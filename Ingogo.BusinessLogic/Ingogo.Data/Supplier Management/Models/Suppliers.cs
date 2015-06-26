using System.ComponentModel.DataAnnotations;

namespace Ingogo.Data.Supplier_Management.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierLastName { get; set; }

        public string SupplierCellNo { get; set; }

        public string SupplierTelNo { get; set; }

        public string EmailAddress { get; set; }

        public string PhysicalAddress { get; set; }

        public string UserId { get; set; }

        public string ShortCode { get; set; }

        public string Status { get; set; }
    }
}
