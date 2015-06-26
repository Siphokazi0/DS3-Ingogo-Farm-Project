using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Batch_Management.Interface_Classes;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Data.Context;
using Ingogo.Model.Batch_Management.Model_View;
using Ingogo.Service.Batch_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Batch_Management.Implementation_Classes
{
    public class BatchBl : IBatchBl
    {
        private static readonly ApplicationDbContext _db = new ApplicationDbContext();
        private static readonly BatchTypeBl _TypeBl = new BatchTypeBl();
        public List<BatchView> GetAllBatches()
        {
            using (var rep = new BatchRepository())
            {
                var bat = new List<BatchView>();
                foreach (var x in rep.GetAll())
                {
                    bat.Add(new BatchView
                    {
                        Batchid = x.Batchid,
                        Agerange = x.Agerange,
                        UserId = x.UserId,
                        Name=x.Name,
                        BatchTypeid = x.BatchTypeid,
                        NumOfAnimals = x.NumOfAnimals,
                        BatchCode = x.BatchCode,
                        Wiegth = x.Wiegth,
                        Totalcost = x.Totalcost

                    }
                        );

                }
                return bat;
            }

        }

        public void Insert(BatchView batchView, String userId)
        {
            using (var rep = new BatchRepository())
            {
                rep.Insert(ConvertBatch(batchView, userId));
            }
        }

        public void Delete(BatchView batchView)
        {
            using (var rep = new BatchRepository())
            {
                //rep.Delete(ConvertBatch(batchView));
            }
        }

        public void Update(BatchView batchView, string userId)
        {
            using (var rep = new BatchRepository())
            {
                var user = _db.Users.ToList().Find(x => x.Id == userId);
                Batch batch =rep.GetById(batchView.BatchTypeid);
                if (batch != null)
                {
                    //batch.Batchid = batchView.Batchid;
                    batch.BatchTypeid = batchView.BatchTypeid;

                    batch.UserId = batchView.UserId;
                   // batch.Name = user.UserProfile.FirstName;
                    batch.BatchCode =
                        _TypeBl.GetBatchTypeById(batchView.BatchTypeid).BatchTypeDesc.Substring(0, 2) +
                        DateTime.Now;
                    batch.Agerange = batchView.Agerange;
                    batch.NumOfAnimals = batchView.NumOfAnimals;
                    batch.Wiegth = batchView.Wiegth;
                    batch.Totalcost = batchView.Totalcost;
                }
               // rep.Update(batch);
                rep.Update(ConvertBatch(batchView, userId));
            }
        }

        public BatchView GetBatchById(int id)
        {
            using (var rep = new BatchRepository())
            {
               // var user = _db.Users.ToList().Find(x => x.Id == userid);
                return rep.GetAll().Select(x => new BatchView
                {
                    Batchid = x.Batchid,
                    Agerange = x.Agerange,
                    UserId = x.UserId,
                    Name = x.Name,
                    BatchCode = x.BatchCode,
                    BatchTypeid = x.BatchTypeid,
                    BatchTypeViews = x.BatchTypeViews,
                    NumOfAnimals = x.NumOfAnimals,
                    Totalcost = x.Totalcost,
                    Wiegth = x.Wiegth
                }).First(b => b.Batchid == id);

            }
        }
        public List<BatchView> SearchByDescOfbatch(string searchstring)
        {
            
            var batchType = new BatchTypeBl();
            return (from b in GetAllBatches()
                    let cat = batchType.GetBatchTypeById(b.BatchTypeid)
                    where cat.BatchTypeDesc.ToLower().Contains(searchstring.ToLower())
                    || b.BatchCode.ToLower().Contains(searchstring.ToLower())

                    select b).ToList();
        }
        public IEnumerable<SelectListItem> PopulateDropDownList(object selectedCategory = null)
        {
            var db2 = new BatchTypeBl();
            var batchtypes = db2.GetAllBatchTypes().Select(b => new SelectListItem
            {
                Value = b.BatchTypeid.ToString(CultureInfo.InvariantCulture),
                Text = b.BatchTypeDesc
            });
            return batchtypes;
        }
        private static Batch ConvertBatch(BatchView batchView, String userId)
        {

            var bty = new BatchTypeBl();
            var user = _db.Users.ToList().Find(x => x.Id == userId);

            var batch = new Batch
            {
                Batchid = batchView.Batchid,
                BatchTypeid = batchView.BatchTypeid,
                UserId = batchView.UserId,
                Name = user.UserProfile.FirstName,
                BatchCode = bty.GetBatchTypeById(batchView.BatchTypeid).BatchTypeDesc.Substring(0, 2) + DateTime.Now,
                Agerange = batchView.Agerange,
                NumOfAnimals = batchView.NumOfAnimals,
                Wiegth = batchView.Wiegth,
                Totalcost = batchView.Totalcost



            };
            return batch;

        }

        public void Dispose(bool disposing)
        {
            using (var rep = new BatchRepository())
            {
                rep.Dispose();
            }
        }
    }
}
