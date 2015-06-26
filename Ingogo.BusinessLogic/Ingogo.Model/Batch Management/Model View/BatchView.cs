using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Ingogo.Data.Batch_Management.Models;

namespace Ingogo.Model.Batch_Management.Model_View
{
    public class BatchView
    {
        [Key]

        public int Batchid { get; set; }

        [Required]
        [DisplayName("Batch Description")]
        public int BatchTypeid { get; set; }
        public String UserId { get; set; }
        public String Name { get; set; }
        [Required]
        [DisplayName("Number Of Animals")]
        public int NumOfAnimals { get; set; }
        [Required]
        [DisplayName("Age Range Of Animals")]

        public int Agerange { get; set; }
        // [Required]
        [DisplayName("Batch Code")]
        public String BatchCode { get; set; }
        [Required]
        [DisplayName("Animals Average Weigth")]
        public Double Wiegth { get; set; }
        [Required]
        [DisplayName("Animals Total Cost")]
        public Decimal Totalcost { get; set; }
        public virtual BatchType BatchTypeViews { get; set; }
    }
}
