using System;
using System.ComponentModel.DataAnnotations;

namespace Ingogo.Data.Animal_Management.Models
{
    public class AnimalWeight
    {

        [Key]
        public int AnimalWeightId { get; set; }
        public DateTime DateWeighted { get; set; }
        public double OriginalWeight { get; set; }
        public double AverageWeight { get; set; }
        
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }

    }
}
