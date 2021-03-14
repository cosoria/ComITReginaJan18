using System.Linq;
using ClassAttendance.Common.Interfaces;
using ClassAttendance.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var students = _repository.GetAll();

            var model = new StudentViewModel(students);
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _repository.GetOne(id);

            var model = new StudentUpdateViewModel(student);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(StudentUpdateViewModel model)
        {
            var student = _repository.GetOne(model.Id);

            if (student == null)
            {
                //ModelState.AddModelError("all","Student not found");
                return View(model);
            }

            student.NameChange(model.FirstName, model.LastName);

            _repository.Update(student);

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Enroll()
        {
            return View();
        }
    }
}
