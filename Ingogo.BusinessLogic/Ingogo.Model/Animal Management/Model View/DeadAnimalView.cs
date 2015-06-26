using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Model.Batch_Management.Model_View;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class DeadAnimalView 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }


        [Display(Name = "Animal Code")]
        public string AniCode { get; set; }


        public int BatchTypeid { get; set; }

        [Required]
        [Display(Name = "Animal Colour")]
        public string AniColor { get; set; }

        [Required]
        [Display(Name = "Feeding Status")]
        public string AniFeedingStatus { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int AniAge { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public int AniWeight { get; set; }

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

        [Display(Name = "Death Cause")]
        public string deathCause { get; set; }
        public virtual BatchTypeView BatchTypeViews { get; set; }
   
    }

}
