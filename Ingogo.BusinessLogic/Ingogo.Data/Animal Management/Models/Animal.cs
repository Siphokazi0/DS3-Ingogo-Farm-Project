using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ingogo.Data.Batch_Management.Models;

//using Ingogo.Data.Batch_Management.Models;

namespace Ingogo.Data.Animal_Management.Models
{
    public class Animal 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public String AniCode { get; set; }
        public int BatchTypeid { get; set; }
        public string AniColor { get; set; }
        public string AniFeedingStatus { get; set; }
        public int AniAge { get; set; }
        public string AniGender { get; set; }
        public string AniHealthStatus { get; set; }
        public decimal AniCurrentCost { get; set; }
        public string AniSaleStatus { get; set; }
        public decimal AniTotCost { get; set; }
        public double AnimalValue { get; set; }
        public virtual BatchType BatchTypes { get; set; }

       // public int FeedingId { get; set; }
      //  public virtual FeedingScheme FeedingScheme { get; set; }
    
    }
}
