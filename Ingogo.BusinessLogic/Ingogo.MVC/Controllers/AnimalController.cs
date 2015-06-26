using System;
using System.Linq;
using System.Web.Mvc;
using Ingogo.BusinessLogic.Animal_Management.Implementation_Classes;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Model.Batch_Management.Model_View;
using Microsoft.Ajax.Utilities;

//using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;

namespace Ingogo.MVC.Controllers
{
    public class AnimalController : Controller
    {
        
        static readonly AnimalBusiness ani = new AnimalBusiness();
        readonly BatchTypeBl _db2 = new BatchTypeBl();
        private  BatchBl batch = new BatchBl();
        static readonly DeadAnimalBL dead = new DeadAnimalBL();
    

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllAnimals()
        {
       
            return View(ani.GetAllAnimals());

        }

        [HttpGet]
        public ActionResult InsertAnimals(AnimalView model)
        {

                ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
                return View(ani.GetAnimalById2(model));
        
        }

        [HttpPost, ActionName("InsertAnimals")]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(AnimalView model)
        {
            var m = batch.GetAllBatches().Find(x => x.BatchTypeid == model.BatchTypeid);

            int count = ani.GetAllAnimals().FindAll(x => x.BatchTypeDesc.Contains(model.AniCode.Substring(0, 2))).Count;       
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            if (ani.tot(model)==0)
            {
              if(count<m.NumOfAnimals)
                 {
                    ani.InsertAnimals(model);

                    count = count = ani.GetAllAnimals().FindAll(x => x.BatchTypeDesc.Contains(model.AniCode.Substring(0, 2))).Count; 
                     if (count < m.NumOfAnimals)
                     {
                         return RedirectToAction("InsertAnimals");
                     }
                 }      
            }
           else
            {
                ViewBag.Exist = "The current cost you have entered must be less than total cost";
                return View(model);
            }
               
                return RedirectToAction("GetAllAnimals");
            
        }
               

        public ActionResult DeleteAnimals(int id)
        {
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            return View(ani.GetAnimalById(id));
        }

        [HttpPost, ActionName("DeleteAnimals")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var animals=new AnimalBusiness();
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            var anView =ani.GetAnimalById(id);
            ani.DeleteAnimals(anView);
            dead.InsertDeadAnimals(anView);
            return RedirectToAction("GetAllAnimals");

        }
        public ActionResult AnimalDetails(int id)
        {
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            Animalpar animal = ani.GetAnimalById(id);
            return View(animal);
        }

        [HttpGet]
        public ActionResult UpdateAnimals(int id)
        {
            ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
            return View(ani.GetAnimalById(id));
        }
        [HttpPost, ActionName("UpdateAnimals")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAnimals(Animalpar model)
        {
            if (ani.num == 0)
            {
                ViewBag.Batchtypeid = new SelectList(_db2.GetAllBatchTypes(), "BatchTypeid", "BatchTypeDesc");
                ani.UpdateAnimals(model);
                
            }
            else
            {
                ViewBag.Exist = "The current cost you have entered must be less than total cost";
                return View(model);
            }
            return RedirectToAction("GetAllAnimals");
        }
        

    }
}