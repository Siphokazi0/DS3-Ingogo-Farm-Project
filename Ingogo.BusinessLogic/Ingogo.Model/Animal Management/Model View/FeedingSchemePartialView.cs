using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class FeedingSchemePartialView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedingSchemeId { get; set; }

        [DisplayName("Animal Category")]
        public string BatchTypeDesc { get; set; }

        [DisplayName("Number of animals in feeding lot")]
        public int NoOfAnimals { get; set; }

        [DisplayName("Date of Preparation")]
        public DateTime DatePrepared { get; set; }

        [Required]
        [DisplayName("Number Of Ingredients")]
        public int NumIngredients { get; set; }

        [DisplayName("Feeding Scheme Code")]
        public string SchemeCode { get; set; }

        [DisplayName("Cost Per Animal Feeding")]
        [DataType(DataType.Currency)]
        public double CostPerAnimal { get; set; }

        [DisplayName("Total Feeding Scheme Cost")]
        [DataType(DataType.Currency)]
        public double TotalCostForScheme { get; set; }
    }
}
