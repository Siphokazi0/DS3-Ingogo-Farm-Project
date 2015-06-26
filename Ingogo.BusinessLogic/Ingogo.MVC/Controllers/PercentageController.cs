using System.Web.Mvc;
using Ingogo.BusinessLogic.Animal_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Purchase_Management.Implementation_Classes;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.MVC.Controllers
{
    public class PercentageController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }
        // GET: Percentage
        public ActionResult GetAllPercentage()
        {
            var percBl= new PercentageBl();
            return View(percBl.GetAllIngredients());
        }

        public ActionResult AddPercentage()
        {
            FeedingStockBussiness fStock = new FeedingStockBussiness();
            ViewBag.FeedingStockId = new SelectList(fStock.GetAllFeedingStock(),"FeedingStockId","ItemName");
            FeedingSchemeBl fScheme = new FeedingSchemeBl();
            ViewBag.FeedingSchemeId = new SelectList(fScheme.GetAllFeedSchemeViews(), "FeedingSchemeId", "SchemeCode");
            return View();
        }

        [HttpPost, ActionName("AddPercentage")]
        [ValidateAntiForgeryToken]
        public ActionResult AddPercentage(PercentageView model)
        {
            if (ModelState.IsValid)
            {
                FeedingStockBussiness fStock = new FeedingStockBussiness();
                ViewBag.FeedingStockId = new SelectList(fStock.GetAllFeedingStock(), "FeedingStockId", "ItemName");
                FeedingSchemeBl fScheme = new FeedingSchemeBl();
                ViewBag.FeedingSchemeId = new SelectList(fScheme.GetAllFeedSchemeViews(), "FeedingSchemeId", "SchemeCode");
                
                PercentageBl percBl=new PercentageBl();

                if (percBl.IsAvailable(model))
                {
                    percBl.AddPercent(model);
                    return RedirectToAction("GetAllPercentage");
                }
                
                return RedirectToAction("ValidateAvailable");
            }

            return View();
        }

        public ActionResult ValidateAvailable()
        {
            TempData["message"] = "Ingredient stock selected has been depleted.";
            return View();
        }
    }
}