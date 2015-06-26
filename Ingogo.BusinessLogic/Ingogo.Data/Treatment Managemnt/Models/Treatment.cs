using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ingogo.Data.Treatment_Managemnt.Models
{
    public class Treatment
    {
        [Key]
        public int Tid { get; set; }
        public string Tname { get; set; } 
    }
}
