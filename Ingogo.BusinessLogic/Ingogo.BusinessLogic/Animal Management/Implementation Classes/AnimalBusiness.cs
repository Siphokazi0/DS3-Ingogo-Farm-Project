using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Service.Animal_Management.Implementation_Classes;
using Ingogo.Service.Batch_Management.Implementation_Classes;
using Ingogo.Service.Treatment_Managemnt.Implementation_Classes;

//using Ingogo.Data.Treatment_Managemnt.Models;

//using Ingogo.Service.Batch_Management.Implementation_Classes;
//using Ingogo.Service.Treatment_Managemnt.Implementation_Classes;

namespace Ingogo.BusinessLogic.Animal_Management.Implementation_Classes
{
    public class AnimalBusiness : IAnimalBusiness
    {
        //private static readonly FeedLotRepository feedL = new FeedLotRepository();
      //  private readonly AnimalTreatRepository treat = new AnimalTreatRepository();
        private readonly AnimalRepository anima = new AnimalRepository();
        private static readonly BatchTypeRepository bat = new BatchTypeRepository();
        //private readonly SupplierRepository sup = new SupplierRepository();
        private readonly BatchRepository batches = new BatchRepository();
        public int num;

        public List<Animalpar> GetAllAnimals()
        {
            decimal sum = 0;
            AnimalView model = new AnimalView();
            using (var b = new AnimalRepository())
            {

                return b.GetAll().Select(x => new Animalpar
                {
                    AnimalId = x.AnimalId,
                    AniCode = x.AniCode,
                    BatchTypeDesc = bat.GetAll().Find(y => y.BatchTypeid == x.BatchTypeid).BatchTypeDesc,
                    AniColor = x.AniColor,
                    AniFeedingStatus = "FeedLot",
                    AniAge = x.AniAge,
                    AniGender = x.AniGender,
                    AniHealthStatus = "Healthy",
                    AniCurrentCost = x.AniCurrentCost,
                    AniSaleStatus = "Not Ready",
                    AniTotCost = 0,
                    AnimalValue = Convert.ToDouble(x.AniCurrentCost + x.AniTotCost),
                }).ToList();

            }


        }

        public void InsertAnimals(AnimalView model)
        {

            using (var x = new AnimalRepository())
            {

                
                var animals = new Animal
               {

                   AnimalId = model.AnimalId,
                    AniCode = model.AniCode,
                   BatchTypeid = model.BatchTypeid,
                   AniColor = model.AniColor,
                    AniFeedingStatus = "FeedLot",
                   AniAge = model.AniAge,
                   AniGender = model.AniGender,
                    AniHealthStatus = "Healthy",
                    AniCurrentCost = model.AniCurrentCost,
                   AniSaleStatus = "Not Ready",
                    AniTotCost = 0,
                    AnimalValue = model.AnimalValue,
               };
                x.Insert(animals);

            }


        }


        public void DeleteAnimals(Animalpar model)
        {
            using (var animal = new AnimalRepository())
            {
                Animal ani = animal.GetById(model.AnimalId);
                if (ani != null)
                {
                    animal.Delete(ani);
                }
            }
        }

        public Animalpar GetAnimalById(int id)
        {
            using (var animal = new AnimalRepository())
            {
                Animal ani = animal.GetById(id);
                var anView = new Animalpar();
                if (ani != null)
                {
                    anView.AnimalId = ani.AnimalId;
                    anView.AniCode = ani.AniCode;
                    anView.BatchTypeDesc = bat.GetAll().Find(y => y.BatchTypeid == ani.BatchTypeid).BatchTypeDesc;
                    anView.AniColor = ani.AniColor;
                    anView.AniFeedingStatus = ani.AniFeedingStatus;
                    anView.AniAge = ani.AniAge;
                    anView.AniGender = ani.AniGender;
                    anView.AniHealthStatus = ani.AniHealthStatus;
                    anView.AniCurrentCost = ani.AniCurrentCost;
                    anView.AniSaleStatus = ani.AniSaleStatus;
                    anView.AniTotCost = ani.AniTotCost;
                    anView.AnimalValue = ani.AnimalValue;
                    
                }
                return anView;
            }
        }

        public AnimalView GetAnimalById2(AnimalView anView)
        {
            decimal sum = 0;
            int count = 0;
            count++;
            sum = anima.GetAll().Sum(x => x.AniCurrentCost);
            using (var animal = new AnimalRepository())
            {
                foreach (var c in bat.GetAll())
                {
                    Batch ani = batches.GetAll().FindLast(x => x.BatchTypeid == c.BatchTypeid);
                    if (ani != null)
                    {
                        anView.AnimalId = count;
                        anView.AniCode = ani.BatchCode+ "-" + "SU" + "-" +
                                         anView.AnimalId + "-" + Guid.NewGuid().ToString().Substring(0, 5);
                        anView.BatchTypeid = anView.BatchTypeid;
                        anView.AniColor = "";
                        anView.AniFeedingStatus = "Feeding Lot";
                        anView.AniAge = 0;
                        anView.AniGender = "";
                        anView.AniHealthStatus = "Healthy";
                        anView.AniCurrentCost = ani.Totalcost / ani.NumOfAnimals;
                        anView.AniSaleStatus = "Not Ready";
                        anView.AniTotCost = 0;
                        anView.AnimalValue = Convert.ToDouble(anView.AniCurrentCost + anView.AniTotCost);


                }
                }

                return anView;
            }
        }

        public void UpdateAnimals(Animalpar model)
        {
            using (var animal = new AnimalRepository())
            {
                Animal ani = animal.GetById(model.AnimalId);
                if (ani != null)
                {
                    ani.AnimalId = model.AnimalId;
                    ani.AniCode = model.AniCode;
                    //ani.BatchTypeid = model.b;
                    ani.AniColor = model.AniColor;
                    ani.AniFeedingStatus = model.AniFeedingStatus;
                    ani.AniAge = model.AniAge;
                    ani.AniGender = model.AniGender;
                    ani.AniHealthStatus = model.AniHealthStatus;
                    ani.AniCurrentCost = model.AniCurrentCost;
                    ani.AniSaleStatus = model.AniSaleStatus;
                    ani.AniTotCost = model.AniTotCost;
                    ani.AnimalValue = model.AnimalValue;
                    animal.Update(ani);
                }
            }

        }

        public void AnimalDetails(AnimalView model)
        {
            using (var animal = new AnimalRepository())
            {
                Animal ani = animal.GetById(model.AnimalId);
            }
        }

        public string GenerateAnimalId(AnimalView model)
        {
            string id = "";
            foreach (var b in bat.GetAll())
            {
                if (b.BatchTypeid == model.BatchTypeid)
                {
                    id = (b.BatchTypeDesc.Substring(0,2) + "-" + "SU" + "-" + 0 + "-" + "-" +
                     Guid.NewGuid().ToString().Substring(0, 5)).ToUpper();
                }
            }

            return id;
        }

        public decimal current(AnimalView view)
        {

            decimal current = 0;
            var animal = new AnimalRepository();

            foreach (var model in batches.GetAll())
            {
                if (view.BatchTypeid == model.BatchTypeid)
                {
                    current = (model.Totalcost / model.NumOfAnimals);
                }
            }
            return current;
        }

        public int tot(AnimalView model)
        {
        
            decimal sum = 0;
            sum = GetAllAnimals().FindAll(x => x.AniCode.Substring(0,2) == model.AniCode.Substring(0,2)).Sum(x => x.AniCurrentCost) + model.AniCurrentCost;
            var m = batches.GetAll().Find(x => x.BatchTypeid == model.BatchTypeid);
            if (sum > m.Totalcost)
            {
                num = 1;
            }
            else
            {
                num = 0;

        }
            return num;


        }
        public int TotalCost(AnimalView model)
        {

            decimal sum = 0;
            sum = GetAllAnimals().FindAll(x => x.AniCode.Substring(0,2) == model.AniCode.Substring(0,2)).Sum(x => x.AniCurrentCost) + model.AniCurrentCost;
            var m = batches.GetAll().Find(x => x.BatchTypeid == model.BatchTypeid);
            if (sum > m.Totalcost || sum < m.Totalcost)
                {
                num = 1;
        }
            else
            {
                num = 0;

    }
            return num;


        }
    }
}






