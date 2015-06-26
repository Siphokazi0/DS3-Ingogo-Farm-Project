using System.Web.Mvc;

namespace Ingogo.MVC.Controllers
{
    public class OwnerController : Controller
    {
        [Authorize(Roles = "Owner")]
        public ActionResult OwnerHome()
        {
            return View();
        }
    }
}