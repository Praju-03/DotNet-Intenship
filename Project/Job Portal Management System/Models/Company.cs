using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.Models
{
    public class Company
    {
          
        [Key]
            public int CompanyId { get; set; }

            [Required(ErrorMessage = "Company name is required")]
            [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
            public string CompanyName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Email is required")]
            [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Phone number is required")]
            [StringLength(15, ErrorMessage = "15 Max letters are allowed")]
            public string Phone { get; set; } = string.Empty;

            [Required(ErrorMessage = "Location is required")]
            [StringLength(50, ErrorMessage = "50 Max letters are allowed")]
            public string Location { get; set; } = string.Empty;

            // One company can have many jobs
            public ICollection<Job> Jobs { get; set; } = new List<Job>();
        }
    }

