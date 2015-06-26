using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingogo.Data.Animal_Management.Models
{
    public class FeedingPercentage
    {
        [Key]
        public int FeedingPercentageId { get; set; }

        public string Percentage { get; set; }

        public IEnumerable<FeedingPercentage> FeedingPercentages{ get; set; }
    }
}
