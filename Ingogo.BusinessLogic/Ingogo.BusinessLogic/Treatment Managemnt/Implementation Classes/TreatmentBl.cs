using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes;
using Ingogo.Data.Treatment_Managemnt.Models;
using Ingogo.Model.Treatment_Managemnt.Model_View;
using Ingogo.Service.Treatment_Managemnt.Implementation_Classes;

namespace Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes
{
    public class TreatmentBl : ITreatmentBl
    {

        public List<TreatmentModelView> GetAllT()
        {
            using (var treatment = new TreatmentRepository())
            {
                return treatment.GetAll().Select(x => new TreatmentModelView
                {
                    Tid = x.Tid,
                    Tname = x.Tname,
                }).ToList();
            }

        }


        public void AddT(TreatmentModelView model)
        {
            using (var treatment = new TreatmentRepository())
            {
                var treat = new Treatment
                {
                    Tid = model.Tid,
                    Tname = model.Tname,
                };
                treatment.Insert(treat);
            }
        }


        public void DeleteT(int id)
        {
            using (var treatment = new TreatmentRepository())
            {
                Treatment treat = treatment.GetById(id);
                if (treat != null)
                {
                    treatment.Delete(treat);
                }
            }
        }



        public TreatmentModelView GetTById(int id)
        {
            using (var treatment = new TreatmentRepository())
            {
               Treatment treat = treatment.GetById(id);
               var treatView = new TreatmentModelView();
                if (treat != null)
                {
                    treatView.Tid = treat.Tid;
                    treatView.Tname = treat.Tname; 
                }
                return treatView;
            }
        }



        public void UpdateT(TreatmentModelView model)
        {
            using (var treatment = new TreatmentRepository())
            {
                Treatment treat = treatment.GetById(model.Tid);
                if (treat != null)
                {
                    treat.Tid = model.Tid;
                    treat.Tname = model.Tname;

                    treatment.Update(treat);
                }
            }
        }


    }
}
