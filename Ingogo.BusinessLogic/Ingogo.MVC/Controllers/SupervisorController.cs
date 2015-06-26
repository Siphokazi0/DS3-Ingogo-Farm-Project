using System.Web.Mvc;

namespace Ingogo.MVC.Controllers
{
    public class SupervisorController : Controller
    {
        [Authorize(Roles = "Supervisor")]
        public ActionResult SupervisorHome()
        {
            return View();
        }
    }
}