using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentIngredientsBl
    {

        List<IngredientsViewPar> GetAll();
        void Add(IngredientsModelView model);
        void Delete(int id);
        IngredientsViewPar GetById(int id);
        void Update(IngredientsViewPar model);

    }
}
