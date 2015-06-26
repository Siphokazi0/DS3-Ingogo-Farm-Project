using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ingogo.Model.Batch_Management.Model_View
{
    public class BatchTypeView
    {
        [Key]
        public int BatchTypeid { get; set; }
        [Required]
        [DisplayName("Batch Description")]
        [DataType(DataType.Text)]
        public String BatchTypeDesc { get; set; }
         
    }
}
