using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Model.Treatment_Managemnt.Model_View
{
    public class TreatmentRatioTotalView
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreatmentRatioTotalId { get; set; }

        public decimal Price { get; set; }

       

        [Required]
        public int Tid { get; set; }
        public virtual Treatment Treatment { get; set; }

    }
}
