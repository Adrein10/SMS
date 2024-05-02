using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System.Diagnostics;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SMSContext context;

        public HomeController(ILogger<HomeController> logger,SMSContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            CustomStudentReg newdata = new CustomStudentReg
            {
                CstudentReg = new StudentReg(),
                Courselist = context.Courses.ToList()
            };
            return View(newdata);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}