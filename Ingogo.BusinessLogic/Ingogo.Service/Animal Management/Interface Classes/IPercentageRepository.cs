using System;
using System.Collections.Generic;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IPercentageRepository: IDisposable
    {
        List<Percentage> GetAll();
        Percentage GetById(int id);
        void Insert(Percentage model);
        void Update(Percentage model);
        void Delete(Percentage model);
        IEnumerable<Percentage> Find(Func<Percentage, bool> predicate); 
    }
}
