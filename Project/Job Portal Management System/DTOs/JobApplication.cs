using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.DTOs
{
    public class JobApplicationDto
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required(ErrorMessage = "JobId is required")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "ApplicantId is required")]
        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "RecruitmentStageId is required")]
        public int RecruitmentStageId { get; set; }

        [Required(ErrorMessage = "Application date is required")]
        public DateTime ApplicationDate { get; set; }
    }
}