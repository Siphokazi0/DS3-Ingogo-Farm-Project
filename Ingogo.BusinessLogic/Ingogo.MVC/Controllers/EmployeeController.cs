using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Employee_Management.Implementation_Classes;
using Ingogo.Model.Employee_Management.Model_View;
using Microsoft.AspNet.Identity.Owin;

namespace Ingogo.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationUserManager _userManager;

        Email _emails = new Email();

        public EmployeeController()
        {
        }

        public EmployeeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        readonly EmployeeBl _employee = new EmployeeBl();

        #region owner can do this
        [Authorize(Roles = "Owner")]
        public ActionResult OwnerGetAllEmployees()
        {
            return View(_employee.GetAllEmployees());
        }

        [HttpGet]
        public ActionResult OwnerRegister()
        {
            return View();
        }

        [HttpPost, ActionName("OwnerRegister")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult> OwnerRegister(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string message = _employee.AddEmployees(model);


                int index = message.IndexOf('~') + 1;
                var user = message.Substring(index, 36).Trim();
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(user);

                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user, code }, Request.Url.Scheme);

                var boddy = new StringBuilder();
                var boddyConf = new StringBuilder();

                boddy.Append(message.Substring(index + 36).Trim());
                string confirmMessage = "Hi! " + model.Email + "<br/>"
                      + "Click the link to confirm your account " +
                      callbackUrl;
                boddyConf.Append(confirmMessage);

                string bodyForConf = boddyConf.ToString();

                string bodyFor = boddy.ToString();
                string subjectFor = "Registration";
                string subjectForConf = "Confirm Email";

                string toFor = message.Substring(0, index - 1).Trim();
                var mail = new MailAddress("21217040@dut4life.ac.za", "SPBFI-Administrators");
                WebMail.SmtpServer = "pod51014.outlook.com";
                WebMail.SmtpPort = 587;
                WebMail.UserName = "21217040@dut4life.ac.za";
                WebMail.Password = "Dut921208";
                WebMail.From = mail.ToString();
                WebMail.EnableSsl = true;

                try { WebMail.Send(toFor, subjectFor, bodyFor); }
                catch
                {
                    // ignored
                }
                try { WebMail.Send(toFor, subjectForConf, bodyForConf); }
                catch
                {
                    //null
                }
                return RedirectToAction("OwnerGetAllEmployees");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Owner")]
        public ActionResult OwnerEmployeeDetails(int id)
        {
            RegisterViewModel emp = _employee.GetEmployeeById(id);
            return View(emp);
        }

        #endregion

        #region All Employees
        //Get all employees
        //[Authorize(Roles = "Admin Clerk")]
        public ActionResult GetAllEmployees()
        {
            return View(_employee.GetAllEmployees());
        }
        #endregion

        #region Add Employees
        //Add Employee
         //[Authorize(Roles = "Admin Clerk")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Admin Clerk")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string message = _employee.AddEmployees(model);

               
                int index = message.IndexOf('~')+1;
                var user = message.Substring(index,36).Trim();
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(user);

                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user, code }, Request.Url.Scheme);

                var boddy = new StringBuilder();
                var boddyConf = new StringBuilder();

                boddy.Append(message.Substring(index + 36).Trim());
                string confirmMessage = "Hi! " + model.Email + "<br/>"
                      + "Click the link to confirm your account " +
                      callbackUrl;
                boddyConf.Append(confirmMessage);

                string bodyForConf = boddyConf.ToString();

                string bodyFor = boddy.ToString();
                string subjectFor = "Registration";
                string subjectForConf = "Confirm Email";

                string toFor = message.Substring(0, index-1).Trim();
                var mail = new MailAddress("21217040@dut4life.ac.za", "SPBFI-Administrators");
                WebMail.SmtpServer = "pod51014.outlook.com";
                WebMail.SmtpPort = 587;
                WebMail.UserName = "21217040@dut4life.ac.za";
                WebMail.Password = "Dut921208";
                WebMail.From = mail.ToString();
                WebMail.EnableSsl = true;

                //try { WebMail.Send(toFor, subjectFor, bodyFor); }
                //catch
                //{
                //    // ignored
                //}
                //try { WebMail.Send(toFor, subjectForConf, bodyForConf); }
                //catch
                //{
                //    //null
                //}
                return RedirectToAction("GetAllEmployees");
            }
            return View(model);
        }
        #endregion

        #region Employee details
        [HttpGet]
        [Authorize(Roles = "Admin Clerk")]
        public ActionResult EmployeeDetails(int id)
        {
            RegisterViewModel emp = _employee.GetEmployeeById(id);
            return View(emp);
        }
        #endregion

        #region update
        [HttpGet]
        [Authorize(Roles = "Admin Clerk")]
        public ActionResult EditEmployee(int id)
        {
            return View(_employee.GetEmployeeById(id));
        }
        [HttpPost, ActionName("EditEmployee")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin Clerk")]
        public ActionResult Edit(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _employee.UpdateEmployee(model);
                return RedirectToAction("GetAllEmployees");
            }
            return View(model);
        }
        #endregion

        #region delete employee
        [Authorize(Roles = "Admin Clerk")]
        public ActionResult DeleteEmployee(int id)
        {
            return View(_employee.GetEmployeeById(id));
        }

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin Clerk")]
        public ActionResult Delete(int id)
        {
            _employee.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees");

        }
        #endregion

        //public PartialViewResult GetNameForEmployee()
        //{
        //    return PartialView(_employee.GetEmployeeNames(""));
        //}
    }
}