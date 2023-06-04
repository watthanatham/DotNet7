using CVC.Data;
using CVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable <Student> allStudent = _db.Students;

            return View(allStudent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertStudent(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}
