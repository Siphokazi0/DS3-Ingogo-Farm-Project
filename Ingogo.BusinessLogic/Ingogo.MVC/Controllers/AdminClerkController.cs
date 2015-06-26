using System.Web.Mvc;
using Ingogo.BusinessLogic.Employee_Management.Implementation_Classes;

namespace Ingogo.MVC.Controllers
{
    public class AdminClerkController : Controller
    {
        readonly EmployeeBl _employees = new EmployeeBl();
        [Authorize(Roles = "Admin Clerk")]
        public ActionResult AdminClerkHome()
        {
            return View();
        }

        //public PartialViewResult GetDashboardSummary()
        //{

        //    var user = User.Identity.GetUserId();
        //    _employees.GetEmployeeById(user);
        //    var model = new DashboardView
        //    {
        //        UserName = 
        //    };
        //    return PartialView(model);
        //}
    }
}