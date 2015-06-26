using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Purchase_Management.Models;

namespace Ingogo.Data.Animal_Management.Models
{
    public class FeedingRatio
    {
        [Key]
        public int FeedingRatioId { get; set; }

        public string ProductName { get; set; }

        public string ProductMass { get; set; }

    }
}
