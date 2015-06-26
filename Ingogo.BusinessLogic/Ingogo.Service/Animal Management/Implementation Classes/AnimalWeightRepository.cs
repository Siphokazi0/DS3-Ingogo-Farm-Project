using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Service.Animal_Management.Interface_Classes;

namespace Ingogo.Service.Animal_Management.Implementation_Classes
{
    public class AnimalWeightRepository : IAnimalWeightRepository
    {
         private ApplicationDbContext _datacontext;
         private readonly IRepository<AnimalWeight> _animalweightRepository;

        public AnimalWeightRepository()
        {
            _datacontext = new ApplicationDbContext();
            _animalweightRepository = new RepositoryService<AnimalWeight>(_datacontext);
            
        }

        public AnimalWeight GetById(int id)
        {
            return _animalweightRepository.GetById(id);
        }

        public List<AnimalWeight> GetAll()
        {
            return _animalweightRepository.GetAll().ToList();
        }

        public void Insert(AnimalWeight model)
        {
            _animalweightRepository.Insert(model);
        }

        public void Update(AnimalWeight model)
        {
            _animalweightRepository.Update(model);
        }

        public void Delete(AnimalWeight model)
        {
            _animalweightRepository.Delete(model);
        }

        public IEnumerable<AnimalWeight> Find(Func<AnimalWeight, bool> predicate)
        {
           return _animalweightRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }


    }
}
