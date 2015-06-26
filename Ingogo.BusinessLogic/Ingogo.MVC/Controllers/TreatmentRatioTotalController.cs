using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.MVC.Controllers
{
    public class TreatmentRatioTotalController : Controller
    {
        readonly TreatmentBl _treatmentBl = new TreatmentBl();
        readonly TreatmentRatioTotalBl _treatmentRatioBl = new TreatmentRatioTotalBl();
        // GET: TreatmentRatioTotal
        public ActionResult GetAllRatioTotal()
        {
            return View(_treatmentRatioBl.GetAll());
        }


        public ActionResult AddRatioTotal()
        {
            ViewBag.Tid = new SelectList(_treatmentBl.GetAllT(), "Tid", "Tname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRatioTotal(TreatmentRatioTotalView model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Tid = new SelectList(_treatmentBl.GetAllT(), "Tid", "Tname");
                _treatmentRatioBl.Add(model);
                return RedirectToAction("GetAllRatioTotal");
            }
            return View(model);
        }

    }
}