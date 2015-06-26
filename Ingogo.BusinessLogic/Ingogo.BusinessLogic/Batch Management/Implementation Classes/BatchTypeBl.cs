using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Batch_Management.Interface_Classes;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Model.Batch_Management.Model_View;
using Ingogo.Service.Batch_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Batch_Management.Implementation_Classes
{
    public class BatchTypeBl:IBatchTypeBl
    {
        public List<BatchTypeView> GetAllBatchTypes()
        {
            using (var batchtyperepo = new BatchTypeRepository())
            {
                return
                    batchtyperepo.GetAll()
                        .Select(x => new BatchTypeView { BatchTypeid = x.BatchTypeid, BatchTypeDesc = x.BatchTypeDesc})
                        .ToList();
            }
        }

        private static BatchType ConvertBatchType(BatchTypeView batchTypeView)
        {
            var batchtype = new BatchType
            {
                BatchTypeid = batchTypeView.BatchTypeid,
                BatchTypeDesc = batchTypeView.BatchTypeDesc
              
            };
            return batchtype;
        }

        public void Insert(BatchTypeView batchTypeView)
        {
            using (var rep = new BatchTypeRepository())
            {
                var batchtype = new BatchType
                {
                   
                    BatchTypeDesc = batchTypeView.BatchTypeDesc,
                    BatchTypeid = batchTypeView.BatchTypeid
                };
                rep.Insert(batchtype);
            }
        }

        public void Delete(BatchTypeView batchTypeView)
        {
            using (var rep = new BatchTypeRepository())
            {
                rep.Delete(ConvertBatchType(batchTypeView));
            }
        }

        public void Update(BatchTypeView batchTypeView)
        {
            using (var batchtyperepo = new BatchTypeRepository())
            {
                BatchType batchtype = batchtyperepo.GetById(batchTypeView.BatchTypeid);
                if (batchtype != null)
                {
                   
                    batchtype.BatchTypeid = batchTypeView.BatchTypeid;
                  
                    batchtype.BatchTypeDesc = batchTypeView.BatchTypeDesc;
                   batchtyperepo.Update(batchtype);
                }
            }
        }



        public BatchTypeView GetBatchTypeById(int id)
        {
            using (var batchtyperepo = new BatchTypeRepository())
            {
                BatchType batchtype = batchtyperepo.GetById(id);
                var batchtypeView = new BatchTypeView();
                if (batchtype != null)
                {
                    batchtypeView.BatchTypeDesc = batchtype.BatchTypeDesc;
                    
                    batchtypeView.BatchTypeid = batchtype.BatchTypeid;
                }
                return batchtypeView;
            }
        }

        public void Dispose(bool disposing)
        {
            using (var rep = new BatchTypeRepository())
            {
                rep.Dispose();
            }
        }
    }
}
