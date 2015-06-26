using System;
using System.Collections.Generic;
using Ingogo.Model.Batch_Management.Model_View;

namespace Ingogo.BusinessLogic.Batch_Management.Interface_Classes
{
    public interface IBatchBl
    {
        List<BatchView> GetAllBatches();
        void Insert(BatchView productView,String UserId);
        void Delete(BatchView productView);
        void Update(BatchView productView,String UserId);
        BatchView GetBatchById(int id);
        void Dispose(bool disposing);
    }
}
