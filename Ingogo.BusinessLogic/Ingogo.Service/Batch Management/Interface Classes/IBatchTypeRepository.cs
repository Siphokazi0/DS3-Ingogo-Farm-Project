using System;
using System.Collections.Generic;
using Ingogo.Data.Batch_Management.Models;

namespace Ingogo.Service.Batch_Management.Interface_Classes
{
    public interface IBatchTypeRepository
    {

        BatchType GetById(Int32 id);
        List<BatchType> GetAll();
        void Insert(BatchType model);
        void Update(BatchType model);
        void Delete(BatchType model);
        IEnumerable<BatchType> Find(Func<BatchType, bool> predicate);  
    }
}
