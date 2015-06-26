using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes
{
    public interface ITreatmentRatioTotalBl
    {

        List<TreatmentRatioTotalViewPar> GetAll();
        void Add(TreatmentRatioTotalView model);
        void Delete(int id);
        TreatmentRatioTotalViewPar GetById(int id);
        void Update(TreatmentRatioTotalView model);

    }
}
