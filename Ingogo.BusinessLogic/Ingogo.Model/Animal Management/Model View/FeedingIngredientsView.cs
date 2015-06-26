using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Purchase_Management.Models;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class FeedingIngredientsView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedingIngredientsId { get; set; }

        //from feeding stock
        [Display(Name = "Ingredient Mass")]
        public string IngredientMass { get; set; }

        //foreign key
        public int FeedingPercentageId { get; set; }
        public virtual FeedingPercentageView FeedingPercentage { get; set; }


        public int FeedingStockId { get; set; }
        public virtual FeedingStock FeedingStock { get; set; } 
    }
}
