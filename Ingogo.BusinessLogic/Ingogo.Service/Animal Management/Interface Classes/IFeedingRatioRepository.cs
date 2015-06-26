using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IFeedingRatioRepository : IDisposable
    {
        FeedingRatio GetById(int id);
        List<FeedingRatio> GetAll();
        void Insert(FeedingRatio model);
        void Update(FeedingRatio model);
        void Delete(FeedingRatio model);
        IEnumerable<FeedingRatio> Find(Func<FeedingRatio, bool> predicate); 
    }
}
