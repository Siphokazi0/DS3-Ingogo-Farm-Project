using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class AnimalWeightView
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalWeightId { get; set; }

        [Display(Name= "Date Weighted")]
        [DataType(DataType.DateTime)]
        public DateTime DateWeighted { get; set; }

        [Display(Name = "Animal Weight")]
        [DataType(DataType.Currency)]
        [Required]
        public double OriginalWeight { get; set; }

        [Display(Name = "Average")]
        [DataType(DataType.Currency)]
        public double AverageWeight { get; set; }

        [Required]
        [Display(Name = "Animal Code")]
        public int AnimalId { get; set; }
        public virtual AnimalView Animal { get; set; }

    }
}
