using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Model.Treatment_Managemnt.Model_View
{
    public class TreatmentPercentageModelView
    {

        [Key]
        public int TreatmentPercentageId { get; set; }

        [Required]
        public string Percentage { get; set; }

    }
}
