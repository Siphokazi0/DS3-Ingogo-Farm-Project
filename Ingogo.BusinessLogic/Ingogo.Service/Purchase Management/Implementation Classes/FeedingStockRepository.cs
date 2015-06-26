using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Context;
using Ingogo.Data.Purchase_Management.Models;
using Ingogo.Data.Repository;
using Ingogo.Service.Purchase_Management.Interface_Classes;

//21225381 SD FIKENI: Changed namespace from 'Ingogo.Service' to
//'Ingogo.Service.Purchase_Management.Implementation_Classes'

namespace Ingogo.Service.Purchase_Management.Implementation_Classes
{
    public class FeedingStockRepository : IFeedingStockRepository, IDisposable
    {
        private ApplicationDbContext _datacontext;
        private readonly IRepository<FeedingStock> _feedingStockRepository;

        public FeedingStockRepository()
        {
            _datacontext = new ApplicationDbContext();
            _feedingStockRepository = new RepositoryService<FeedingStock>(_datacontext);
            
        }

        public FeedingStock GetById(int id)
        {
           return _feedingStockRepository.GetById(id);
        }

        public List<FeedingStock> GetAll()
        {
            return _feedingStockRepository.GetAll().ToList();
        }

        public void Insert(FeedingStock model)
        {
            _feedingStockRepository.Insert(model);
        }

        public void Update(FeedingStock model)
        {
            _feedingStockRepository.Update(model);
        }

        public void Delete(FeedingStock model)
        {
            _feedingStockRepository.Delete(model);
        }

        public IEnumerable<FeedingStock> Find(Func<FeedingStock, bool> predicate)
        {
           return _feedingStockRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
