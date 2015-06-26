using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.MVC.Controllers
{
    public class TreatmentRatioController : Controller
    {

        readonly TreatmentIngredientsBl _ingredients = new TreatmentIngredientsBl();
        readonly TreatmentPercentageBl _percentage = new TreatmentPercentageBl();
        private readonly TreatmentRatioBl _ratio = new TreatmentRatioBl();

        // GET: TreatmentRatio
        public ActionResult GetAll()
        {
            return View(_ratio.GetAll());
        }


        public ActionResult Add()
        {
            ViewBag.IngredientId = new SelectList(_ingredients.GetAll(), "IngredientId", "IngredientName");
            ViewBag.TreatmentPercentageId = new SelectList(_percentage.GetPercentage(), "TreatmentPercentageId", "Percentage");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TreatmentRatioModelView model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IngredientId = new SelectList(_ingredients.GetAll(), "IngredientId", "IngredientName");
                ViewBag.TreatmentPercentageId = new SelectList(_percentage.GetPercentage(), "TreatmentPercentageId", "Percentage");
                _ratio.Add(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }



    }
}