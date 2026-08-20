using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.Models
{
    public class InterviewStatus
    {

            [Key]
            public int InterviewId { get; set; }

            [Required(ErrorMessage = "Application ID is required")]
            public int ApplicationId { get; set; }

            [Required(ErrorMessage = "Interview date is required")]
            public DateTime InterviewDate { get; set; }

            [Required(ErrorMessage = "Interview type is required")]
            [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
            public string InterviewType { get; set; } = string.Empty;

            [Required(ErrorMessage = "Status is required")]
            [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
            public string Status { get; set; } = string.Empty;

            [Required(ErrorMessage = "Feedback is required")]
            [StringLength(500, ErrorMessage = "500 Max letters are allowed")]
            public string Feedback { get; set; } = string.Empty;

            public JobApplication? Application { get; set; }
        }
    }