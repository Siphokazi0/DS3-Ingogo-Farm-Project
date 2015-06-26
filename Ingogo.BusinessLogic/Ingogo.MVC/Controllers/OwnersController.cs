using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace Ingogo.MVC.Controllers
{
    public class OwnersController : Controller
    {
        private ApplicationUserManager _userManager;

        public OwnersController()
        {
        }

        public OwnersController(ApplicationUserManager userManager)
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
        //readonly OwnerBl _ownerBl = new OwnerBl();

        //// GET: Owners
        //public ActionResult GetOwner()
        //{
        //    return View(_ownerBl.GetAllOwner());
        //}

        //[HttpGet]
        //public ActionResult AddOwner()
        //{
        //    return View();
        //}

        //[HttpPost, ActionName("AddOwner")]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddOwner(OwnerViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _ownerBl.AddOwner(model);
        //        return RedirectToAction("Login","Account");
        //    }
        //    return View(model);
        //}

        //[HttpGet]
        //public ActionResult UpdateOwner()
        //{
        //    return View(_ownerBl.GetOwnerById(_ownerBl.GetId(User.Identity.GetUserId())));
        //}

        //[HttpPost, ActionName("UpdateOwner")]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpdateOwner(OwnerViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _ownerBl.UpdateOwner(model,User.Identity.GetUserId());
        //        return RedirectToAction("Login", "Account");
        //    }
        //    return View(model);
        //}
    }
}