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
    public class FeedingRatioViewPar
    {
        [Key]
        public int FeedingRatioId { get; set; }

        [Display(Name = "Product Mass")]
        public string ProductMass { get; set; }

        
    }
}
