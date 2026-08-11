using _30July2026.Models;
using _30July2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace _30July2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _service.GetStudentByID(id);

            if (student == null)
                return NotFound("Student does not exist");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _service.AddStudent(student);
            return Ok("Student Added");
        }
    }
}