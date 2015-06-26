using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingogo.Data.Treatment_Managemnt.Models
{
    public class TreatmentRatioTotal
    {

        [Key]
        public int TreatmentRatioTotalId { get; set; }
        public decimal Price { get; set; }
   
        public int Tid { get; set; }
        public virtual Treatment Treatment { get; set; }

    }
}
