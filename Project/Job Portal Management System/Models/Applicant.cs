using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.Models
{
    public class Applicant
    {
            [Key]
            public int ApplicantId { get; set; }

            [Required(ErrorMessage = "Name is required")]
            [StringLength(30, ErrorMessage = "30 Max letters are required")]
            public string Name { get; set; } = string.Empty;

            [Required(ErrorMessage = "Email is required")]
            [StringLength(50, ErrorMessage = "50 Max letters are required")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Phone number is required")]
            [StringLength(10, ErrorMessage = "10 Max letters are required")]
            public string Phone { get; set; } = string.Empty;

            [Required(ErrorMessage = "Skills are required")]
            [StringLength(200, ErrorMessage = "200 Max letters are required")]
            public string Skills { get; set; } = string.Empty;

            [Required(ErrorMessage = "Education is required")]
            [StringLength(100, ErrorMessage = "100 Max letters are required")]
            public string Education { get; set; } = string.Empty;

            [Required(ErrorMessage = "Resume is required")]
            [StringLength(200, ErrorMessage = "200 Max letters are required")]
            public string Resume { get; set; } = string.Empty;

            // One applicant can apply many jobs
            public ICollection<JobApplication> Applications { get; set; }  = new List<JobApplication>();
        }
    }
