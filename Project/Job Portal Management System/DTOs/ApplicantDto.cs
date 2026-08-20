using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.DTOs
{
    public class ApplicantDto
    {
        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
        [EmailAddress(ErrorMessage = "Email is incorrect")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(15, ErrorMessage = "15 Max letters are allowed")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Skills are required")]
        [StringLength(200, ErrorMessage = "200 Max letters are allowed")]
        public string Skills { get; set; } = string.Empty;

        [Required(ErrorMessage = "Education is required")]
        [StringLength(100, ErrorMessage = "100 Max letters are allowed")]
        public string Education { get; set; } = string.Empty;

        [Required(ErrorMessage = "Resume is required")]
        [StringLength(255, ErrorMessage = "255 Max characters are allowed")]
        public string Resume { get; set; } = string.Empty;
    }
}