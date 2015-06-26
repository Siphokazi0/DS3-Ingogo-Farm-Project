using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Data.Supplier_Management.Models;
using Ingogo.Service.Supplier_Management.Interface_Classes;

namespace Ingogo.Service.Supplier_Management.Implementation_Classes
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private ApplicationDbContext _datacontext;
        private readonly IRepository<Suppliers> _suppliersRepository;

        public SuppliersRepository()
        {
            _datacontext = new ApplicationDbContext();
            _suppliersRepository = new RepositoryService<Suppliers>(_datacontext);
        }

        public Suppliers GetById(int id)
        {
            return _suppliersRepository.GetById(id);
        }

        public List<Suppliers> GetAll()
        {
            return _suppliersRepository.GetAll().ToList();
        }

        public void Insert(Suppliers model)
        {
            _suppliersRepository.Insert(model);
        }

        public void Update(Suppliers model)
        {
            _suppliersRepository.Update(model);
        }

        public void Delete(Suppliers model)
        {
            _suppliersRepository.Delete(model);
        }

        public IEnumerable<Suppliers> Find(Func<Suppliers, bool> predicate)
        {
           return _suppliersRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

    }
}
