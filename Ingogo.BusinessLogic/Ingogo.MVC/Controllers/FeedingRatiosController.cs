using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Animal_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Purchase_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Purchase_Management.Interface_Classes;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.MVC.Controllers
{
    public class FeedingRatiosController : Controller
    {
        private readonly FeedingIngredientBl _ingredient = new FeedingIngredientBl();
        private readonly FeedingRatioBl _ratio = new FeedingRatioBl();
        private readonly FeedingStockBussiness _stock = new FeedingStockBussiness();
        private readonly FeedingPercentageBl _percentage = new FeedingPercentageBl();
        private readonly FeedingPercentageBl _feedingPercentage = new FeedingPercentageBl();

        public FeedingRatiosController() { }

        public FeedingRatiosController(FeedingRatioBl ratio)
        {
            _ratio = ratio;
        }
        public ActionResult CreateFeedRatio()
        {
            return View();
        }
        #region Ratio
        public ActionResult GetAllFeedRatio()
        {
            return View(_ratio.GetAllFeedRatio());
        }

        [HttpGet]
        public ActionResult AddFeedRatio()
        {
            return View();
        }
        [HttpPost, ActionName("AddFeedRatio")]
        [ValidateAntiForgeryToken]
        public ActionResult AddFeedRatio(FeedingRatioView model)
        {
            if (ModelState.IsValid)
            {
                _ratio.AddFeedRatio(model);
                return RedirectToAction("GetAllFeedRatio");
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateFeedRatio()
        {
            return View();
        }
        [HttpPost, ActionName("UpdateFeedRatio")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFeedRatio(FeedingRatioView model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteFeedRatio()
        {
            return View();
        }
        [HttpPost, ActionName("DeleteFeedRatio")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFeedRatio(FeedingRatioView model)
        {
            return View();
        }
        #endregion

        #region ingredients
        public ActionResult GetAllFeedIngredient()
        {
            return View(_ingredient.GetAllFeedIngr());
        }
        public ActionResult GetAllFeedIngredientList()
        {
            return View(_ingredient.GetAllFeedIngr());
        }
        [HttpGet]
        public ActionResult AddFeedIngredient()
        {
            ViewBag.FeedingStockId = new SelectList(_stock.GetAllFeedingStock(), "FeedingStockId", "ItemName");
            ViewBag.FeedingPercentageId = new SelectList(_percentage.GetPercentage(), "FeedingPercentageId", "Percentage");
            return View();
        }
        [HttpPost, ActionName("AddFeedIngredient")]
        [ValidateAntiForgeryToken]
        public ActionResult AddFeedIngredient(FeedingIngredientsView model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FeedingStockId = new SelectList(_stock.GetAllFeedingStock(), "FeedingStockId", "FeedingStockId");
                ViewBag.FeedingPercentageId = new SelectList(_percentage.GetPercentage(), "FeedingPercentageId",
                    "FeedingPercentageId");
                _ingredient.AddFeedIngr(model);
                return RedirectToAction("CreateFeedRatio");
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateFeedIngredient()
        {
            return View();
        }
        [HttpPost, ActionName("UpdateFeedIngredient")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFeedIngredient(FeedingIngredientsView model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteFeedIngredient(int id)
        {
            return View(_ingredient.GetFeedIngrById(id));
        }
        [HttpPost, ActionName("DeleteFeedIngredient")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFeed(int id)
        {
            _ingredient.DeleteFeedIngr(id);
            return RedirectToAction("CreateFeedRatio");
        }
        #endregion

        #region percentage

        // GET: FeedingPercentage
        public ActionResult GetAllFeedPercentage()
        {
            return View(_feedingPercentage.GetPercentage());
        }

        [HttpGet]
        public ActionResult AddFeedPercentage()
        {
            return View();
        }

        [HttpPost, ActionName("AddFeedPercentage")]
        [ValidateAntiForgeryToken]
        public ActionResult AddFeedPercentage(FeedingPercentageView model)
        {
            if (ModelState.IsValid)
            {
                _feedingPercentage.AddPercentage(model);
                return RedirectToAction("CreateFeedRatio");
            }
            return View(model);
        }
        #endregion
    }
}