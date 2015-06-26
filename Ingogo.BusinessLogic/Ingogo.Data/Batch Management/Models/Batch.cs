using System;
using System.ComponentModel.DataAnnotations;

namespace Ingogo.Data.Batch_Management.Models
{
    public class Batch
    {
        [Key]

        public int Batchid { get; set; }
        public String BatchCode { get; set; }
        public String UserId { get; set; }
        public String Name { get; set; }
        public int BatchTypeid { get; set; }
        public int NumOfAnimals { get; set; }
        public int Agerange { get; set; }
        public Double Wiegth { get; set; }
        public Decimal Totalcost { get; set; }
       public virtual BatchType BatchTypeViews { get; set; }
    }
}
