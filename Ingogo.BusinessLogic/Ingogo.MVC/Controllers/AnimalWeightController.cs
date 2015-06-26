using System.Web.Mvc;
using Ingogo.BusinessLogic.Animal_Management.Implementation_Classes;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.MVC.Controllers
{
  // [Authorize(Roles = "Farm Assistance")]
    public class AnimalWeightController : Controller
    {

        readonly AnimalWeightBl _weight = new AnimalWeightBl();  
        readonly AnimalBusiness _animalBl = new AnimalBusiness();

        // GET: AnimalWeight
        
        public ActionResult GetAll()
        {
            return View(_weight.GetAllAnimalWeight());
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(_animalBl.GetAllAnimals(), "AnimalId", "AniCode");
            return View();
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalWeightView model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.AnimalId = new SelectList(_animalBl.GetAllAnimals(), "AnimalId", "AnimalId");
                _weight.AddAnimalWeight(model);
                return RedirectToAction("GetAll");
            }

            return View(model);

        }


        public ActionResult DeleteAnimalWeight(int id)
        {  
            return View(_weight.GetByIdAnimalWeight(id));
        }


        [HttpPost, ActionName("DeleteAnimalWeight")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {   
            _weight.DeleteAnimalWeight(id);
            return RedirectToAction("GetAll");

        }

        public ActionResult Details(int id)
        {  
            AnimalWeightViewPar weightt = _weight.GetByIdAnimalWeight(id);
            return View(weightt);
        }


        [HttpGet]
        public ActionResult EditAnimalWeight(int id)
        {
            return View(_weight.GetByIdAnimalWeight(id));
        }


        [HttpPost, ActionName("EditAnimalWeight")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnimalWeightViewPar model)
        {
            if (ModelState.IsValid)
            {
                _weight.UpdateAnimalWeight(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }

    }
}