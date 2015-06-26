using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Data.Purchase_Management.Models
{
    public class FeedingStock
    {
        [Key]
        public int FeedingStockId { get; set; }

        public string ItemName { get; set; }

        public int NumberOfItems { get; set; }

        public int Mass { get; set; }

        public double ItemPrice { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public DateTime ExpairyDate { get; set; }
        
        public double TotalPrice { get; set; }

        public double TotalMass{ get; set; }

        public IEnumerable<FeedingRatio> FeedingRatios { get; set; }

    }
}
