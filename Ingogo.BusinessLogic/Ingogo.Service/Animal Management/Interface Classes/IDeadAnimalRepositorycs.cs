using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;


namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IDeadAnimalRepositorycs:IDisposable
    {
        DeadAnimal GetById(int id);
        List<DeadAnimal> GetAll();
        void Insert(DeadAnimal model);
        void Update(DeadAnimal model);
        void Delete(DeadAnimal model);
        IEnumerable<DeadAnimal> Find(Func<DeadAnimal, bool> predicate);
  
    }
}
