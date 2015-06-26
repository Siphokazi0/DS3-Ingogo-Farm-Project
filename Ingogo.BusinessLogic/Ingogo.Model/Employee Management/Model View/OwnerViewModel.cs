using System.ComponentModel.DataAnnotations;

namespace Ingogo.Model.Employee_Management.Model_View
{
    public class OwnerViewModel
    {
        [Key]
        public int UserProfileId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool? IsFirstTimeLogin { get; set; } 
    }
}
