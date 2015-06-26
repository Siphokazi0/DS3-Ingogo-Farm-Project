using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Context;
using Ingogo.Data.Employee_Management.Models;
using Ingogo.Data.Repository;
using Ingogo.Service.Employee_Management.Interface_Classes;

namespace Ingogo.Service.Employee_Management.Implementation_Classes
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private ApplicationDbContext _datacontext;
        private readonly IRepository<Employees> _employeeRepository;

        public EmployeeRepository()
        {
            _datacontext = new ApplicationDbContext();
            _employeeRepository = new RepositoryService<Employees>(_datacontext);
            
        }
        //

        public Employees GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public List<Employees> GetAll()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public void Insert(Employees model)
        {
            _employeeRepository.Insert(model);
        }

        public void Update(Employees model)
        {
            _employeeRepository.Update(model);
        }

        public void Delete(Employees model)
        {
            _employeeRepository.Delete(model);
        }

        public IEnumerable<Employees> Find(Func<Employees, bool> predicate)
        {
           return _employeeRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

        
    }
}
