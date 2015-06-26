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
    public class TreatmentRatioTotalBl : ITreatmentRatioTotalBl
    {
        private readonly IngredientsRepository _ingredients = new IngredientsRepository();
        private readonly TreatmentPercentageRepository _percentage = new TreatmentPercentageRepository();
        private readonly TreatmentRepository _treatment = new TreatmentRepository();
        private readonly TreatmentRatioRepository _ratio = new TreatmentRatioRepository();

        public List<TreatmentRatioTotalViewPar> GetAll()
        {
            using (var ingredient = new TreatmentRatioTotalRepository())
            {
                return ingredient.GetAll().Select(x => new TreatmentRatioTotalViewPar
                {
                    TreatmentRatioTotalId = x.TreatmentRatioTotalId,
                    Price = x.Price,
                    TreatmentName = _treatment.GetAll().ToList().Find(y => y.Tid == x.Tid).Tname

                }).ToList();
            }
        }

        public void Add(TreatmentRatioTotalView model)
        {
            using (var ratio = new TreatmentRatioTotalRepository())
            {
                List<TreatmentRatio> total = _ratio.GetAll().ToList().FindAll(x=>x.Tid==model.Tid);
              
                var treat = new TreatmentRatioTotal
                {
                    TreatmentRatioTotalId = model.TreatmentRatioTotalId,
                    Price = total.Sum(x=>x.TreatPrice),
                    Tid = model.Tid

                };
                ratio.Insert(treat);
               
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TreatmentRatioTotalViewPar GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TreatmentRatioTotalView model)
        {
            throw new NotImplementedException();
        }
    }
}
