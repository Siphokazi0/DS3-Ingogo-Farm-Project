using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Service.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentRatioRepository : IDisposable
    {

        TreatmentRatio GetById(int id);
        List<TreatmentRatio> GetAll();
        void Insert(TreatmentRatio model);
        void Update(TreatmentRatio model);
        void Delete(TreatmentRatio model);
        IEnumerable<TreatmentRatio> Find(Func<TreatmentRatio, bool> predicate); 

    }
}
