using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Data.Batch_Management.Models;

namespace Ingogo.Data.Animal_Management.Models
{
    public class DeadAnimal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public String AniCode { get; set; }
        public int BatchTypeid { get; set; }
        public string AniColor { get; set; }
        public string AniFeedingStatus { get; set; }
        public int AniAge { get; set; }
        public int AniWeight { get; set; }
        public string AniGender { get; set; }
        public string AniHealthStatus { get; set; }
        public decimal AniCurrentCost { get; set; }
        public string AniSaleStatus { get; set; }
        public decimal AniTotCost { get; set; }
        public double AnimalValue { get; set; }
        public string deathCause { get; set; }
        public virtual BatchType BatchTypes { get; set; }

    }
}
