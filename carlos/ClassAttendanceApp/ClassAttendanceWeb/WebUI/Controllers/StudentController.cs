using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.WebUI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
