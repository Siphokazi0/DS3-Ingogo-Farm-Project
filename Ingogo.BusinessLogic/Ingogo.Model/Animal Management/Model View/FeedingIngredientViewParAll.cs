using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Purchase_Management.Models;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class FeedingIngredientViewParAll
    {
        [Key]        
        public int FeedingIngredientsId { get; set; }

        public string IngredientMass { get; set; }

        public string Percentage { get; set; }

        public string StockItem{ get; set; }
    }
}
