using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class DeadAnimalpar
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [Display(Name = "Animal Code")]
        public string AniCode { get; set; }

        [Display(Name = "Batch Description")]
        public string BatchTypeDesc { get; set; }

        [Display(Name = "Animal Colour")]
        public string AniColor { get; set; }

        [Display(Name = "Feeding Status")]
        public string AniFeedingStatus { get; set; }

        [Display(Name = "Age")]
        public int AniAge { get; set; }

        [Display(Name = "Weight")]
        public int AniWeight { get; set; }

        [Display(Name = "Gender")]
        public string AniGender { get; set; }

        [Display(Name = "Health Status")]
        public string AniHealthStatus { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Current Cost")]
        public decimal AniCurrentCost { get; set; }


        [Display(Name = "Sales Status")]
        public string AniSaleStatus { get; set; }



        [DataType(DataType.Currency)]
        [Display(Name = "Total Cost")]
        public decimal AniTotCost { get; set; }


        [DataType(DataType.Currency)]
        [Display(Name = "Animal Value")]
        public double AnimalValue { get; set; }


        [Display(Name = "Death Cause")]
        public string deathCause { get; set; }
     

        }

    }

