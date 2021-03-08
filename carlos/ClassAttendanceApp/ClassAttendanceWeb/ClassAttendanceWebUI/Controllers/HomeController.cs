using ClassAttendanceWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassAttendanceCommon.Interfaces;
using ClassAttendanceData.Repositories;
using ClassAttendanceDomain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClassAttendanceWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [Inject]
        public ILogger Logger { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            if (username == "carlos" && password == "osoria")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                
                await HttpContext.SignInAsync(principal);
                
                return Redirect(returnUrl);
            }
            else
            {
                ViewBag.LoginFailed = true;
                ViewData["loginfailed"] = true;
                ViewBag.ReturnUrl = returnUrl;
                ViewData["returlurl"] = returnUrl;

                return View("Index"); 
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return View();
        }

        public IActionResult Privacy([FromServices] IStudentRepository repository)
        {
            var users = GetUsers(repository);

            return View(users);
        }


        private IEnumerable<ApplicationUser> GetUsers(IStudentRepository repository)
        {
            var repo = new ApplicationUserRepository();

            return repo.GetAll();
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
