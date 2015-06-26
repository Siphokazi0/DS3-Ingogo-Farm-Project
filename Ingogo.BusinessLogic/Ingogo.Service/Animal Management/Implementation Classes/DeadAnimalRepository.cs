using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Service.Animal_Management.Interface_Classes;

namespace Ingogo.Service.Animal_Management.Implementation_Classes
{
    public class DeadAnimalRepository:IDeadAnimalRepositorycs
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<DeadAnimal> _deadAnimalRepository;

        public DeadAnimalRepository()
        {
            _datacontext = new ApplicationDbContext();
            _deadAnimalRepository = new RepositoryService<DeadAnimal>(_datacontext);
            
        }

        public DeadAnimal GetById(int id)
        {
            return _deadAnimalRepository.GetById(id);
        }

        public List<DeadAnimal> GetAll()
        {
            return _deadAnimalRepository.GetAll().ToList();
        }

        public void Insert(DeadAnimal model)
        {
            _deadAnimalRepository.Insert(model);
        }

        public void Update(DeadAnimal model)
        {
            _deadAnimalRepository.Update(model);
        }

        public void Delete(DeadAnimal model)
        {
            _deadAnimalRepository.Delete(model);
        }

        public IEnumerable<DeadAnimal> Find(Func<DeadAnimal, bool> predicate)
        {
            return _deadAnimalRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

    }
}
