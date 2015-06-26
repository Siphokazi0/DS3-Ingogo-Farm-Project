using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingogo.Data.Treatment_Managemnt.Models
{
    public class TreatmentRatio
    {
        [Key]
        public int TreatmentRatioId { get; set; }

        public double TotalMass { get; set; }

        public decimal TreatPrice { get; set; }

        public int IngredientId { get; set; }
        public virtual TreatmentIngredients TreatmentIngredients { get; set; }

        public int TreatmentPercentageId { get; set; }
        public virtual TreatmentPercentage TreatmentPercentage { get; set; }

        public int Tid { get; set; }
        public virtual Treatment Treatment { get; set; }


    }
}
