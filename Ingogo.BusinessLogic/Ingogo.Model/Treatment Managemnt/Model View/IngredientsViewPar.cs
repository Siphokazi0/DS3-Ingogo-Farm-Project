using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingogo.Model.Treatment_Managemnt.Model_View
{
    public class IngredientsViewPar
    {

        [Key]
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }
     
        public decimal Ingredientprice { get; set; }
        
        public double IngredientMass { get; set; }

        [Display(Name = "Number of Treatments")]
        public int NumIngredients { get; set; }

        public decimal TotalPrice { get; set; }

        public double TotalMass { get; set; }
   

    }
}
