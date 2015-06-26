using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IFeedingPercentageRepository : IDisposable
    {
        FeedingPercentage GetById(int id);
        List<FeedingPercentage> GetAll();
        void Insert(FeedingPercentage model);
        void Update(FeedingPercentage model);
        void Delete(FeedingPercentage model);
        IEnumerable<FeedingPercentage> Find(Func<FeedingPercentage, bool> predicate); 
    }
}
