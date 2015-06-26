using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ingogo.Data.Purchase_Management.Models;

namespace Ingogo.Data.Animal_Management.Models
{
    public class Percentage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PercentageId { get; set; }
        public int FeedingStockId { get; set; }
        public double PercentageRate { get; set; }
        public int FeedingSchemeId { get; set; }
        public virtual FeedingScheme FeedingScheme { get; set; }
        public virtual FeedingStock FeedingStock { get; set; }
    }
}
