using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.BusinessLogic.Animal_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;

namespace Ingogo.MVC.Controllers
{
    public class FeedingSchemeController : Controller
    {
        readonly BatchTypeBl _bTypeBl = new BatchTypeBl();
        readonly FeedingSchemeBl _fSchemeBl = new FeedingSchemeBl();

        // GET: FeedingScheme
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllSchemes()
        {
            var fSchemeBl = new FeedingSchemeBl();
            return View(fSchemeBl.GetAllFeedSchemeViews()); 
        }

        public ActionResult AddFeedingScheme()
        {
            ViewBag.BatchTypeid = new SelectList(_bTypeBl.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            return View();
        }

        [HttpPost, ActionName("AddFeedingScheme")]
        [ValidateAntiForgeryToken]
        public ActionResult AddFeedingScheme(FeedingSchemeView model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.BatchTypeid = new SelectList(_bTypeBl.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
                _fSchemeBl.AddFeedScheme(model);
                return RedirectToAction("GetAllSchemes");
            }
            
            return View();
        }
    }
}