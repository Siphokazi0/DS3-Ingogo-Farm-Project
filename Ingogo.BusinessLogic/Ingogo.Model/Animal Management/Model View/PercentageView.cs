using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ingogo.Model.Purchase_Management.Model_View;

namespace Ingogo.Model.Animal_Management.Model_View
{
    public class PercentageView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PercentageId { get; set; }

        public int FeedingStockId { get; set; }

        [Required]
        [DisplayName("Ingredient Percentage (%)")]
        public double Percentage { get; set; }

        public int FeedingSchemeId { get; set; }

        public virtual FeedingSchemeView FeedingSchemeView { get; set; }
        public virtual FeedingStockView FeedingStockView { get; set; }
    }
}
