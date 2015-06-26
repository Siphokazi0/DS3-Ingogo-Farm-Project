using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ingogo.Data.Batch_Management.Models;


namespace Ingogo.Data.Animal_Management.Models
{
    public class FeedingScheme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedingSchemeId { get; set; }

        public int BatchTypeid { get; set; }
        public int NoOfAnimals { get; set; }
        public DateTime DatePrepared { get; set; }
        public int NumberOfItems { get; set; }
        public double FeedCostPerAnimal { get; set; }
        public string SchemeCode { get; set; }
        public double TotalFeedingCost { get; set; }
        public virtual BatchType BatchTypes { get; set; }
    }
}
