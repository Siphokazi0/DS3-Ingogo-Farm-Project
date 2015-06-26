using System;
using System.Collections.Generic;
using Ingogo.Data.Employee_Management.Models;

namespace Ingogo.Service.Employee_Management.Interface_Classes
{
    public interface IEmployeeRepository
    {
        Employees GetById(int id);
        List<Employees> GetAll();
        void Insert(Employees model);
        void Update(Employees model);
        void Delete(Employees model);
        IEnumerable<Employees> Find(Func<Employees, bool> predicate); 
    }
}
