using System.Web.Mvc;
using Ingogo.BusinessLogic.Batch_Management.Implementation_Classes;
using Ingogo.Model.Batch_Management.Model_View;
using Ingogo.Service.Batch_Management.Implementation_Classes;

namespace Ingogo.MVC.Controllers
{
   [Authorize(Roles = "Supervisor")]
    public class BatchTypeController : Controller
    {
      
       readonly BatchTypeBl _db = new BatchTypeBl();
        //private readonly IBatchTypeBl _db;

        // public BatchTypeController(IBatchTypeBl db)
        //{
        //    this._db = db;
        //}

      
        //Get all batchtype
        public ActionResult GetAllBatchType()
        {
            return View(_db.GetAllBatchTypes());
        }
       
        //Add batchtype
        public ActionResult AddBatchType()
        {
            return View();
        }

        [HttpPost, ActionName("AddBatchType")]
        [ValidateAntiForgeryToken]
        public ActionResult AddBatchType(BatchTypeView model)
        {
           // BatchType _dbb=new BatchType();
            var titleobj = _db.GetAllBatchTypes().Find(t => t.BatchTypeDesc.StartsWith(model.BatchTypeDesc));
            //int countrec = _db.GetAllBatchTypes().Count;
            //if (countrec > 5)
          //  {
            if (titleobj != null)
            {
                ViewBag.Exist = "Batch Of " + model.BatchTypeDesc + "Already Exists, Please Enter Anther One";
                return View(model);
            }

          //  }
            _db.Insert(model);
            return RedirectToAction("GetAllBatchType");  
        }  
       
        //Single Batchtype
        public ActionResult Details(int id)
        {
            var batchtypelog = new BatchTypeBl();
            return View(batchtypelog.GetBatchTypeById(id));
        }
       //Edit BatchType
        [HttpGet]
        public ActionResult EditBatchType(int id)
        {
            return View(_db.GetBatchTypeById(id));
        }
        [HttpPost, ActionName("EditBatchType")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBatchType(BatchTypeView model)
        {
            if (ModelState.IsValid)
            {

                _db.Update(model);
                return RedirectToAction("GetAllBatchType");
            }
            return View(model);
        }

        //Edit BatchType

        public ActionResult Delete(int? id)
        {
            var _batchtypelog = new BatchTypeBl();
            var batchview = _batchtypelog.GetAllBatchTypes().Find(x => x.BatchTypeid == id);
            return View(batchview);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var repo = new BatchTypeRepository();
            var _batchtypelog = new BatchTypeBl();
            var batchview = _batchtypelog.GetBatchTypeById(id);
            _batchtypelog.Delete(batchview);
            return RedirectToAction("GetAllBatchType");
        }
    }
}