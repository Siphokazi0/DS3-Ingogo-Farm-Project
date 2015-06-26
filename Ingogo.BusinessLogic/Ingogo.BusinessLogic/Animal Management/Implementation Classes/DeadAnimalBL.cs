using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Service.Animal_Management.Implementation_Classes;
using Ingogo.Service.Animal_Management.Interface_Classes;
using Ingogo.Service.Batch_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Animal_Management.Implementation_Classes
{
    public class DeadAnimalBL : IDeadBL
    {
        private AnimalRepository ani = new AnimalRepository();
        private static readonly BatchTypeRepository bat = new BatchTypeRepository();
        private readonly BatchRepository batches = new BatchRepository();

        public List<Animalpar> GetAllDeadAnimals()
        {
            //DeadAnimalView model = new DeadAnimalView();
            using (var b = new DeadAnimalRepository())
            {
                
                return b.GetAll().Select(x => new Animalpar
                {
                    AnimalId = x.AnimalId,
                    AniCode = x.AniCode,
                    BatchTypeDesc = bat.GetAll().Find(y => y.BatchTypeid == x.BatchTypeid).BatchTypeDesc,
                    AniColor = x.AniColor,
                    AniFeedingStatus = x.AniFeedingStatus,
                    AniAge = x.AniAge,
                    AniGender = x.AniGender,
                    AniHealthStatus = "Dead",
                    AniCurrentCost = x.AniCurrentCost,
                    AniSaleStatus = x.AniSaleStatus,
                    AniTotCost = 0,
                    AnimalValue = Convert.ToDouble(x.AniCurrentCost + x.AniTotCost),
                    //deathCause = "none",


                }).ToList();
            }

        }

        public void InsertDeadAnimals(Animalpar model)
        {
            int num = 0;
            foreach (var b in batches.GetAll())
            {
                if (model.AniCode.Substring(0,2)==model.BatchTypeDesc.Substring(0,2))
                {
                    num = b.NumOfAnimals - 1;
                }
            }
            
            using (var x = new DeadAnimalRepository())
            {

              
                var deadAnimals = new DeadAnimal
                {

                    AnimalId = model.AnimalId,
                    AniCode = model.AniCode,
                    BatchTypeid = bat.GetAll().Find(y => y.BatchTypeDesc == model.BatchTypeDesc).BatchTypeid,
                    AniColor = model.AniColor,
                    AniFeedingStatus = model.AniFeedingStatus,
                    AniAge = model.AniAge,
                    AniGender = model.AniGender,
                    AniHealthStatus = "Dead",
                    AniCurrentCost = model.AniCurrentCost,
                    AniSaleStatus = model.AniSaleStatus,
                    AniTotCost = 0,
                    AnimalValue = 0,
                    //deathCause = model.deathCause,
                };
                x.Insert(deadAnimals);

            }
        }

        public Animalpar GetDeadById(int id)
        {
            using (var animal = new DeadAnimalRepository())
            {
                DeadAnimal ani = animal.GetById(id);
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

        public void UpdateDeadAnimals(Animalpar model)
        {

            using (var animal = new DeadAnimalRepository())
            {
                DeadAnimal ani = animal.GetById(model.AnimalId);
                if (ani != null)
                {
                    ani.AnimalId = model.AnimalId;
                    ani.AniCode = model.AniCode;
                    //ani.b = model.BatchTypeDesc;
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

        public void DeadAnimalDetails(DeadAnimalView model)
        {
            using (var animal = new DeadAnimalRepository())
            {
                DeadAnimal ani = animal.GetById(model.AnimalId);
            }
        }

        public void DeleteDeadAnimals(int id)
        {
            using (var deadAnimal = new DeadAnimalRepository())
            {
                DeadAnimal anima = deadAnimal.GetById(id);
                if (anima != null)
                {
                    deadAnimal.Delete(anima);
                }
            }
        }

        public string GenerateAnimalId(Animalpar model)
        {
            string id = "";
            foreach (var b in bat.GetAll())
            {
                if (b.BatchTypeDesc == model.BatchTypeDesc)
                {
                    id = (b.BatchTypeDesc.Substring(0,2) + "-" + "SU" + "-" + 0 + "-" + "-" +
                          Guid.NewGuid().ToString().Substring(0, 5)).ToUpper();
                }
            }

            return id;
        }

        public decimal current(Animalpar view)
        {

            decimal current = 0;
            //var ani = new BatchRepository();
            var animal = new AnimalRepository();

            foreach (var model in batches.GetAll())
            {
                if (view.BatchTypeid == model.BatchTypeid)
                {
                    current = (model.Totalcost/model.NumOfAnimals);
                }
            }
            return current;
        }
    }
}
