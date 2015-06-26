using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.Data.Context;
using Ingogo.Data.Repository;
using Ingogo.Data.Treatment_Managemnt.Models;
using Ingogo.Service.Treatment_Managemnt.Interface_Classes;

namespace Ingogo.Service.Treatment_Managemnt.Implementation_Classes
{
    public class TreatmentRepository : ITreatmentRepository
    {

        private ApplicationDbContext _datacontext;
        private readonly IRepository<Treatment> _treatmentRepository;

        public TreatmentRepository()
        {
            _datacontext = new ApplicationDbContext();
            _treatmentRepository = new RepositoryService<Treatment>(_datacontext);
            
        }

        public Treatment GetById(int id)
        {
            return _treatmentRepository.GetById(id);
        }

        public List<Treatment> GetAll()
        {
            return _treatmentRepository.GetAll().ToList();
        }

        public void Insert(Treatment model)
        {
            _treatmentRepository.Insert(model);
        }

        public void Update(Treatment model)
        {
            _treatmentRepository.Update(model);
        }

        public void Delete(Treatment model)
        {
            _treatmentRepository.Delete(model);
        }

        public IEnumerable<Treatment> Find(Func<Treatment, bool> predicate)
        {
           return _treatmentRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }



    }
}
