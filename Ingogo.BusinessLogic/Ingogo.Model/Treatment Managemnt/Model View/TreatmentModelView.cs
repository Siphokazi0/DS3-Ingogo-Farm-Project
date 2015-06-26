using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingogo.Model.Treatment_Managemnt.Model_View
{
    public class TreatmentModelView
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tid { get; set; }

        [Required]
        [Display(Name = "Treatment Name:")]
        [DataType(DataType.Text)]
        public string Tname { get; set; }

    }
}
