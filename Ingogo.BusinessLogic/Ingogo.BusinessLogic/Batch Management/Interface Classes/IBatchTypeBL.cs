using System.Collections.Generic;
using Ingogo.Model.Batch_Management.Model_View;

namespace Ingogo.BusinessLogic.Batch_Management.Interface_Classes
{
    public interface IBatchTypeBl
    {
        List<BatchTypeView> GetAllBatchTypes();
        void Insert(BatchTypeView productView);
        void Delete(BatchTypeView productView);
        void Update(BatchTypeView productView);
        BatchTypeView GetBatchTypeById(int id);
        void Dispose(bool disposing);
    }
}
