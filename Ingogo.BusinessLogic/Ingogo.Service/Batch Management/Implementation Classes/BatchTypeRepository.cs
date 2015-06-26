using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Service.Batch_Management.Interface_Classes;

namespace Ingogo.Service.Batch_Management.Implementation_Classes
{
    public class BatchTypeRepository:IBatchTypeRepository, IDisposable
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<BatchType> _batchTypeRepository;

        public BatchTypeRepository()
        {
            _datacontext = new ApplicationDbContext();
            _batchTypeRepository = new RepositoryService<BatchType>(_datacontext);

        }

        public BatchType GetById(int id)
        {
            return _batchTypeRepository.GetById(id);
        }

        public List<BatchType> GetAll()
        {
            return _batchTypeRepository.GetAll().ToList();
        }

        public void Insert(BatchType model)
        {
            _batchTypeRepository.Insert(model);
        }

        public void Update(BatchType model)
        {
            _batchTypeRepository.Update(model);
        }

        public void Delete(BatchType model)
        {
            _batchTypeRepository.Delete(model);
        }

        public IEnumerable<BatchType> Find(Func<BatchType, bool> predicate)
        {
            return _batchTypeRepository.Find(predicate).ToList();
        }

     
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
