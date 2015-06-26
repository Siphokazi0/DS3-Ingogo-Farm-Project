using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.MVC.Controllers
{
    public class TreatmentIngredientsController : Controller
    {
        readonly TreatmentIngredientsBl _ingredients = new TreatmentIngredientsBl();
        readonly TreatmentBl _treatmentBl = new TreatmentBl();

        // GET: TreatmentIngredients
        public ActionResult GetAll()
        {
            return View(_ingredients.GetAll());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IngredientsModelView model)
        {
            if (ModelState.IsValid)
            {
                _ingredients.Add(model);
                return RedirectToAction("RatioManagement","TreatmentRatioManagement");
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
            return RedirectToAction("GetAll");

        }


        public ActionResult Details(int id)
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
                return RedirectToAction("GetAll");
            }
            return View(model);
        }


    }
}