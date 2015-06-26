using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Data.Treatment_Managemnt.Models
{
    public class TreatmentPercentage
    {

        [Key]
        public int TreatmentPercentageId { get; set; }
        public string Percentage { get; set; }
    }
}
