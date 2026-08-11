using _30July2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace _30July2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    CourseName = "C#"
                },

                new Course
                {
                    Id = 2,
                    CourseName = "ASP.NET"
                },

                new Course
                {
                    Id = 3,
                    CourseName = "SQL Server"
                }
            };

            return Ok(courses);
        }
    }
}