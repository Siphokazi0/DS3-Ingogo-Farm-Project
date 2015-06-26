using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Employee_Management.Models;
using Ingogo.Data.Repository;
using Ingogo.Service.Animal_Management.Interface_Classes;

namespace Ingogo.Service.Animal_Management.Implementation_Classes
{
    public class FeedingPercentageRepository : IFeedingPercentageRepository
    {
        private ApplicationDbContext _datacontext;
        private readonly IRepository<FeedingPercentage> _feedingPercentageRepository;

        public FeedingPercentageRepository()
        {
            _datacontext = new ApplicationDbContext();
            _feedingPercentageRepository = new RepositoryService<FeedingPercentage>(_datacontext);
            
        }
        
        public FeedingPercentage GetById(int id)
        {
            return _feedingPercentageRepository.GetById(id);
        }

        public List<FeedingPercentage> GetAll()
        {
            return _feedingPercentageRepository.GetAll().ToList();
        }

        public void Insert(FeedingPercentage model)
        {
            _feedingPercentageRepository.Insert(model);
        }

        public void Update(FeedingPercentage model)
        {
            _feedingPercentageRepository.Update(model);
        }

        public void Delete(FeedingPercentage model)
        {
            _feedingPercentageRepository.Delete(model);
        }

        public IEnumerable<FeedingPercentage> Find(Func<FeedingPercentage, bool> predicate)
        {
            return _feedingPercentageRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
