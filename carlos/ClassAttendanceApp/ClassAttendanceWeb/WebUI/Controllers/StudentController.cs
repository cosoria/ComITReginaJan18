using System.Linq;
using ClassAttendance.Common.Interfaces;
using ClassAttendance.Domain;
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _repository.GetOne(id);
            var model = new StudentUpdateViewModel(student);

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(StudentUpdateViewModel model)
        {
            var student = _repository.GetOne(model.Id);

            if (student == null)
            {
                ViewBag.ErrorMessage = "Student not found";
                return View();
            }

            _repository.Delete(student.Id);

            return LocalRedirect("/student");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(StudentUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _repository.Add(model.ToStudent());

            return LocalRedirect("/student");
        }

        public IActionResult Enroll()
        {
            return View();
        }
    }
}
