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
    public class FeedingIngredientRepository : IFeedingIngredientRepository
    {
        private ApplicationDbContext _datacontext;
        private readonly IRepository<FeedingIngredients> _feedingPercentageRepository;

        public FeedingIngredientRepository()
        {
            _datacontext = new ApplicationDbContext();
            _feedingPercentageRepository = new RepositoryService<FeedingIngredients>(_datacontext);
            
        }
        
        public FeedingIngredients GetById(int id)
        {
            return _feedingPercentageRepository.GetById(id);
        }

        public List<FeedingIngredients> GetAll()
        {
            return _feedingPercentageRepository.GetAll().ToList();
        }

        public void Insert(FeedingIngredients model)
        {
            _feedingPercentageRepository.Insert(model);
        }

        public void Update(FeedingIngredients model)
        {
            _feedingPercentageRepository.Update(model);
        }

        public void Delete(FeedingIngredients model)
        {
            _feedingPercentageRepository.Delete(model);
        }

        public IEnumerable<FeedingIngredients> Find(Func<FeedingIngredients, bool> predicate)
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
