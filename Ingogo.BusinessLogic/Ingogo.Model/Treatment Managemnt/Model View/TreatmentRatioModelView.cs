using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Model.Treatment_Managemnt.Model_View
{
    public class TreatmentRatioModelView
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreatmentRatioId { get; set; }

        public double TotalMass { get; set; }

        public decimal TreatPrice { get; set; }

        [Required]
        public int IngredientId { get; set; }
        public virtual TreatmentIngredients TreatmentIngredients { get; set; }

        [Required]
        public int TreatmentPercentageId { get; set; }
        public virtual TreatmentPercentage TreatmentPercentage { get; set; }

        [Required]
        public int Tid { get; set; }
        public virtual Treatment Treatment { get; set; }


    }
}
