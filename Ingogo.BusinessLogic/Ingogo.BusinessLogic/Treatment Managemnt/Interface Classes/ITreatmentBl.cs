using System.Collections.Generic;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentBl
    {

        List<TreatmentModelView> GetAllT();
        void AddT(TreatmentModelView model);
        void DeleteT(int id);
        TreatmentModelView GetTById(int id);
        void UpdateT(TreatmentModelView model);

    }
}
