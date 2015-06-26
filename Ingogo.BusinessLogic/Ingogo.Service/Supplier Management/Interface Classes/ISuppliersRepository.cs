using System;
using System.Collections.Generic;
using Ingogo.Data.Supplier_Management.Models;

namespace Ingogo.Service.Supplier_Management.Interface_Classes
{
    public interface ISuppliersRepository : IDisposable
    {
        Suppliers GetById(int id);
        List<Suppliers> GetAll();
        void Insert(Suppliers model);
        void Update(Suppliers model);
        void Delete(Suppliers model);
        IEnumerable<Suppliers> Find(Func<Suppliers, bool> predicate);  
    }
}
