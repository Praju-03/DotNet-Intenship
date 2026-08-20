using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.DTOs
{
    public class InterviewStatusDto
    {
        public int InterviewId { get; set; }

        [Required(ErrorMessage = "ApplicationId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "A valid ApplicationId is required")]
        public int ApplicationId { get; set; }

        [Required(ErrorMessage = "Interview date is required")]
        public DateTime InterviewDate { get; set; }

        [Required(ErrorMessage = "Interview type is required")]
        [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
        public string InterviewType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, ErrorMessage = "20 Max letters are allowed")]
        public string Status { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "500 Max letters are allowed")]
        public string? Feedback { get; set; }
    }
}