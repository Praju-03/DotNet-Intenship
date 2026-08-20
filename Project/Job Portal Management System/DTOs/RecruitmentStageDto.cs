using System.ComponentModel.DataAnnotations;

namespace Job_Portal_Management_System.DTOs
{
    public class RecruitmentStageDto
    {
        public int RecruitmentStageId { get; set; }

        [Required, StringLength(100)]
        public string StageName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "StageOrder must be positive")]
        public int StageOrder { get; set; }
    }
}