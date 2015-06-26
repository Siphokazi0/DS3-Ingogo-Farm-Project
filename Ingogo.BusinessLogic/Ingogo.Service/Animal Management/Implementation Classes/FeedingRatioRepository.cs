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
    public class FeedingRatioRepository : IFeedingRatioRepository
    {
        private ApplicationDbContext _datacontext;
        private readonly IRepository<FeedingRatio> _feedingRatioRepository;

        public FeedingRatioRepository()
        {
            _datacontext = new ApplicationDbContext();
            _feedingRatioRepository = new RepositoryService<FeedingRatio>(_datacontext);
            
        }
        
        public FeedingRatio GetById(int id)
        {
            return _feedingRatioRepository.GetById(id);
        }

        public List<FeedingRatio> GetAll()
        {
            return _feedingRatioRepository.GetAll().ToList();
        }

        public void Insert(FeedingRatio model)
        {
            _feedingRatioRepository.Insert(model);
        }

        public void Update(FeedingRatio model)
        {
            _feedingRatioRepository.Update(model);
        }

        public void Delete(FeedingRatio model)
        {
            _feedingRatioRepository.Delete(model);
        }

        public IEnumerable<FeedingRatio> Find(Func<FeedingRatio, bool> predicate)
        {
            return _feedingRatioRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
