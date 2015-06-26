using System;
using System.Collections.Generic;
using Ingogo.Data.Batch_Management.Models;

namespace Ingogo.Service.Batch_Management.Interface_Classes
{
    public interface IBatchRepository
    {
        Batch GetById(Int32 id);
        List<Batch> GetAll();
        void Insert(Batch model);
        void Update(Batch model);
        void Delete(Batch model);
        IEnumerable<Batch> Find(Func<Batch, bool> predicate);
    }
}
