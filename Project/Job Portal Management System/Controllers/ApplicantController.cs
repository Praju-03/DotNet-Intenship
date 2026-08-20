using Job_Portal_Management_System.DTOs;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService service;

        public ApplicantController(IApplicantService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var applicants = service.GetAll();

            var result = applicants.Select(a => new ApplicantDto
            {
                ApplicantId = a.ApplicantId,
                Name = a.Name,
                Email = a.Email,
                Phone = a.Phone,
                Skills = a.Skills,
                Education = a.Education,
                Resume = a.Resume
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var applicant = service.GetById(id);

            if (applicant == null)
            {
                return NotFound("Applicant not found");
            }

            var result = new ApplicantDto
            {
                ApplicantId = applicant.ApplicantId,
                Name = applicant.Name,
                Email = applicant.Email,
                Phone = applicant.Phone,
                Skills = applicant.Skills,
                Education = applicant.Education,
                Resume = applicant.Resume
            };

            return Ok(result);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var applicant = service.GetByEmail(email);

            if (applicant == null)
            {
                return NotFound("Applicant not found");
            }

            return Ok(new ApplicantDto
            {
                ApplicantId = applicant.ApplicantId,
                Name = applicant.Name,
                Email = applicant.Email,
                Phone = applicant.Phone,
                Skills = applicant.Skills,
                Education = applicant.Education,
                Resume = applicant.Resume
            });
        }

        [HttpPost]
        public IActionResult Create(ApplicantDto dto)
        {
            var existingApplicant =
                service.GetByEmail(dto.Email);

            if (existingApplicant != null)
            {
                return BadRequest(
                    "Applicant with this email already exists."
                );
            }

            var applicant = new Applicant
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Skills = dto.Skills,
                Education = dto.Education,
                Resume = dto.Resume
            };

            service.Add(applicant);

            return Ok("Applicant created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            ApplicantDto dto)
        {
            var applicant = service.GetById(id);

            if (applicant == null)
            {
                return NotFound("Applicant not found");
            }

            applicant.Name = dto.Name;
            applicant.Email = dto.Email;
            applicant.Phone = dto.Phone;
            applicant.Skills = dto.Skills;
            applicant.Education = dto.Education;
            applicant.Resume = dto.Resume;

            service.Update(applicant);

            return Ok("Applicant updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var applicant = service.GetById(id);

            if (applicant == null)
            {
                return NotFound("Applicant not found");
            }

            service.Delete(id);

            return Ok("Applicant deleted successfully");
        }
    }
}