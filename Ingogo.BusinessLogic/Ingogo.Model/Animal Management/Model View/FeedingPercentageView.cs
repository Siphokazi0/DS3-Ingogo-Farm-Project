using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class FeedingPercentageView
    {
        [Key]
        public int FeedingPercentageId { get; set; }

        [Required]
        public string Percentage { get; set; }

        public IEnumerable<FeedingIngredientsView> FeedingIngredients{ get; set; }
    }
}
