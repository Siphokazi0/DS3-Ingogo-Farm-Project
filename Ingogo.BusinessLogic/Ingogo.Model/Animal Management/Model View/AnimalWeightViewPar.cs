using System;
using System.ComponentModel.DataAnnotations;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class AnimalWeightViewPar
    {

        [Key] 
        public int AnimalWeightId { get; set; }

        [Display(Name = "Animal Code")]
        public String AnimalCode { get; set; }

        [Display(Name = "Date Weighted")]
        [DataType(DataType.DateTime)]
        public DateTime DateWeighted { get; set; }

        [Display(Name = "Animal Weight")]
        [DataType(DataType.Currency)]
        public double OriginalWeight { get; set; }

        [Display(Name = "Average")]
        [DataType(DataType.Currency)]
        public double AverageWeight { get; set; }

    }
}
