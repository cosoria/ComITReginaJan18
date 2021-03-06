using ClassAttendanceWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

        public IActionResult Privacy()
        {
            var users = GetUsers();

            return View(users);
        }


        private List<ApplicationUser> GetUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    FirstName = "Optimus", LastName = "Prime", Language = "Cybertronian", Email = "optimus@cybertron.com"
                },
                new ApplicationUser()
                {
                    FirstName = "Bumble", LastName = "Bee", Language = "Cybertronian", Email = "bumblebee@cybertron.com"
                },
                new ApplicationUser()
                {
                    FirstName = "Iron", LastName = "Hide", Language = "Cybertronian", Email = "ironhide@cybertron.com"
                },
                new ApplicationUser()
                {
                    FirstName = "Mega", LastName = "Tron", Language = "Cybertronian", Email = "megatron@cybertron.com"
                },
                new ApplicationUser()
                {
                    FirstName = "Shock", LastName = "Wave", Language = "Cybertronian", Email = "shockwave@cybertron.com"
                },
            };
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
