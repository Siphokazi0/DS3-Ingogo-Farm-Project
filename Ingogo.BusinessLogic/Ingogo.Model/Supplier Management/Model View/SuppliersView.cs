using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingogo.Model.Supplier_Management.Model_View
{
    public class SuppliersView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [Required]
        [Display(Name = "Fore Name")]
        public string SupplierName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string SupplierLastName { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string SupplierCellNo { get; set; }

        [Required]
        [Display(Name = "Telephone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string SupplierTelNo { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Physical Address")]
        [DataType(DataType.MultilineText)]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Employee Name")]
        public string UserId { get; set; }


        [Display(Name = "Code")]
        public string ShortCode { get; set; }

        

        [Display(Name = "Status")]
        public string Status { get; set; }


      
          

    }
}
