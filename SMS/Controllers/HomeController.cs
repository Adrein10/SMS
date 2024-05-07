using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
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
        [HttpPost]
        public IActionResult Index(CustomStudentReg reg)
        {
            var show = reg;
            StudentReg student = new StudentReg()
            {
                StudentName = reg.CstudentReg.StudentName,
                StudentEmail = reg.CstudentReg.StudentEmail,
                Courseid = reg.CstudentReg.Courseid,
                StartDate = reg.CstudentReg.StartDate
            };
            context.StudentRegs.Add(student);
            context.SaveChanges();
            return RedirectToAction();
        }
        public IActionResult Studentlist()
        {
            var show = context.StudentRegs.Include(options => options.Course).ToList();
            return View(show);
        }
        public IActionResult Delete(int id)
        {
            CustomStudentReg newdata = new CustomStudentReg
            {
                CstudentReg = context.StudentRegs.Find(id),
                Courselist = context.Courses.ToList()
            };
            return View(newdata);
        }
        [HttpPost]
        public IActionResult Delete(CustomStudentReg studentReg,int id)
        {
            context.StudentRegs.Remove(studentReg.CstudentReg);
            context.SaveChanges();
            return RedirectToAction("Studentlist");
        }
        public IActionResult Update(int id)
        {
            CustomStudentReg newdata = new CustomStudentReg
            {
                CstudentReg = context.StudentRegs.Find(id),
                Courselist = context.Courses.ToList()
            };
            return View(newdata);
        }
        [HttpPost]
        public IActionResult Update(CustomStudentReg studentReg, int id)
        {
            var update = new StudentReg()
            {
                StudentName = studentReg.CstudentReg.StudentName,
                StudentEmail = studentReg.CstudentReg.StudentEmail,
                Courseid = studentReg.CstudentReg.Courseid,
                StartDate = studentReg.CstudentReg.StartDate
            };
            context.StudentRegs.Update(update);
            context.SaveChanges();
            return RedirectToAction("Studentlist");
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