using System.Web.Mvc;

namespace Ingogo.MVC.Controllers
{
    public class FarmManagerController : Controller
    {
        
      //  [Authorize(Roles = "Farm Manager")]
        public ActionResult FarmManagerHome()
        {
            return View();
        }
       
    }
}