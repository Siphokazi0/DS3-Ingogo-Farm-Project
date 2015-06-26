using System;
using System.Collections.Generic;
using Ingogo.Data.Purchase_Management.Models;

//21225381 SD FIKENI: Changed namespace from 'Ingogo.Service' to
//'Ingogo.BusinessLogic.Purchase_Management.Interface_Classes'

namespace Ingogo.Service.Purchase_Management.Interface_Classes
{
     public interface IFeedingStockRepository
    {
        FeedingStock GetById(Int32 id);
        List<FeedingStock> GetAll();
        void Insert(FeedingStock model);
        void Update(FeedingStock model);
        void Delete(FeedingStock model);
        IEnumerable<FeedingStock> Find(Func<FeedingStock, bool> predicate);
    }
}
