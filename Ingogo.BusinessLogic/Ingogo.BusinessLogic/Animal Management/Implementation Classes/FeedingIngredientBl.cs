using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Service.Animal_Management.Implementation_Classes;
using Ingogo.Service.Purchase_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Animal_Management.Implementation_Classes
{
    public class FeedingIngredientBl : IFeedingIngredientBl
    {
        private readonly FeedingStockRepository _stock = new FeedingStockRepository();
        private readonly FeedingPercentageRepository _percentage = new FeedingPercentageRepository();

        public List<FeedingIngredientViewParAll> GetAllFeedIngr()
        {
            using (var feedIng = new FeedingIngredientRepository())
            {
                return feedIng.GetAll().Select(x => new FeedingIngredientViewParAll
                {
                    FeedingIngredientsId = x.FeedingIngredientsId,
                    Percentage = (_percentage.GetAll().ToList().Find(p => p.FeedingPercentageId == x.FeedingPercentageId).Percentage).ToString(CultureInfo.InvariantCulture),
                    StockItem = _stock.GetAll().ToList().Find(s => s.FeedingStockId == x.FeedingStockId).ItemName,
                    IngredientMass = x.IngredientMass
                }).ToList();
            }
        }

        public void AddFeedIngr(FeedingIngredientsView model)
        {
            using (var feedIng = new FeedingIngredientRepository())
            {
                //calculate percentage from dropdown list
                string per =
                    _percentage.GetAll()
                        .ToList()
                        .Find(x => x.FeedingPercentageId == model.FeedingPercentageId)
                        .Percentage;

                //get percentage length
                int indper = per.Length;


                //Get total mass from feeding stock
                double mass = _stock.GetAll().ToList().Find(x => x.FeedingStockId == model.FeedingStockId).TotalMass;

                //calculatye percentage mass that has been added as an ingredient
                double calcPercMass = ((Convert.ToDouble(per.Substring(0, indper - 2))) / 100) * mass;

                //Add Ingredients to database
                FeedingIngredients getList = feedIng.GetAll().ToList().Find(x => x.FeedingStockId == model.FeedingStockId);
                if (getList != null)
                {
                    getList.IngredientMass = Convert.ToString(Convert.ToDouble(getList.IngredientMass) + calcPercMass, CultureInfo.InvariantCulture);
                    getList.FeedingPercentageId = model.FeedingPercentageId;
                    getList.FeedingStockId = model.FeedingStockId;

                    feedIng.Update(getList);
                }
                else
                {
                    var feedIn = new FeedingIngredients
                    {
                        FeedingIngredientsId = model.FeedingIngredientsId,
                        IngredientMass = calcPercMass.ToString(CultureInfo.InvariantCulture),
                        FeedingPercentageId = model.FeedingPercentageId,
                        FeedingStockId = model.FeedingStockId
                    };
                    //Call repository insert 
                    feedIng.Insert(feedIn);
                }
                
                

                //Mass from stock update every time ingredient is added
                //Gets stock item that has been selected
                var stock = _stock.GetAll().ToList().Find(x => x.FeedingStockId == model.FeedingStockId);
                if (stock != null)
                {
                    //Calculate mass left
                    double massLeff = stock.TotalMass - calcPercMass;
                    
                    //Get the number of items minused in stock
                    double massRatio = massLeff/stock.Mass;

                    //Check if number is a double 
                    int index = massRatio.ToString(CultureInfo.InvariantCulture).IndexOf('.');

                    //calculates the number of items bought and replace values with left
                    int number;
                    if (index > 0)
                    {
                        number= (Convert.ToInt16(massRatio.ToString(CultureInfo.InvariantCulture).Substring(0, index)) + 1);
                        stock.NumberOfItems = number;
                    }
                    else
                    {
                        number = Convert.ToInt16(massRatio.ToString(CultureInfo.InvariantCulture));
                        stock.NumberOfItems = number;
                    }
                    //update mass stock to new value
                    stock.TotalMass = Math.Round(massLeff,0);

                    //call update method from repository and update
                    _stock.Update(stock);
                }

            }
        }

        public void DeleteFeedIngr(int id)
        {
            using (var feedIng = new FeedingIngredientRepository())
            {
                var feed = feedIng.GetById(id);
                if (feed != null)
                {
                    //from ingredients
                    var ingredient = feedIng.GetById(id);

                    //Mass from stock
                    //Get selected stock
                    var stock = _stock.GetAll().ToList().Find(x => x.FeedingStockId == ingredient.FeedingStockId);
                    if (stock != null)
                    {
                        //Calculate total mass from stock add with selected ingredients 
                        double totalMass = (Math.Round(stock.TotalMass, 0) + Math.Round(Convert.ToDouble(ingredient.IngredientMass), 0));

                        //Gets the average mass
                        double qtyRatio = totalMass / stock.Mass;

                        //Checks if its a double or not
                        int index = qtyRatio.ToString(CultureInfo.InvariantCulture).IndexOf('.');

                        //calculates the number of items bought and replace values with left
                        int number;
                        if (index > 0)
                        {
                            number =
                                (Convert.ToInt16(qtyRatio.ToString(CultureInfo.InvariantCulture).Substring(0, index)) +
                                 1);
                            stock.NumberOfItems = number;
                        }
                        else
                        {
                            number = Convert.ToInt16(qtyRatio.ToString(CultureInfo.InvariantCulture));
                            stock.NumberOfItems = number;
                        }
                        //equate mass with the calculated
                        stock.TotalMass = totalMass;

                        //Call update method fro the repository
                        _stock.Update(stock);
                    }
                    feedIng.Delete(feed);
                }
            }
        }

        public FeedingIngredientViewParAll GetFeedIngrById(int id)
        {
            using (var feedIng = new FeedingIngredientRepository())
            {
                var feed = feedIng.GetById(id);
                var feedView = new FeedingIngredientViewParAll();
                if (feed != null)
                {
                    feedView.FeedingIngredientsId = feed.FeedingIngredientsId;
                    feedView.Percentage = feed.FeedingPercentage.Percentage;
                    feedView.StockItem = feed.FeedingStock.ItemName;
                    feedView.IngredientMass = feed.IngredientMass;
                }
                return feedView;
            }
        }

        public void UpdateFeedIngr(FeedingIngredientsView model)
        {
            using (var feedIng = new FeedingIngredientRepository())
            {
                var feed = feedIng.GetById(model.FeedingIngredientsId);
                if (feed != null)
                {
                    feed.FeedingIngredientsId = model.FeedingIngredientsId;
                    feed.FeedingPercentageId = model.FeedingPercentageId;
                    feed.FeedingStockId = model.FeedingStockId;
                    feed.IngredientMass = model.IngredientMass;
                }
            }
        }
    }
}
