using System.Linq;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Purchase_Management.Implementation_Classes;
using Ingogo.Model.Purchase_Management.Model_View;

namespace Ingogo.MVC.Controllers
{
    //[Authorize(Roles = "Admin Clerk")]
    public class FeedingStockController : Controller
    {
        readonly FeedingStockBussiness _feed = new FeedingStockBussiness();

        public ActionResult Search(string searchby,string search)
        {
            if (search == "ItemName")
            {
                return View(_feed.GetAllFeedingStock().Where(x => x.ItemName == searchby).ToList());
            }
            return View(_feed.GetAllFeedingStock().Where(x => x.ItemName == search || search == null).ToList());
        }


        public ActionResult GetAllFeedingStock()
        {
            return View(_feed.GetAllFeedingStock());
        }
   
        public ActionResult AddFeedingStock()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFeedingStock(FeedingStockView model)
        {
            if (ModelState.IsValid)
            {
                _feed.AddFeedingStock(model);
                return RedirectToAction("GetAllFeedingStock");
            }
            return View(model);
        }

        public ActionResult DeleteFeedingStock(int id)
        {
            return View(_feed.GetFeedingStockById(id));
        }

        [HttpPost,ActionName("DeleteFeedingStock")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _feed.DeleteFeedingStock(id);
            return RedirectToAction("GetAllFeedingStock");
        }

        [HttpGet]
        public ActionResult UpdateFeedingStock(int id)
        {
            return View(_feed.GetFeedingStockById(id));
        }

        [HttpPost, ActionName("UpdateFeedingStock")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(FeedingStockView model)
        {
            if (ModelState.IsValid)
            {
                _feed.UpdateFeedingStock(model);
                return RedirectToAction("GetAllFeedingStock");
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            FeedingStockView feedView = _feed.GetFeedingStockById(id);
            return View(feedView);
        }
    }
}