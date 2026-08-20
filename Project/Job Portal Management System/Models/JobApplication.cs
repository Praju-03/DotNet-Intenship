using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.Models
{
    public class JobApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required(ErrorMessage = "Job ID is required")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "Applicant ID is required")]
        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "Recruitment Stage ID is required")]
        public int RecruitmentStageId { get; set; }

        [Required(ErrorMessage = "Application date is required")]
        public DateTime ApplicationDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(30, ErrorMessage = "30 Max letters are allowed")]
        public string Status { get; set; } = string.Empty;

        // Navigation properties
        public Job? Jobs { get; set; }

        public Applicant? Applicant { get; set; }

        public RecruitmentStage? RecruitmentStage { get; set; }

        // Interview information
        public InterviewStatus? InterviewStatus { get; set; }
    }
}