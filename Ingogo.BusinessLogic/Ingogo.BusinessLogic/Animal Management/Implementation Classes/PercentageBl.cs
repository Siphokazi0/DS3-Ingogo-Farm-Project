using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.BusinessLogic.Purchase_Management.Implementation_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Model.Purchase_Management.Model_View;
using Ingogo.Service.Animal_Management.Implementation_Classes;
using Ingogo.Service.Purchase_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Animal_Management.Implementation_Classes
{
    public class PercentageBl:IPercentageBl
    {
        private  readonly FeedingStockRepository _fStockRepo = new FeedingStockRepository();
        private readonly FeedingSchemeRepository _fSchemeRepo = new FeedingSchemeRepository();
        
        public void AddPercent(PercentageView model)
        {
            using (var percRepo = new PercentageRepository())
            {
                var ingPerc = new Percentage()
                {
                    PercentageId = model.PercentageId,
                    FeedingStockId = _fStockRepo.GetAll().Find(x=>x.FeedingStockId == model.FeedingStockId).FeedingStockId,
                    PercentageRate = model.Percentage,
                    FeedingSchemeId = _fSchemeRepo.GetAll().Find(p=>p.FeedingSchemeId==model.FeedingSchemeId).FeedingSchemeId
                };
               percRepo.Insert(ingPerc);
               CalcIngredientCost(model);
            }
        }

  //Method to validate if stock items exist from which a percenatge can be obtained from
        public bool IsAvailable(PercentageView model)
        {
            var available = false;

            FeedingStockBussiness stockItem= new FeedingStockBussiness();

            FeedingStockView stockView = stockItem.GetFeedingStockById(model.FeedingStockId);

            if (stockView != null)
                if (stockView.NumberOfItems >= 1)
                           available = true;

            return available;
        }

        public void CalcIngredientCost(PercentageView model)
        {
 //to get percentage for the ingredient added
            double percRate = model.Percentage/100;

            using (_fStockRepo)
            {
                var stockItem = _fStockRepo.GetById(model.FeedingStockId);

                if (stockItem != null)
                {
//to get total mass of the ingredient in stock
                    double totalMass = stockItem.NumberOfItems*stockItem.Mass;

//to get amount of mass to remove from stock item according to percentage inputted
                    double massUsed = totalMass*percRate;

//to get number of items that should be left in stock for the ingredient chosen
                    int numItemsLeft = (int) (totalMass - massUsed)/stockItem.Mass;

                    stockItem.NumberOfItems = numItemsLeft;

                    _fStockRepo.Update(stockItem);
//to get how much the ingredient to be used costs
                    double ingCost = (massUsed/stockItem.Mass)*stockItem.ItemPrice;

                    var feedingScheme = _fSchemeRepo.GetById(model.FeedingSchemeId);
                    feedingScheme.TotalFeedingCost += ingCost;
                    
                    _fSchemeRepo.Update(feedingScheme);
                }
            }
        }

        public List<PercentagePartialView> GetAllIngredients()
        {
            using (var percRepo = new PercentageRepository())
            {
                return percRepo.GetAll().Select(x => new PercentagePartialView
                {
                    PercentageId = x.PercentageId,
                    ItemName = _fStockRepo.GetAll().Find(j=>j.FeedingStockId==x.FeedingStockId).ItemName,
                    Percentage = x.PercentageRate,
                    SchemeCode = _fSchemeRepo.GetAll().Find(j=>j.FeedingSchemeId==x.FeedingSchemeId).SchemeCode
                }).ToList();
            }
        }

        public void DeletePercent(PercentageView model)
        {
            using (var percRepo = new PercentageRepository())
            {
                Percentage feed = percRepo.GetById(model.FeedingSchemeId);

                if (feed != null)
                {
                    percRepo.Delete(feed);
                }
            }
        }

        public PercentagePartialView GetPercView(int id)
        {
            using (var ingreRepo = new PercentageRepository())
            {
                Percentage perc = ingreRepo.GetById(id);

                var ingredView = new PercentagePartialView();

                if (perc != null)
                {
                    ingredView.PercentageId = perc.PercentageId;
                    ingredView.ItemName =
                        _fStockRepo.GetAll().Find(j => j.FeedingStockId == perc.FeedingStockId).ItemName;
                    ingredView.Percentage = perc.PercentageRate;
                    ingredView.SchemeCode =
                        _fSchemeRepo.GetAll().Find(j => j.FeedingSchemeId == perc.FeedingSchemeId).SchemeCode;
                }
                return ingredView;
            }
        }
    }
}
