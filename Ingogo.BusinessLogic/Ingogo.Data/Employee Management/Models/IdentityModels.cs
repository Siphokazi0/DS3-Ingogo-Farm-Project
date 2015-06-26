using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ingogo.Data.Employee_Management.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual UserProfile UserProfile { get; set; }
    }

    public abstract class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }

        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool? IsFirstTimeLogin { get; set; } 
    }
    
    public class Employees :UserProfile
    {
        public string IdentityNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Position { get; set; }
    }
    //[Table("Owner")]
    //public class Owner : UserProfile
    //{
    //    //public int Counter { get; set; }
    //}

    public class Counter
    {
        [Key]
        public int CounterId { get; set; }
        public int Count { get; set; }
    }
}