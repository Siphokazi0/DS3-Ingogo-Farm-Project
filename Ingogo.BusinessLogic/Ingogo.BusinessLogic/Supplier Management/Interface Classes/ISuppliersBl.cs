using System.Collections.Generic;
using Ingogo.Model.Supplier_Management.Model_View;

namespace Ingogo.BusinessLogic.Supplier_Management.Interface_Classes
{
    public interface ISuppliersBl
    {
        List<SuppliersView> GetAllSuppliers();
        void AddNewSupplier(SuppliersView model, string userId);
        void Approve(SuppliersView model);
        SuppliersView GetSupplierById(int id);
        List<SuppliersView> GetAllSuppliersManagement();
        List<SuppliersView> GetAllSuppliersDisApproved();
        List<SuppliersView> GetAllSuppliersApproved();
    }
}
