using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Service.Animal_Management.Implementation_Classes;
using Ingogo.Service.Batch_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Animal_Management.Implementation_Classes
{
    public class FeedingSchemeBl : IFeedingSchemeBl
    {
        private readonly BatchTypeRepository _bTypeRepo= new BatchTypeRepository();

        public List<FeedingSchemePartialView> GetAllFeedSchemeViews()
        {
          
          using (var feedSchemeRepo = new FeedingSchemeRepository())
            {
                var percBl = new PercentageBl();

                return feedSchemeRepo.GetAll().Select(x => new FeedingSchemePartialView
                {
                    FeedingSchemeId = x.FeedingSchemeId,
                    BatchTypeDesc = _bTypeRepo.GetAll().Find(j=>j.BatchTypeid==x.BatchTypeid).BatchTypeDesc,
                    NoOfAnimals = x.NoOfAnimals,
                    DatePrepared = x.DatePrepared,
                    NumIngredients = percBl.GetAllIngredients().Count(j => j.SchemeCode == x.SchemeCode),
                    SchemeCode = x.SchemeCode,
                    CostPerAnimal = x.TotalFeedingCost/x.NoOfAnimals,
                    TotalCostForScheme = x.TotalFeedingCost// CalcTotalCost(x)
                }).ToList();
            }
        }

        public FeedingSchemePartialView GetFeedSchemeById(int id)
        {
            using (var feedSchemeRepo = new FeedingSchemeRepository())
            {
                FeedingScheme feed = feedSchemeRepo.GetById(id);

                var feedView = new FeedingSchemePartialView();

                if (feed != null)
                {
                    feedView.FeedingSchemeId = feed.FeedingSchemeId;
                    feedView.BatchTypeDesc =
                        _bTypeRepo.GetAll().Find(j => j.BatchTypeid == feed.BatchTypeid).BatchTypeDesc;
                    feedView.NoOfAnimals = feed.NoOfAnimals;
                    feedView.DatePrepared = feed.DatePrepared;
                    feedView.CostPerAnimal = feed.FeedCostPerAnimal;
                    feedView.TotalCostForScheme =  feed.TotalFeedingCost;
                    feedView.NumIngredients = feed.NumberOfItems;
                }
                return feedView;
            }
        }


        public void AddFeedScheme(FeedingSchemeView model)
        {
            var datePre = DateTime.Today;
            Random rand = new Random();

            using (var feedSchemeRepo = new FeedingSchemeRepository())
            {
                var feed = new FeedingScheme()
                {
                    FeedingSchemeId = model.FeedingSchemeId,
                    BatchTypeid = _bTypeRepo.GetAll().ToList().Find(x => x.BatchTypeid == model.BatchTypeid).BatchTypeid,
                    NoOfAnimals = CalcAniFeeding(model),
                    DatePrepared = datePre,
                    SchemeCode = datePre.DayOfYear +"#SC#"+ CalcAniFeeding(model)+"#"+rand.Next(1,1000000),
                    FeedCostPerAnimal = 0,
                    TotalFeedingCost = 0,
                    NumberOfItems = 0
                };
                feedSchemeRepo.Insert(feed);
            }
        }

        public int IngredientCount(FeedingSchemeView model)
        {
            PercentageBl percBl= new PercentageBl();

            return percBl.GetAllIngredients().Count(j => j.SchemeCode == model.SchemeCode); 
        }



//Method to get number of animals currently in feeding lots
        private static int CalcAniFeeding(FeedingSchemeView model)
        {
            AnimalBusiness aniBl = new AnimalBusiness();
            BatchTypeBl batchTypeBl = new BatchTypeBl();
            var bDesc = batchTypeBl.GetAllBatchTypes().Find(x=>x.BatchTypeid== model.BatchTypeid);

            return (aniBl.GetAllAnimals().Count(animalpar => animalpar.AniFeedingStatus == "FeedLot" 
                         && animalpar.BatchTypeDesc==bDesc.BatchTypeDesc));
        }
        
        public void UpdateFeedScheme(FeedingSchemePartialView model)
        {
            using (var feedSchemeRepo = new FeedingSchemeRepository())
            {
                FeedingScheme feed = feedSchemeRepo.GetById(model.FeedingSchemeId);
                
                if (feed != null)
                {
                    feed.FeedingSchemeId = model.FeedingSchemeId;
                    feed.NoOfAnimals = model.NoOfAnimals;
                    feed.DatePrepared = model.DatePrepared;
                    feed.NumberOfItems = model.NumIngredients;
                    feed.SchemeCode = model.SchemeCode;
                    feed.FeedCostPerAnimal = model.CostPerAnimal;
                    feed.TotalFeedingCost = model.TotalCostForScheme;
                    
                    feedSchemeRepo.Update(feed);
                }
            }
        }

        public void DeleteFeedScheme(FeedingSchemeView model)
        {
            using (var feedSchemeRepo = new FeedingSchemeRepository())
            {
                FeedingScheme feed = feedSchemeRepo.GetById(model.FeedingSchemeId);

                if (feed != null)
                {
                    feedSchemeRepo.Delete(feed);
                }
            }
        }
    }
}
