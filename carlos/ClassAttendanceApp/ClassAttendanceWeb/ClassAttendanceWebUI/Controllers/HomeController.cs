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
using ClassAttendanceWebUI.Services;
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
        
        [Authorize]
        public IActionResult Secret()
        {
            var model = new SecretModel
            {
                Users = _userRepo.GetAll()
            };

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
