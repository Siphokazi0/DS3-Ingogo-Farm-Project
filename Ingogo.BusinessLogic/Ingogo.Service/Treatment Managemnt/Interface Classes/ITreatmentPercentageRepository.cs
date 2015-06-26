using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Service.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentPercentageRepository : IDisposable
    {

        TreatmentPercentage GetById(int id);
        List<TreatmentPercentage> GetAll();
        void Insert(TreatmentPercentage model);
        void Update(TreatmentPercentage model);
        void Delete(TreatmentPercentage model);
        IEnumerable<TreatmentPercentage> Find(Func<TreatmentPercentage, bool> predicate); 

    }
}
