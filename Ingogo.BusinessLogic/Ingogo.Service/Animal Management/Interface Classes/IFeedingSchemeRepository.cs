using System;
using System.Collections.Generic;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Service.Animal_Management.Interface_Classes
{
    public interface IFeedingSchemeRepository: IDisposable
    {
        List<FeedingScheme> GetAll();
        FeedingScheme GetById(int id);
        void Insert(FeedingScheme model);
        void Update(FeedingScheme model);
        void Delete(FeedingScheme model);
        IEnumerable<FeedingScheme> Find(Func<FeedingScheme, bool> predicate); 
    }
}
