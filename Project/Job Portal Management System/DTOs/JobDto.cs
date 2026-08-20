using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.DTOs
{
    public class JobDto
    {
        public int JobId { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        [StringLength(50, ErrorMessage = "50 Max letters are allowed")]
        public string JobTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "1000 Max letters are allowed")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Skills are required")]
        [StringLength(200, ErrorMessage = "200 Max letters are allowed")]
        public string Skills { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, 10000000, ErrorMessage = "Salary must be a positive value")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, ErrorMessage = "50 Max letters are allowed")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Experience is required")]
        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years")]
        public int Experience { get; set; }

        [Required(ErrorMessage = "Job type is required")]
        [StringLength(20, ErrorMessage = "20 Max letters are allowed")]
        public string JobType { get; set; } = string.Empty;

        [Required(ErrorMessage = "CompanyId is required")]
        public int CompanyId { get; set; }
    }
}