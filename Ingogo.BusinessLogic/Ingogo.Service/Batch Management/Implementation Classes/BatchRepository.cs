using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Service.Batch_Management.Interface_Classes;

namespace Ingogo.Service.Batch_Management.Implementation_Classes
{
    public class BatchRepository:IBatchRepository, IDisposable
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Batch> _batchRepository;

        public BatchRepository()
        {
            _datacontext = new ApplicationDbContext();
            _batchRepository = new RepositoryService<Batch>(_datacontext);

        }


        public Batch GetById(int id)
        {
            return _batchRepository.GetById(id);
        }

        public List<Batch> GetAll()
        {
            return _batchRepository.GetAll().ToList();
        }

        public void Insert(Batch model)
        {
            _batchRepository.Insert(model);
        }



        public void Update(Batch model)
        {
            _batchRepository.Update(model);
        }

        public void Delete(Batch model)
        {
            _batchRepository.Delete(model);
        }
        public IEnumerable<Batch> Find(Func<Batch, bool> predicate)
        {
            return Find(predicate).ToList();
        }

       

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
