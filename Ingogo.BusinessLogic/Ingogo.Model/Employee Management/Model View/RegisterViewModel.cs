using System.ComponentModel.DataAnnotations;

namespace Ingogo.Model.Employee_Management.Model_View
{
    public class RegisterViewModel
    {
        [Key]
        public int UserProfileId { get; set; }
        
        [Required]
        [Display(Name="First Name")]
        public string  FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //To be determined by the system
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Identity Number")]
        [StringLength(13)]
        public string IdentityNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Physical Address")]
        [DataType(DataType.MultilineText)]
        public string PhysicalAddress { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [StringLength(10)]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        //For Fist Time Log in
        public bool? IsFirstTimeLogin { get; set; }
    }

   
}