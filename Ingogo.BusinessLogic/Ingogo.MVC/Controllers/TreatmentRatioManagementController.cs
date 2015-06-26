using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.MVC.Controllers
{
    public class TreatmentRatioManagementController : Controller
    {


        readonly TreatmentIngredientsBl _ingredients = new TreatmentIngredientsBl();
        readonly TreatmentPercentageBl _percentage = new TreatmentPercentageBl();
        private readonly TreatmentRatioBl _ratio = new TreatmentRatioBl();
        readonly TreatmentBl _treatmentBl = new TreatmentBl();
        

        #region Ratio

        // GET: TreatmentRatio
        public ActionResult GetAllRatios()
        {
            return View(_ratio.GetAll());
        }


        public ActionResult AddRatio()
        {
            ViewBag.IngredientId = new SelectList(_ingredients.GetAll(), "IngredientId", "IngredientName");
            ViewBag.TreatmentPercentageId = new SelectList(_percentage.GetPercentage(), "TreatmentPercentageId", "Percentage");
            ViewBag.Tid = new SelectList(_treatmentBl.GetAllT(), "Tid", "Tname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRatio(TreatmentRatioModelView model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IngredientId = new SelectList(_ingredients.GetAll(), "IngredientId", "IngredientName");
                ViewBag.TreatmentPercentageId = new SelectList(_percentage.GetPercentage(), "TreatmentPercentageId", "Percentage");
                ViewBag.Tid = new SelectList(_treatmentBl.GetAllT(), "Tid", "Tname");
                _ratio.Add(model);
                return RedirectToAction("RatioManagement");
            }
            return View(model);
        }

        public ActionResult DeleteRatio(int id)
        {
            return View(_ratio.GetById(id));
        }

        [HttpPost, ActionName("DeleteRatio")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteR(int id)
        {
            _ratio.Delete(id);
            return RedirectToAction("RatioManagement");

        }



        #endregion

        #region Treatment Ingredients

        public ActionResult GetAllIngredients()
        {
            return View(_ingredients.GetAll());
        }

        public ActionResult AddIngredient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddIngredient(IngredientsModelView model)
        {
            if (ModelState.IsValid)
            {
                _ingredients.Add(model);
                return RedirectToAction("GetAllIngredients");
            }
            return View(model);
        }


        public ActionResult DeleteIngredient(int id)
        {
            return View(_ingredients.GetById(id));
        }

        [HttpPost, ActionName("DeleteIngredient")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _ingredients.Delete(id);
            return RedirectToAction("GetAllIngredients");

        }


        public ActionResult IngredientDetails(int id)
        {
            IngredientsViewPar treat = _ingredients.GetById(id);
            return View(treat);
        }


        [HttpGet]
        public ActionResult EditIngredient(int id)
        {
            return View(_ingredients.GetById(id));
        }
        [HttpPost, ActionName("EditIngredient")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IngredientsViewPar model)
        {
            if (ModelState.IsValid)
            {
                _ingredients.Update(model);
                return RedirectToAction("GetAllIngredients");
            }
            return View(model);
        }


        #endregion


        #region Treatment Percentage

        public ActionResult GetAllTreatmentPercentage()
        {
            return View(_percentage.GetPercentage());
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
                _percentage.AddPercentage(model);
                return RedirectToAction("RatioManagement");
            }
            return View(model);
        }


        #endregion


        public ActionResult RatioManagement()
        {
            return View();
        }


    }
}