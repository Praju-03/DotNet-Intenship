using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.Models
{
    public class Job
     {
            [Key]
            public int JobId { get; set; }

            [Required(ErrorMessage = "Job title is required")]
            [StringLength(50, ErrorMessage = "50 Max letters are required")]
            public string JobTitle { get; set; } = string.Empty;

            [Required(ErrorMessage = "Description is required")]
            [StringLength(200, ErrorMessage = "200 Max letters are required")]
            public string Description { get; set; } = string.Empty;

            [Required(ErrorMessage = "Skills are required")]
            [StringLength(200, ErrorMessage = "200 Max letters are required")]
            public string Skills { get; set; } = string.Empty;

            [Required(ErrorMessage = "Salary is required")]
            public decimal Salary { get; set; }

            [Required(ErrorMessage = "Location is required")]
            [StringLength(50, ErrorMessage = "50 Max letters are required")]
            public string Location { get; set; } = string.Empty;

            [Required(ErrorMessage = "Experience is required")]
            public int Experience { get; set; }

            [Required(ErrorMessage = "Job type is required")]
            [StringLength(30, ErrorMessage = "30 Max letters are required")]
            public string JobType { get; set; } = string.Empty;

            // Foreign Key
            public int CompanyId { get; set; }

            // Navigation is here
            public Company? Company { get; set; }

            // One job can have many applications
            public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
        }
    }
