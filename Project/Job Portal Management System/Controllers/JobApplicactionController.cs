using Job_Portal_Management_System.DTOs;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService service;

        public JobApplicationController(
            IJobApplicationService service)
        {
            this.service = service;
        }

        // GET: api/JobApplication
        [HttpGet]
        public IActionResult GetAll()
        {
            var applications = service.GetAll();

            var result = applications.Select(a =>
                new JobApplicationDto
                {
                    ApplicationId = a.ApplicationId,
                    JobId = a.JobId,
                    ApplicantId = a.ApplicantId,
                    RecruitmentStageId =
                        a.RecruitmentStageId,
                    ApplicationDate =
                        a.ApplicationDate
                }).ToList();

            return Ok(result);
        }

        // GET: api/JobApplication/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var application =
                service.GetById(id);

            if (application == null)
            {
                return NotFound(
                    "Application not found");
            }

            var result = new JobApplicationDto
            {
                ApplicationId =
                    application.ApplicationId,

                JobId =
                    application.JobId,

                ApplicantId =
                    application.ApplicantId,

                RecruitmentStageId =
                    application.RecruitmentStageId,

                ApplicationDate =
                    application.ApplicationDate
            };

            return Ok(result);
        }

        // GET: api/JobApplication/applicant/1
        [HttpGet("applicant/{applicantId}")]
        public IActionResult GetByApplicantId(
            int applicantId)
        {
            var applications =
                service.GetByApplicantId(applicantId);

            var result = applications.Select(a =>
                new JobApplicationDto
                {
                    ApplicationId =
                        a.ApplicationId,

                    JobId = a.JobId,

                    ApplicantId =
                        a.ApplicantId,

                    RecruitmentStageId =
                        a.RecruitmentStageId,

                    ApplicationDate =
                        a.ApplicationDate
                }).ToList();

            return Ok(result);
        }

        // GET: api/JobApplication/job/1
        [HttpGet("job/{jobId}")]
        public IActionResult GetByJobId(int jobId)
        {
            var applications =
                service.GetByJobId(jobId);

            var result = applications.Select(a =>
                new JobApplicationDto
                {
                    ApplicationId =
                        a.ApplicationId,

                    JobId = a.JobId,

                    ApplicantId =
                        a.ApplicantId,

                    RecruitmentStageId =
                        a.RecruitmentStageId,

                    ApplicationDate =
                        a.ApplicationDate
                }).ToList();

            return Ok(result);
        }

        // POST: api/JobApplication
        [HttpPost]
        public IActionResult Apply(
            JobApplicationDto dto)
        {
            var application = new JobApplication
            {
                JobId = dto.JobId,

                ApplicantId = dto.ApplicantId,

                RecruitmentStageId =
                    dto.RecruitmentStageId,

                ApplicationDate =
                    DateTime.Now
            };

            try
            {
                service.Apply(application);

                return Ok(
                    "Job application submitted successfully"
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/JobApplication/1
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            JobApplicationDto dto)
        {
            var application =
                service.GetById(id);

            if (application == null)
            {
                return NotFound(
                    "Application not found");
            }

            application.JobId = dto.JobId;

            application.ApplicantId =
                dto.ApplicantId;

            application.RecruitmentStageId =
                dto.RecruitmentStageId;

            service.Update(application);

            return Ok(
                "Application updated successfully"
            );
        }

        // DELETE: api/JobApplication/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var application =
                service.GetById(id);

            if (application == null)
            {
                return NotFound(
                    "Application not found");
            }

            service.Delete(id);

            return Ok(
                "Application deleted successfully"
            );
        }
    }
}