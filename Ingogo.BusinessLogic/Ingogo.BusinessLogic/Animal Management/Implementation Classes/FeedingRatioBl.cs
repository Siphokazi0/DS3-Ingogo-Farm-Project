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
    public class FeedingRatioBl : IFeedingRatioBl
    {
        private readonly FeedingIngredientRepository _ingredients = new FeedingIngredientRepository();

        public List<FeedingRatioView> GetAllFeedRatio()
        {
            using (var feedRatio = new FeedingRatioRepository())
            {
                return feedRatio.GetAll().Select(x => new FeedingRatioView
                {
                    FeedingRatioId = x.FeedingRatioId,
                    ProductName = x.ProductName,
                    ProductMass = x.ProductMass
                }).ToList();
            }
        }

        public void AddFeedRatio(FeedingRatioView model)
        {
            using (var feedRatio = new FeedingRatioRepository())
            {
                //from ingredients
                double totalIngredientsMass = _ingredients.GetAll().Sum(x => Convert.ToDouble(x.IngredientMass));

                var feed = new FeedingRatio
                {
                    FeedingRatioId = model.FeedingRatioId,
                    ProductName = model.ProductName,
                    ProductMass = totalIngredientsMass.ToString(CultureInfo.InvariantCulture) + " Kg."
                };
                feedRatio.Insert(feed);
                DeleteAllIngredientsFromList();
            }
        }

        public void DeleteAllIngredientsFromList()
        {
            using (var feedIng = new FeedingIngredientRepository())
            {
                foreach (var ingredient in feedIng.GetAll())
                {
                    var ing = feedIng.GetById(ingredient.FeedingIngredientsId);
                    if (ing != null)
                    {
                        feedIng.Delete(ing);
                    }
                }
            }
        }

        public FeedingRatioView GetFeedRatioById(int id)
        {
            using (var feedRatio = new FeedingRatioRepository())
            {
                var feed = feedRatio.GetById(id);
                var feedView = new FeedingRatioView();
                if (feed != null)
                {
                    feedView.FeedingRatioId = feed.FeedingRatioId;
                    feedView.ProductMass = feed.ProductMass;
                    feedView.ProductName = feed.ProductName;
                }
                return feedView;
            }
        }
    }
}
