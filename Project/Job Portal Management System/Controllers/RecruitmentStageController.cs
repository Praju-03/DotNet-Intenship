using Job_Portal_Management_System.DTOs;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitmentStageController
        : ControllerBase
    {
        private readonly IRecruitmentStageService service;

        public RecruitmentStageController(
            IRecruitmentStageService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stages = service.GetAll();

            var result = stages.Select(s =>
                new RecruitmentStageDto
                {
                    RecruitmentStageId =
                        s.RecruitmentStageId,

                    StageName =
                        s.StageName,

                    Description =
                        s.Description,

                    StageOrder =
                        s.StageOrder
                }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var stage =
                service.GetById(id);

            if (stage == null)
            {
                return NotFound(
                    "Recruitment stage not found");
            }

            return Ok(new RecruitmentStageDto
            {
                RecruitmentStageId =
                    stage.RecruitmentStageId,

                StageName =
                    stage.StageName,

                Description =
                    stage.Description,

                StageOrder =
                    stage.StageOrder
            });
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(
            string name)
        {
            var stage =
                service.GetByName(name);

            if (stage == null)
            {
                return NotFound(
                    "Recruitment stage not found");
            }

            return Ok(new RecruitmentStageDto
            {
                RecruitmentStageId =
                    stage.RecruitmentStageId,

                StageName =
                    stage.StageName,

                Description =
                    stage.Description,

                StageOrder =
                    stage.StageOrder
            });
        }

        [HttpPost]
        public IActionResult Create(
            RecruitmentStageDto dto)
        {
            var stage = new RecruitmentStage
            {
                StageName =
                    dto.StageName,

                Description =
                    dto.Description,

                StageOrder =
                    dto.StageOrder
            };

            service.Add(stage);

            return Ok(
                "Recruitment stage created successfully"
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            RecruitmentStageDto dto)
        {
            var stage =
                service.GetById(id);

            if (stage == null)
            {
                return NotFound(
                    "Recruitment stage not found");
            }

            stage.StageName =
                dto.StageName;

            stage.Description =
                dto.Description;

            stage.StageOrder =
                dto.StageOrder;

            service.Update(stage);

            return Ok(
                "Recruitment stage updated successfully"
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var stage =
                service.GetById(id);

            if (stage == null)
            {
                return NotFound(
                    "Recruitment stage not found");
            }

            service.Delete(id);

            return Ok(
                "Recruitment stage deleted successfully"
            );
        }
    }
}