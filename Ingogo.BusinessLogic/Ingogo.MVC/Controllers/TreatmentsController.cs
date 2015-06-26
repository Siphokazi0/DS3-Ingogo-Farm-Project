using System.Web.Mvc;
using Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes;
using Ingogo.Model.Treatment_Managemnt.Model_View;

namespace Ingogo.MVC.Controllers
{
    //[Authorize(Roles = "Farm Manager")]
    public class TreatmentsController : Controller
    {
        readonly TreatmentBl _treat = new TreatmentBl();

        // GET: Treatments
        public ActionResult GetAllT()
        {
            return View(_treat.GetAllT());
        }

        public ActionResult AddT()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddT(TreatmentModelView model)
        {
            if (ModelState.IsValid)
            {
                _treat.AddT(model);
                return RedirectToAction("RatioManagement","TreatmentRatioManagement");
            }
            return View(model);
        }


        public ActionResult DeleteT(int id)
        {
            return View(_treat.GetTById(id));
        }

        [HttpPost, ActionName("DeleteT")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _treat.DeleteT(id);
            return RedirectToAction("GetAllT");

        }


        public ActionResult DetailsT(int id)
        {
            TreatmentModelView treat = _treat.GetTById(id);
            return View(treat);
        }


        [HttpGet]
        public ActionResult EditT(int id)
        {
            return View(_treat.GetTById(id));
        }
        [HttpPost, ActionName("EditT")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TreatmentModelView model)
        {
            if (ModelState.IsValid)
            {
                _treat.UpdateT(model);
                return RedirectToAction("GetAllT");
            }
            return View(model);
        }


    }
}