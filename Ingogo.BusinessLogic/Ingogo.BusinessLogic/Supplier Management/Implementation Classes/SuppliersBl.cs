using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Supplier_Management.Interface_Classes;
using Ingogo.Data.Supplier_Management.Models;
using Ingogo.Model.Supplier_Management.Model_View;
using Ingogo.Service.Supplier_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Supplier_Management.Implementation_Classes
{
    public class SuppliersBl : ISuppliersBl
    {
        #region Supervisor
        public List<SuppliersView> GetAllSuppliers()
        {
            using (var supplier = new SuppliersRepository())
            {
                return supplier.GetAll().Select(x => new SuppliersView
                {
                    SupplierId = x.SupplierId,
                    EmailAddress = x.EmailAddress,
                    PhysicalAddress = x.PhysicalAddress,
                    ShortCode = x.ShortCode,
                    Status = x.Status,
                    SupplierCellNo = x.SupplierCellNo,
                    SupplierLastName = x.SupplierLastName,
                    SupplierName = x.SupplierName,
                    SupplierTelNo = x.SupplierCellNo,
                    UserId = x.UserId
                }).ToList();
            }
        }

        public void AddNewSupplier(SuppliersView model, string userId)
        {
            using (var supplier = new SuppliersRepository())
            {
                var supp = new Suppliers
                {
                    SupplierId = model.SupplierId,
                    EmailAddress = model.EmailAddress,
                    PhysicalAddress = model.PhysicalAddress,
                    Status = "Waiting For Approval",
                    SupplierCellNo = model.SupplierCellNo,
                    SupplierLastName = model.SupplierLastName,
                    SupplierName = model.SupplierName,
                    SupplierTelNo = model.SupplierTelNo,
                    UserId = userId,
                    ShortCode = ""
                };
                supplier.Insert(supp);

                //update
                supp.ShortCode = (Guid.NewGuid().ToString().Substring(0, 4) + "-" + supp.SupplierId + "-"
                                  + model.SupplierName.Substring(0, 1) + model.SupplierLastName.Substring(0, 1)).ToUpper();
                supplier.Update(supp);
                
            }
        }
        #endregion

        public List<SuppliersView> GetAllSuppliersDisApproved()
        {
            using (var supplier = new SuppliersRepository())
            {
                List<Suppliers> returnList = supplier.GetAll().Where(x => x.Status == "Disapproved").ToList();
                return returnList.Select(x => new SuppliersView
                {
                    SupplierId = x.SupplierId,
                    EmailAddress = x.EmailAddress,
                    PhysicalAddress = x.PhysicalAddress,
                    ShortCode = x.ShortCode,
                    Status = x.Status,
                    SupplierCellNo = x.SupplierCellNo,
                    SupplierLastName = x.SupplierLastName,
                    SupplierName = x.SupplierName,
                    SupplierTelNo = x.SupplierCellNo,
                    UserId = x.UserId
                }).ToList();
            }
        }

        public List<SuppliersView> GetAllSuppliersApproved()
        {
            using (var supplier = new SuppliersRepository())
            {
                List<Suppliers> returnList = supplier.GetAll().Where(x => x.Status == "Approved").ToList();
                return returnList.Select(x => new SuppliersView
                {
                    SupplierId = x.SupplierId,
                    EmailAddress = x.EmailAddress,
                    PhysicalAddress = x.PhysicalAddress,
                    ShortCode = x.ShortCode,
                    Status = x.Status,
                    SupplierCellNo = x.SupplierCellNo,
                    SupplierLastName = x.SupplierLastName,
                    SupplierName = x.SupplierName,
                    SupplierTelNo = x.SupplierCellNo,
                    UserId = x.UserId
                }).ToList();
            }
        }

        #region Owner

        public List<SuppliersView> GetAllSuppliersManagement()
        {
            using (var supplier = new SuppliersRepository())
            {
                List<Suppliers> returnList = supplier.GetAll().Where(x => x.Status == "Waiting For Approval").ToList();

                return returnList.Select(x => new SuppliersView
                {
                    SupplierId = x.SupplierId,
                    EmailAddress = x.EmailAddress,
                    PhysicalAddress = x.PhysicalAddress,
                    ShortCode = x.ShortCode,
                    Status = x.Status,
                    SupplierCellNo = x.SupplierCellNo,
                    SupplierLastName = x.SupplierLastName,
                    SupplierName = x.SupplierName,
                    SupplierTelNo = x.SupplierCellNo,
                    UserId = x.UserId
                }).ToList();
            }
        }
        //owner approval
        public void Approve(SuppliersView model)
        {
            using (var supplier = new SuppliersRepository())
            {
                var supp = supplier.GetById(model.SupplierId);
                if (supp != null)
                {
                    supp.SupplierId = model.SupplierId;
                    supp.Status = model.Status;
                    supp.SupplierId = supp.SupplierId;
                    supp.EmailAddress = supp.EmailAddress;
                    supp.PhysicalAddress = supp.PhysicalAddress;
                    supp.ShortCode = supp.ShortCode;
                    supp.SupplierCellNo = supp.SupplierCellNo;
                    supp.SupplierLastName = supp.SupplierLastName;
                    supp.SupplierName = supp.SupplierName;
                    supp.UserId = supp.UserId;
                    supp.SupplierTelNo = model.SupplierTelNo;

                    supplier.Update(supp);
                }
            }
        }
        #endregion

        public SuppliersView GetSupplierById(int id)
        {
            using (var supplier = new SuppliersRepository())
            {
                Suppliers supp = supplier.GetById(id);
                var suppView = new SuppliersView();
                if (supp != null)
                {
                    suppView.SupplierId = supp.SupplierId;                    
                    suppView.EmailAddress = supp.EmailAddress;
                    suppView.Status = supp.Status;
                    suppView.PhysicalAddress = supp.PhysicalAddress;
                    suppView.ShortCode = supp.ShortCode;
                    suppView.SupplierCellNo = supp.SupplierCellNo;
                    suppView.SupplierLastName = supp.SupplierLastName;
                    suppView.SupplierName = supp.SupplierName;
                    suppView.UserId = supp.UserId;
                    suppView.SupplierTelNo = supp.SupplierTelNo;
                }
                return suppView;
            }
        }
    }
}
