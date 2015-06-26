using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Animal_Management.Implementation_Classes;
using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Service.Batch_Management.Implementation_Classes;

namespace Ingogo.MVC.Controllers
{
    public class DeadAnimalController : Controller
    {
        static readonly DeadAnimalBL dead = new DeadAnimalBL();
        readonly AnimalBusiness ani=new AnimalBusiness();
        static readonly  BatchTypeBl _db2=new BatchTypeBl();
        // GET: DeadAnimal
        public ActionResult GetAllDeadAnimals()
        {

            return View(dead.GetAllDeadAnimals());
        }
        [HttpGet]
        public ActionResult InsertDeadAnimals()
        {
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            return View();

        }
        [HttpPost, ActionName("InsertDeadAnimals")]
        [ValidateAntiForgeryToken]
        public ActionResult InsertDeadAnimals(Animalpar model)
        {

                if (ModelState.IsValid)
                {
                    ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
                    dead.InsertDeadAnimals(model);
                    return RedirectToAction("GetAllDeadAnimals");

                    
                }
                return View(model);          
        }
        public ActionResult DeleteDeadAnimals(int id)
        {
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            return View(dead.GetDeadById(id));
        }
        
        [HttpPost, ActionName("DeleteDeadAnimals")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            dead.DeleteDeadAnimals(id);
            return RedirectToAction("GetAllDeadAnimals");

        }
        public ActionResult DeadAnimalDetails(int id)
        {
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            Animalpar animal = dead.GetDeadById(id);
            return View(animal);
        }
        [HttpGet]
        public ActionResult UpdateDeadAnimals(int id)
        {
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            return View(dead.GetDeadById(id));
        }
        [HttpPost, ActionName("UpdateDeadAnimals")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDeadAnimals(Animalpar model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
                dead.UpdateDeadAnimals(model);
                return RedirectToAction("GetAllDeadAnimals");
            }


            return View(model);
        }

    }
}