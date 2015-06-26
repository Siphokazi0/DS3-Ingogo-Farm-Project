using System;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Model.Batch_Management.Model_View;
using Microsoft.AspNet.Identity;

namespace Ingogo.MVC.Controllers
{
    
    //[Authorize(Roles = "Farm Manager")]
    public class BatchController : Controller
    {
        private readonly BatchBl _db = new BatchBl();
        private readonly BatchTypeBl _db2 = new BatchTypeBl();

        public ActionResult Index(string searchstring)
        {
            var batches = _db.GetAllBatches();

            if (!String.IsNullOrEmpty(searchstring))
            {
                batches =_db.SearchByDescOfbatch(searchstring);
            }

            foreach (var c in batches)
            {
                var batchtype = _db2.GetBatchTypeById(c.BatchTypeid);
                c.BatchTypeViews = new BatchType
                {
                    BatchTypeid = batchtype.BatchTypeid,
                    BatchTypeDesc = batchtype.BatchTypeDesc
                };
            }
            return View(batches);
        }

        public ActionResult GetAllBatches()
        {
            var batches = _db.GetAllBatches();
            foreach (var c in batches)
            {
                var batchtype = _db2.GetBatchTypeById(c.BatchTypeid);
           
                c.BatchTypeViews = new BatchType
                {
                    BatchTypeid = batchtype.BatchTypeid,
                    BatchTypeDesc = batchtype.BatchTypeDesc
                };

            }
            return View(batches);
           
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            ViewData["BatchType"] = _db.PopulateDropDownList();
            return View(new BatchView());
        }

        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BatchView batchView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["BatchType"] = _db.PopulateDropDownList();
                    return View(batchView);
                }
                _db.Insert(batchView,User.Identity.GetUserId());
                return RedirectToAction("InsertAnimals", "Animal");
            }
            catch
            {
                ViewData["BatchType"] = _db.PopulateDropDownList(batchView.BatchTypeid);
                return View(batchView);
            }
        }
        public ActionResult Details(int id)
        {
            var batchtypelog = new BatchBl();
            return View(batchtypelog.GetBatchById(id));
        }
        [HttpGet]
        public ActionResult EditBatch(int id)
        {
            ViewData["BatchType"] =_db.PopulateDropDownList();
            return View(_db.GetBatchById(id));
        }
        [HttpPost, ActionName("EditBatch")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBatch(BatchView model)
        {
            if (ModelState.IsValid)
            {
                ViewData["BatchType"] = _db.PopulateDropDownList();
                _db.Update(model,User.Identity.GetUserId());
                return RedirectToAction("GetAllBatches");
            }
            return View(model);
        }

    }
}