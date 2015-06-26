using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Service.Animal_Management.Interface_Classes;

namespace Ingogo.Service.Animal_Management.Implementation_Classes
{
    public class PercentageRepository:IPercentageRepository
    {
        private readonly IRepository<Percentage> _percentageRepository;
        private ApplicationDbContext _datacontext;

        public PercentageRepository()
        {
            _datacontext = new ApplicationDbContext();
            _percentageRepository = new RepositoryService<Percentage>(_datacontext);
        }

        public void Insert(Percentage model)
        {
            _percentageRepository.Insert(model);
        }

        public List<Percentage> GetAll()
        {
            return (_percentageRepository.GetAll().ToList());
        }

        public void Delete(Percentage model)
        {
            _percentageRepository.Delete(model);
        }

        public Percentage GetById(int id)
        {
            return _percentageRepository.GetById(id);
        }

        public void Update(Percentage model)
        {
            _percentageRepository.Update(model);
        }

        public IEnumerable<Percentage> Find(Func<Percentage, bool> predicate)
        {
            return _percentageRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
