using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Service.Animal_Management.Interface_Classes;

namespace Ingogo.Service.Animal_Management.Implementation_Classes
{
    public class FeedingSchemeRepository: IFeedingSchemeRepository
    {
        private readonly IRepository<FeedingScheme> _feedingSchemeRepository;
        private ApplicationDbContext _datacontext;

        public FeedingSchemeRepository()
        {
            _datacontext = new ApplicationDbContext();
            _feedingSchemeRepository = new RepositoryService<FeedingScheme>(_datacontext);
        }

        public FeedingScheme GetById(int id)
        {
            return _feedingSchemeRepository.GetById(id);
        }

        public List<FeedingScheme> GetAll()
        {
            return (_feedingSchemeRepository.GetAll().ToList());
        }

        public void Insert(FeedingScheme model)
        {
            _feedingSchemeRepository.Insert(model);
        }

        public void Update(FeedingScheme model)
        {
            _feedingSchemeRepository.Update(model);
        }

        public void Delete(FeedingScheme model)
        {
            _feedingSchemeRepository.Delete(model);
        }

        public IEnumerable<FeedingScheme> Find(Func<FeedingScheme, bool> predicate)
        {
            return _feedingSchemeRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
