using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.MVC.Controllers
{
    public class TreatmentPercentageController : Controller
    {
        private readonly TreatmentPercentageBl _treatmentPercentage = new TreatmentPercentageBl();
        // GET: FeedingPercentage
        public ActionResult GetAllTreatmentPercentage()
        {
            return View(_treatmentPercentage.GetPercentage());
        }

        [HttpGet]
        public ActionResult AddTreatmentPercentage()
        {
            return View();
        }

        [HttpPost, ActionName("AddTreatmentPercentage")]
        [ValidateAntiForgeryToken]
        public ActionResult AddTreatmentPercentage(TreatmentPercentageModelView model)
        {
            if (ModelState.IsValid)
            {
                _treatmentPercentage.AddPercentage(model);
                return RedirectToAction("GetAllTreatmentPercentage");
            }
            return View(model);
        }
    }
}