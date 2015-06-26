using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Purchase_Management.Models;

namespace Ingogo.Data.Animal_Management.Models
{
    public class FeedingIngredients
    {
        [Key]
        public int FeedingIngredientsId { get; set; }

        //from feeding stock
        public string IngredientMass { get; set; }

        //foreign key
        public int FeedingPercentageId { get; set; }
        public virtual FeedingPercentage FeedingPercentage { get; set; }


        public int FeedingStockId { get; set; }
        public virtual FeedingStock FeedingStock { get; set; }
    }
}
