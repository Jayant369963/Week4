using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Week4.Models;

namespace Week4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NavigateToPrivacyPage()
        {
            return View(nameof(Privacy));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("students"), ProducesResponseType(typeof(StudentModel), 200)]
        public List<StudentModel> GetStudents()
        {
            var students = new List<StudentModel>
            {
                new StudentModel { StudentName = "Student1", UniversityName = "UNiversity1" },
                new StudentModel { StudentName = "Student2", UniversityName = "UNiversity2" }
            };
            return students;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}