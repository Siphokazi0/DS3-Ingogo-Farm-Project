using System;
using System.Collections.Generic;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IAnimalRepository: IDisposable
    {
        Animal GetById(int id);
        List<Animal> GetAll();
        void Insert(Animal model);
        void Update(Animal model);
        void Delete(Animal model);
        IEnumerable<Animal> Find(Func<Animal, bool> predicate);  
    }
}
