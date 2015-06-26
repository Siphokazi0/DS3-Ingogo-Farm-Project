using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class PercentagePartialView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PercentageId { get; set; }

        [DisplayName("Ingredient Description")]
        public string ItemName { get; set; }

        [DisplayName("Ingredient Percentage (%)")]
        public double Percentage { get; set; }
        
        [DisplayName("Feeding Scheme Code")]
        public string SchemeCode { get; set; }
     }
}
