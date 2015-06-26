using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Treatment_Managemnt.Models;

namespace Ingogo.Model.Treatment_Managemnt.Model_View
{
    public class TreatmentRatioTotalViewPar
    {

        [Key]
        public int TreatmentRatioTotalId { get; set; }

        public decimal Price { get; set; }

        

        public string TreatmentName { get; set; }
        

    }
}
