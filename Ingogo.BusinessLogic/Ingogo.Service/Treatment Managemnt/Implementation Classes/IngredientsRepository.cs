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
    public class IngredientsRepository : ITreatmentIngredients
    {

       private ApplicationDbContext _datacontext;
        private readonly IRepository<TreatmentIngredients> _ingredientRepository;

        public IngredientsRepository()
        {
            _datacontext = new ApplicationDbContext();
            _ingredientRepository = new RepositoryService<TreatmentIngredients>(_datacontext);
            
        }

        public TreatmentIngredients GetById(int id)
        {
            return _ingredientRepository.GetById(id);
        }

        public List<TreatmentIngredients> GetAll()
        {
            return _ingredientRepository.GetAll().ToList();
        }

        public void Insert(TreatmentIngredients model)
        {
            _ingredientRepository.Insert(model);
        }

        public void Update(TreatmentIngredients model)
        {
            _ingredientRepository.Update(model);
        }

        public void Delete(TreatmentIngredients model)
        {
            _ingredientRepository.Delete(model);
        }

        public IEnumerable<TreatmentIngredients> Find(Func<TreatmentIngredients, bool> predicate)
        {
           return _ingredientRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

    }
}
