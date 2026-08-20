using Microsoft.AspNetCore.Identity;

namespace Job_Portal_Management_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = "Applicant";
    }
}