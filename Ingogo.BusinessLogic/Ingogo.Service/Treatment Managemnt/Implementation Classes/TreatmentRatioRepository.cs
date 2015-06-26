using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Data.Treatment_Managemnt.Models;
using Ingogo.Service.Treatment_Managemnt.Interface_Classes;

namespace Ingogo.Service.Treatment_Managemnt.Implementation_Classes
{
    public class TreatmentRatioRepository : ITreatmentRatioRepository
    {

        private ApplicationDbContext _datacontext;
        private readonly IRepository<TreatmentRatio> _treatmentRatioRepository;

        public TreatmentRatioRepository()
        {
            _datacontext = new ApplicationDbContext();
            _treatmentRatioRepository = new RepositoryService<TreatmentRatio>(_datacontext);
            
        }

        public TreatmentRatio GetById(int id)
        {
            return _treatmentRatioRepository.GetById(id);
        }

        public List<TreatmentRatio> GetAll()
        {
            return _treatmentRatioRepository.GetAll().ToList();
        }

        public void Insert(TreatmentRatio model)
        {
            _treatmentRatioRepository.Insert(model);
        }

        public void Update(TreatmentRatio model)
        {
            _treatmentRatioRepository.Update(model);
        }

        public void Delete(TreatmentRatio model)
        {
            _treatmentRatioRepository.Delete(model);
        }

        public IEnumerable<TreatmentRatio> Find(Func<TreatmentRatio, bool> predicate)
        {
           return _treatmentRatioRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }


    }
}
