using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.Models
{
    public class RecruitmentStage
    {
        [Key]
        public int RecruitmentStageId { get; set; }

        [Required(ErrorMessage = "Stage name is required")]
        [StringLength(50, ErrorMessage = "50 Max letters are required")]
        public string StageName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Stage order is required")]
        public int StageOrder { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "200 Max letters are required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [StringLength(30, ErrorMessage = "30 Max letters are required")]
        public string Status { get; set; } = string.Empty;

        public ICollection<JobApplication> Applications { get; set; }
           = new List<JobApplication>();
    }
}