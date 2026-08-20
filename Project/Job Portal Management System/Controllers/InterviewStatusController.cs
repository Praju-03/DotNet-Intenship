using Job_Portal_Management_System.DTOs;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewStatusController : ControllerBase
    {
        private readonly IInterviewStatusService service;

        public InterviewStatusController(
            IInterviewStatusService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var interviews = service.GetAll();

            var result = interviews.Select(i =>
                new InterviewStatusDto
                {
                    InterviewId = i.InterviewId,

                    ApplicationId =
                        i.ApplicationId,

                    InterviewDate =
                        i.InterviewDate,

                    InterviewType =
                        i.InterviewType,

                    Status = i.Status,

                    Feedback = i.Feedback
                }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var interview =
                service.GetById(id);

            if (interview == null)
            {
                return NotFound(
                    "Interview not found");
            }

            return Ok(new InterviewStatusDto
            {
                InterviewId =
                    interview.InterviewId,

                ApplicationId =
                    interview.ApplicationId,

                InterviewDate =
                    interview.InterviewDate,

                InterviewType =
                    interview.InterviewType,

                Status =
                    interview.Status,

                Feedback =
                    interview.Feedback
            });
        }

        [HttpGet("application/{applicationId}")]
        public IActionResult GetByApplicationId(
            int applicationId)
        {
            var interview =
                service.GetByApplicationId(
                    applicationId);

            if (interview == null)
            {
                return NotFound(
                    "Interview not found");
            }

            return Ok(new InterviewStatusDto
            {
                InterviewId =
                    interview.InterviewId,

                ApplicationId =
                    interview.ApplicationId,

                InterviewDate =
                    interview.InterviewDate,

                InterviewType =
                    interview.InterviewType,

                Status =
                    interview.Status,

                Feedback =
                    interview.Feedback
            });
        }

        [HttpPost]
        public IActionResult Create(
            InterviewStatusDto dto)
        {
            var interview = new InterviewStatus
            {
                ApplicationId =
                    dto.ApplicationId,

                InterviewDate =
                    dto.InterviewDate,

                InterviewType =
                    dto.InterviewType,

                Status =
                    dto.Status,

                Feedback =
                    dto.Feedback
            };

            service.Add(interview);

            return Ok(
                "Interview created successfully"
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            InterviewStatusDto dto)
        {
            var interview =
                service.GetById(id);

            if (interview == null)
            {
                return NotFound(
                    "Interview not found");
            }

            interview.ApplicationId =
                dto.ApplicationId;

            interview.InterviewDate =
                dto.InterviewDate;

            interview.InterviewType =
                dto.InterviewType;

            interview.Status =
                dto.Status;

            interview.Feedback =
                dto.Feedback;

            service.Update(interview);

            return Ok(
                "Interview updated successfully"
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var interview =
                service.GetById(id);

            if (interview == null)
            {
                return NotFound(
                    "Interview not found");
            }

            service.Delete(id);

            return Ok(
                "Interview deleted successfully"
            );
        }
    }
}