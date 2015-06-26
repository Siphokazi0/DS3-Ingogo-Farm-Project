using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Purchase_Management.Interface_Classes;
using Ingogo.Data.Purchase_Management.Models;
using Ingogo.Model.Purchase_Management.Model_View;
using Ingogo.Service.Purchase_Management.Implementation_Classes;

//21225381 SD FIKENI: Changed namespace from 'Ingogo.BusinessLogic' to
//'Ingogo.BusinessLogic.Purchase_Management.Implementation_Classes'

namespace Ingogo.BusinessLogic.Purchase_Management.Implementation_Classes
{
    public class FeedingStockBussiness : IFeedingStockBussiness
    {
        public List<FeedingStockView> GetAllFeedingStock()
        {
            using (var feedingStock = new FeedingStockRepository())
            {
                return feedingStock.GetAll().Select(x => new FeedingStockView
                {
                    FeedingStockId = x.FeedingStockId,
                    ItemName = x.ItemName,
                    ItemPrice = x.ItemPrice,
                    Mass = x.Mass,
                    DateOfPurchase = x.DateOfPurchase,
                    ExpairyDate = x.ExpairyDate,
                    NumberOfItems = x.NumberOfItems,
                    TotalPrice = x.TotalPrice,
                    TotalMass = x.TotalMass
                }).ToList();

            }
        }

        public void AddFeedingStock(FeedingStockView model)
        {
            using (var feedingStock = new FeedingStockRepository())
            {
                var feed = new FeedingStock
                {
                    FeedingStockId = model.FeedingStockId,
                    ItemName = model.ItemName,
                    ItemPrice = model.ItemPrice,
                    Mass = model.Mass,
                    DateOfPurchase = model.DateOfPurchase,
                    NumberOfItems = model.NumberOfItems,
                    ExpairyDate = model.ExpairyDate,

                    TotalPrice = model.NumberOfItems * model.ItemPrice,
                    TotalMass = model.NumberOfItems * model.Mass
                };
                feedingStock.Insert(feed);
            }
        }

        public void UpdateFeedingStock(FeedingStockView model)
        {
            using (var feedingStock = new FeedingStockRepository())
            {
                FeedingStock feed = feedingStock.GetById(model.FeedingStockId);
                if (feed != null)
                {
                    feed.FeedingStockId = model.FeedingStockId;
                    feed.ItemName = model.ItemName;
                    feed.NumberOfItems = model.NumberOfItems;
                    feed.Mass = model.Mass;
                    feed.ItemPrice = model.ItemPrice;
                    feed.DateOfPurchase = model.DateOfPurchase;
                    feed.ExpairyDate = model.ExpairyDate;
                    feed.TotalPrice = model.NumberOfItems*model.ItemPrice;
                    feed.TotalMass = model.NumberOfItems*model.Mass;
                    feedingStock.Update(feed);
                }
            }
        }

        public void DeleteFeedingStock(int id)
        {
            using (var feedingStock = new FeedingStockRepository())
            {
                FeedingStock feed = feedingStock.GetById(id);
                if (feed != null)
                {
                    feedingStock.Delete(feed);
                } 
            }
        }

        public FeedingStockView GetFeedingStockById(int id)
        {
            using (var feedingStock = new FeedingStockRepository())
            {
                FeedingStock feed = feedingStock.GetById(id);
                var feedView = new FeedingStockView();
                if (feed != null)
                {
                    feedView.FeedingStockId = feed.FeedingStockId;
                    feedView.ItemName = feed.ItemName;
                    feedView.ItemPrice = feed.ItemPrice;
                    feedView.Mass = feed.Mass;
                    feedView.DateOfPurchase = feed.DateOfPurchase;
                    feedView.NumberOfItems = feed.NumberOfItems;
                    feedView.ExpairyDate = feed.ExpairyDate;
                    feedView.TotalPrice = feed.TotalPrice;
                    feedView.TotalMass = feed.TotalMass;
                }
                return feedView;
            }
        }

       /* public void Details(FeedingStockView id)
        {
            using (var feed = new FeedingStockRepository())
            {
                var stock = feed.GetById(id.FeedingStockId);
                feed.GetAll(stock);
                return feed.GetAll().Select(x => new FeedingStockView
                {
                    FeedingStockId = x.FeedingStockId,
                    DateOfPurchase = x.DateOfPurchase,
                    ExpairyDate = x.ExpairyDate,
                    NumberOfItems = x.NumberOfItems,
                }).ToList();
            }
        } */
    }
}
