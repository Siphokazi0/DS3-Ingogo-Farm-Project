using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IFeedingIngredientRepository : IDisposable
    {
        FeedingIngredients GetById(int id);
        List<FeedingIngredients> GetAll();
        void Insert(FeedingIngredients model);
        void Update(FeedingIngredients model);
        void Delete(FeedingIngredients model);
        IEnumerable<FeedingIngredients> Find(Func<FeedingIngredients, bool> predicate);
    }
}
