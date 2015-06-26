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
    public class TreatmentPercentageRepository : ITreatmentPercentageRepository
    {

        private ApplicationDbContext _datacontext;
        private readonly IRepository<TreatmentPercentage> _treatmentPercentageRepository;

        public TreatmentPercentageRepository()
        {
            _datacontext = new ApplicationDbContext();
            _treatmentPercentageRepository = new RepositoryService<TreatmentPercentage>(_datacontext);
            
        }

        public TreatmentPercentage GetById(int id)
        {
            return _treatmentPercentageRepository.GetById(id);
        }

        public List<TreatmentPercentage> GetAll()
        {
            return _treatmentPercentageRepository.GetAll().ToList();
        }

        public void Insert(TreatmentPercentage model)
        {
            _treatmentPercentageRepository.Insert(model);
        }

        public void Update(TreatmentPercentage model)
        {
            _treatmentPercentageRepository.Update(model);
        }

        public void Delete(TreatmentPercentage model)
        {
            _treatmentPercentageRepository.Delete(model);
        }

        public IEnumerable<TreatmentPercentage> Find(Func<TreatmentPercentage, bool> predicate)
        {
           return _treatmentPercentageRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

    }
}
