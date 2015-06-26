using System.Web.Mvc;

namespace Ingogo.MVC.Controllers
{
    public class FarmAssistanceController : Controller
    {
       // [Authorize(Roles = "Farm Assistance")]
        public ActionResult FarmAssistanceHome()
        {
            return View();
        }
    }
}