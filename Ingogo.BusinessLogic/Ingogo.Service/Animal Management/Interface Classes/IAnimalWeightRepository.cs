using System;
using System.Collections.Generic;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IAnimalWeightRepository : IDisposable
    {

        AnimalWeight GetById(int id);
        List<AnimalWeight> GetAll();
        void Insert(AnimalWeight model);
        void Update(AnimalWeight model);
        void Delete(AnimalWeight model);
        IEnumerable<AnimalWeight> Find(Func<AnimalWeight, bool> predicate);

    }
}
