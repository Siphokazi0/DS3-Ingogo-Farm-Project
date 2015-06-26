using System;
using System.Collections.Generic;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Service.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentRepository : IDisposable
    {

        Treatment GetById(int id);
        List<Treatment> GetAll();
        void Insert(Treatment model);
        void Update(Treatment model);
        void Delete(Treatment model);
        IEnumerable<Treatment> Find(Func<Treatment, bool> predicate); 


    }
}
