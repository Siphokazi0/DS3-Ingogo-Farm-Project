using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Service.Animal_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Animal_Management.Implementation_Classes
{
    public class AnimalWeightBl : IAnimalWeightBl
    {

        private readonly AnimalRepository _animal = new AnimalRepository();
        //getting all animals weighted
        public List<AnimalWeightViewPar> GetAllAnimalWeight()
        {
            using (var animalweight = new AnimalWeightRepository())
            { 
                return animalweight.GetAll().Select(x => new AnimalWeightViewPar
                {
                    AnimalWeightId = x.AnimalWeightId,
                    AnimalCode = _animal.GetAll().ToList().Find(y => y.AnimalId == x.AnimalId).AniCode,
                    AverageWeight = x.AverageWeight,
                    DateWeighted = x.DateWeighted,
                    OriginalWeight = x.OriginalWeight

                }).ToList();
            }
        }

        //weigh animal
        public void AddAnimalWeight(AnimalWeightView model)
        {

            using (var animalweight = new AnimalWeightRepository())
            {
                var weight = new AnimalWeight
                {
                    AnimalWeightId = model.AnimalWeightId,
                    DateWeighted = DateTime.Now,
                    OriginalWeight = model.OriginalWeight, 
                    AverageWeight = model.AverageWeight,
                    AnimalId = model.AnimalId
                    
                };
                List<AnimalWeight> listAni =
                    animalweight.GetAll().ToList().FindAll(x => x.AnimalId == model.AnimalId).ToList();
                weight.AverageWeight += ((model.OriginalWeight+listAni.Sum(x => x.OriginalWeight)) / (listAni.Count+1));
                animalweight.Insert(weight);
            }
        }
        

        public void DeleteAnimalWeight(int id)
        {
            using (var animalweight = new AnimalWeightRepository())
            {
                AnimalWeight weight = animalweight.GetById(id);
                if (weight != null)
                {
                    animalweight.Delete(weight);
                }
            }
        }

        public AnimalWeightViewPar GetByIdAnimalWeight(int id)
        {
            using (var animalweight = new AnimalWeightRepository())
            {
                AnimalWeight weight = animalweight.GetById(id);
                var weightView = new AnimalWeightViewPar();
                if (weight != null)
                {
                    weightView.AnimalWeightId = weight.AnimalWeightId;
                    weightView.AnimalCode = _animal.GetAll().ToList().Find(x => x.AnimalId == weight.AnimalId).AniCode;
                    weightView.AverageWeight = weight.AverageWeight;
                    weightView.DateWeighted = weight.DateWeighted;
                    weightView.OriginalWeight = weight.OriginalWeight;
                    
                }
                return weightView;
            }
        }

        public void UpdateAnimalWeight(AnimalWeightViewPar model)
        {
            using (var animalweight = new AnimalWeightRepository())
            {
                
                AnimalWeight weight = animalweight.GetById(model.AnimalWeightId);
                if (weight != null)
                {
                    weight.AnimalWeightId = model.AnimalWeightId;
                    //weight.AnimalId =_animal.GetAll().ToList().Find(y => y.AnimalId == weight.AnimalId).AniCode.ToString();
                    weight.AverageWeight = model.AverageWeight;
                    weight.DateWeighted = model.DateWeighted;
                    weight.OriginalWeight = model.OriginalWeight;
  
                    animalweight.Update(weight);
                }
            }
        }
    }
}
