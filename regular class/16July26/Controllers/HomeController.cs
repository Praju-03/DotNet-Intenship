using _16July26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _16July26.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>
    {
        new Student
        {
            Id = 1,
            Name = "Prajwal",
            Age = 20,
            Gender = "Male",
            Qualification = "B.Tech",
            Course = "CSE"
        },
        new Student
        {
            Id = 2,
            Name = "Rahul",
            Age = 21,
            Gender = "Male",
            Qualification = "B.Tech",
            Course = ".Net"
        },


                new Student
                {
                    Id = 3,
                    Name = "Shweta",
                    Age = 22,
                    Gender = "Female",
                    Qualification = "B.Sc",
                    Course = "Python"
                }
          };

            return View(students);
        }

    }
}
