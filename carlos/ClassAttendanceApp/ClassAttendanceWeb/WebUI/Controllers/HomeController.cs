using System.Diagnostics;
using ClassAttendance.Common.Interfaces;
using ClassAttendance.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationUserRepository _userRepo;

        public HomeController(IApplicationUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        
        public IActionResult Index()
        {
            var model = new HomePageModel();

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                model.PopulateFrom(User);
            }

            return View(model);
        }
        
        

        public IActionResult Privacy()
        {
            var users = _userRepo.GetAll();

            return View(users);
        }
       
        public IActionResult About()
        {
            return View();
        }

        public IActionResult GitHub(string returnUrl = "/")
        {
            return new ChallengeResult("GitHub", new AuthenticationProperties() { RedirectUri = returnUrl });
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
