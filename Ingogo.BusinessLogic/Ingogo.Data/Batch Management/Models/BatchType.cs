using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ingogo.Data.Animal_Management.Models;

namespace Ingogo.Data.Batch_Management.Models
{
    public class BatchType
    {
        [Key]
        public int BatchTypeid { get; set; }
        public String BatchTypeDesc { get; set; }

        public IEnumerable<Animal> Animals { get; set; }
    }
}
