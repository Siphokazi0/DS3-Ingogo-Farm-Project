using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Ingogo.Model.Batch_Management.Model_View;
using Ingogo.Model.Supplier_Management.Model_View;


//using Ingogo.Model.Batch_Management.Model_View;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class AnimalView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        
        [Display(Name = "Animal Code")]
        public string AniCode { get; set; }

   
        public int BatchTypeid { get; set; }
        
        [Required]
        [Display(Name="Animal Colour")]
        public string AniColor { get; set; }

        [Required]
        [Display(Name = "Feeding Status")]
        public string AniFeedingStatus { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int AniAge { get; set; }


        [Required]
        [Display(Name = "Gender")]
        public string AniGender { get; set; }

        [Required]
        [Display(Name = "Health Status")]
        public string AniHealthStatus { get; set; }

         
        [DataType(DataType.Currency)]
        [Display(Name = "Current Cost")]
        public decimal AniCurrentCost { get; set; }

   
        [Display(Name = "Sales Status")]
        public string AniSaleStatus { get; set; }



        //[DataType(DataType.Currency)]
        //[Display(Name = "Total Cost")]
        public decimal AniTotCost { get; set; }

  
        [DataType(DataType.Currency)]
        [Display(Name = "Animal Value")]
        public double AnimalValue { get; set; }

        public virtual BatchTypeView BatchTypeViews { get; set; }
        public virtual SuppliersView SuppliersView { get; set; }
        
    }
}
