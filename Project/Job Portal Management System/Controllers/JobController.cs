using Job_Portal_Management_System.DTOs;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService service;

        public JobController(IJobService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = service.GetAll();

            var result = jobs.Select(j => new JobDto
            {
                JobId = j.JobId,
                JobTitle = j.JobTitle,
                Description = j.Description,
                Skills = j.Skills,
                Salary = j.Salary,
                Location = j.Location,
                Experience = j.Experience,
                JobType = j.JobType,
                CompanyId = j.CompanyId
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var job = service.GetById(id);

            if (job == null)
            {
                return NotFound("Job not found");
            }

            var result = new JobDto
            {
                JobId = job.JobId,
                JobTitle = job.JobTitle,
                Description = job.Description,
                Skills = job.Skills,
                Salary = job.Salary,
                Location = job.Location,
                Experience = job.Experience,
                JobType = job.JobType,
                CompanyId = job.CompanyId
            };

            return Ok(result);
        }

        [HttpGet("company/{companyId}")]
        public IActionResult GetByCompanyId(int companyId)
        {
            var jobs = service.GetByCompanyId(companyId);

            var result = jobs.Select(j => new JobDto
            {
                JobId = j.JobId,
                JobTitle = j.JobTitle,
                Description = j.Description,
                Skills = j.Skills,
                Salary = j.Salary,
                Location = j.Location,
                Experience = j.Experience,
                JobType = j.JobType,
                CompanyId = j.CompanyId
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(JobDto dto)
        {
            var job = new Job
            {
                JobTitle = dto.JobTitle,
                Description = dto.Description,
                Skills = dto.Skills,
                Salary = dto.Salary,
                Location = dto.Location,
                Experience = dto.Experience,
                JobType = dto.JobType,
                CompanyId = dto.CompanyId
            };

            service.Add(job);

            return Ok("Job created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            JobDto dto)
        {
            var job = service.GetById(id);

            if (job == null)
            {
                return NotFound("Job not found");
            }

            job.JobTitle = dto.JobTitle;
            job.Description = dto.Description;
            job.Skills = dto.Skills;
            job.Salary = dto.Salary;
            job.Location = dto.Location;
            job.Experience = dto.Experience;
            job.JobType = dto.JobType;
            job.CompanyId = dto.CompanyId;

            service.Update(job);

            return Ok("Job updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var job = service.GetById(id);

            if (job == null)
            {
                return NotFound("Job not found");
            }

            service.Delete(id);

            return Ok("Job deleted successfully");
        }
    }
}