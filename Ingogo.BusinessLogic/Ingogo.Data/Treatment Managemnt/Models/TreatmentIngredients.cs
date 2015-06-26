using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingogo.Data.Treatment_Managemnt.Models
{
    public class TreatmentIngredients
    {

        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int NumIngredients { get; set; }
        public decimal Ingredientprice { get; set; }
        public double IngredientMass { get; set; }
        public decimal TotalPrice { get; set; }
        public double TotalMass { get; set; }

    }
}
