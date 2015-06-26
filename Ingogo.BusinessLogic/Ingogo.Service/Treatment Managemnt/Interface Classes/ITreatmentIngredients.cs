using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Service.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentIngredients : IDisposable
    {

        TreatmentIngredients GetById(int id);
        List<TreatmentIngredients> GetAll();
        void Insert(TreatmentIngredients model);
        void Update(TreatmentIngredients model);
        void Delete(TreatmentIngredients model);
        IEnumerable<TreatmentIngredients> Find(Func<TreatmentIngredients, bool> predicate);

    }
}
