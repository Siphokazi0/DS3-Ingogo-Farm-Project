using System.Web.Mvc;
using Ingogo.BusinessLogic.Supplier_Management.Implementation_Classes;
using Ingogo.Model.Supplier_Management.Model_View;
using Microsoft.AspNet.Identity;

namespace Ingogo.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SuppliersBl _suppliers = new SuppliersBl();

        #region supervisor
        [HttpGet]
        //supervisor gets all suppliers
        public ActionResult GetAllSupplier()
        {
            return View(_suppliers.GetAllSuppliers());
        }

        [HttpGet]
        //supervisor add supplier
        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost, ActionName("AddSupplier")]
        [ValidateAntiForgeryToken]
        public ActionResult AddSupplier(SuppliersView model)
        {
            if (ModelState.IsValid)
            {
                _suppliers.AddNewSupplier(model,User.Identity.GetUserId());
                return RedirectToAction("GetAllSupplier");
            }
            return View();
        }
        #endregion

        #region both users
        public ActionResult GetAllSupplierApproved()
        {
            return View(_suppliers.GetAllSuppliersApproved());
        }

        public ActionResult GetAllSupplierDisApproved()
        {
            return View(_suppliers.GetAllSuppliersDisApproved());
        }
        #endregion

        #region owner

        public ActionResult GetAllSupplierManage()
        {
            return View(_suppliers.GetAllSuppliersManagement());
        }

        [HttpGet]
        public ActionResult A_DSupplier(int id)
        {
            return View(_suppliers.GetSupplierById(id));
        }

        [HttpPost, ActionName("A_DSupplier")]
        [ValidateAntiForgeryToken]
        public ActionResult A_DSupplier(SuppliersView model)
        {
            if (ModelState.IsValid)
            {
                _suppliers.Approve(model);
                return RedirectToAction("GetAllSupplierManage");
            }
            return View();
        }
        #endregion
    }
}