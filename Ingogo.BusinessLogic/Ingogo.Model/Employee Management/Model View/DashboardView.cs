using System.ComponentModel.DataAnnotations;

namespace Ingogo.Model.Employee_Management.Model_View
{
    public class DashboardView
    {
        [Key]
        public int UserProfileId { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
