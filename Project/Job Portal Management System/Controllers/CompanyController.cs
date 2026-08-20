using Job_Portal_Management_System.DTOs;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        // GET: api/Company
        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = service.GetAll();

            var result = companies.Select(c => new CompanyDto
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName,
                Email = c.Email,
                Phone = c.Phone,
                Location = c.Location
            }).ToList();

            return Ok(result);
        }

        // GET: api/Company/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = service.GetById(id);

            if (company == null)
            {
                return NotFound("Company not found");
            }

            var result = new CompanyDto
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                Email = company.Email,
                Phone = company.Phone,
                Location = company.Location
            };

            return Ok(result);
        }

        // POST: api/Company
        [HttpPost]
        public IActionResult Create(CompanyDto dto)
        {
            var company = new Company
            {
                CompanyName = dto.CompanyName,
                Email = dto.Email,
                Phone = dto.Phone,
                Location = dto.Location
            };

            service.Add(company);

            return Ok("Company created successfully");
        }

        // PUT: api/Company/1
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            CompanyDto dto)
        {
            var company = service.GetById(id);

            if (company == null)
            {
                return NotFound("Company not found");
            }

            company.CompanyName = dto.CompanyName;
            company.Email = dto.Email;
            company.Phone = dto.Phone;
            company.Location = dto.Location;

            service.Update(company);

            return Ok("Company updated successfully");
        }

        // DELETE: api/Company/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = service.GetById(id);

            if (company == null)
            {
                return NotFound("Company not found");
            }

            service.Delete(id);

            return Ok("Company deleted successfully");
        }
    }
}