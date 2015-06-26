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
    public class IngredientsModelView
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [Required]
        public int NumIngredients { get; set; }

        [Required]
        public decimal Ingredientprice { get; set; }

        [Required]
        public double IngredientMass { get; set; }

        public decimal TotalPrice { get; set; }

        public double TotalMass { get; set; }
    }
}
