using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Service.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentRatioTotalRepository : IDisposable
    {

        TreatmentRatioTotal GetById(int id);
        List<TreatmentRatioTotal> GetAll();
        void Insert(TreatmentRatioTotal model);
        void Update(TreatmentRatioTotal model);
        void Delete(TreatmentRatioTotal model);
        IEnumerable<TreatmentRatioTotal> Find(Func<TreatmentRatioTotal, bool> predicate); 

    }
}
