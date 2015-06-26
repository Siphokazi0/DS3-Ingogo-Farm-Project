using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Service.Animal_Management.Interface_Classes;

namespace Ingogo.Service.Animal_Management.Implementation_Classes
{
    public class AnimalRepository:IAnimalRepository
    {
        private ApplicationDbContext _datacontext;
        private readonly IRepository<Animal> _animalRepository;

        public AnimalRepository()
        {
            _datacontext = new ApplicationDbContext();
            _animalRepository = new RepositoryService<Animal>(_datacontext);
            
        }

        public Animal GetById(int id)
        {
           return _animalRepository.GetById(id);
        }

        public List<Animal> GetAll()
        {
            return _animalRepository.GetAll().ToList();
        }

        public void Insert(Animal model)
        {
            _animalRepository.Insert(model);
        }

        public void Update(Animal model)
        {
            _animalRepository.Update(model);
        }

        public void Delete(Animal model)
        {
            _animalRepository.Delete(model);
        }

        public IEnumerable<Animal> Find(Func<Animal, bool> predicate)
        {
           return  _animalRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }


    }
}
