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
    public class TreatmentRatioTotalRepository : ITreatmentRatioTotalRepository
    {

         private ApplicationDbContext _datacontext;
        private readonly IRepository<TreatmentRatioTotal> _treatmentratioRepository;

        public TreatmentRatioTotalRepository()
        {
            _datacontext = new ApplicationDbContext();
            _treatmentratioRepository = new RepositoryService<TreatmentRatioTotal>(_datacontext);
            
        }

        public TreatmentRatioTotal GetById(int id)
        {
            return _treatmentratioRepository.GetById(id);
        }

        public List<TreatmentRatioTotal> GetAll()
        {
            return _treatmentratioRepository.GetAll().ToList();
        }

        public void Insert(TreatmentRatioTotal model)
        {
            _treatmentratioRepository.Insert(model);
        }

        public void Update(TreatmentRatioTotal model)
        {
            _treatmentratioRepository.Update(model);
        }

        public void Delete(TreatmentRatioTotal model)
        {
            _treatmentratioRepository.Delete(model);
        }

        public IEnumerable<TreatmentRatioTotal> Find(Func<TreatmentRatioTotal, bool> predicate)
        {
           return _treatmentratioRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }


    }
}
