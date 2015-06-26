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
    public class TreatmentRatioViewPar
    {

        [Key]
        public int TreatmentRatioId { get; set; }

        public double TotalMass { get; set; }

        public decimal TreatPrice { get; set; }

        public string IngredientName { get; set; }
       
        public string TreatmentPercentage { get; set; }

        public string TreatmentName { get; set; }
        

    }
}
