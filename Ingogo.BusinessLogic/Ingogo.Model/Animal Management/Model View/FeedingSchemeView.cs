using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Model.Batch_Management.Model_View;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class FeedingSchemeView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedingSchemeId { get; set; }
     
        [DisplayName("Select Animal Category")]
        public int BatchTypeid { get; set; }
        
        [DisplayName("Number of animals in feeding lot")]
        public int NoOfAnimals { get; set; }

        [DisplayName("Date of Preparation")]
        public DateTime DatePrepared { get; set; }
        
        [DisplayName("Number of Ingredients")]
        public int NumIngredients { get; set; }

        [DisplayName("Feeding Scheme Code")]
        public string SchemeCode { get; set; }

        [DisplayName("Cost Per Animal Feeding")]
        [DataType(DataType.Currency)]
        public double CostPerAnimal { get; set; }

        [DisplayName("Total Feeding Scheme Cost")]
        [DataType(DataType.Currency)]
        public double TotalCostForScheme { get; set; }

        public virtual BatchTypeView BatchTypeViews { get; set; }
      }
}
