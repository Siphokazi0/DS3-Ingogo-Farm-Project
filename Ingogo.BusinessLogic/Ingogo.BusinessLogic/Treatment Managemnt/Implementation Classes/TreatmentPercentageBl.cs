using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes;
using Ingogo.Data.Treatment_Managemnt.Models;
using Ingogo.Model.Treatment_Managemnt.Model_View;
using Ingogo.Service.Treatment_Managemnt.Implementation_Classes;

namespace Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes
{
    public class TreatmentPercentageBl : ITreatmentPercentageBl
    {

        public void AddPercentage(TreatmentPercentageModelView model)
        {
            using (var feedPerc = new TreatmentPercentageRepository())
            {
                var feed = new TreatmentPercentage
                {
                    TreatmentPercentageId = model.TreatmentPercentageId,
                    Percentage = model.Percentage + " %"
                };
                feedPerc.Insert(feed);
            }
        }

        public List<TreatmentPercentageModelView> GetPercentage()
        {
            using (var treatPerc = new TreatmentPercentageRepository())
            {
                return treatPerc.GetAll().Select(x => new TreatmentPercentageModelView
                {
                    TreatmentPercentageId = x.TreatmentPercentageId,
                    Percentage = x.Percentage
                }).ToList();
            }
        }

    }
}
