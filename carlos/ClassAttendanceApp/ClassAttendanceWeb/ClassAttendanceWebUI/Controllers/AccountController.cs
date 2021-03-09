using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendanceCommon.Interfaces;
using ClassAttendanceWebUI.Models;
using ClassAttendanceWebUI.Services;
using Microsoft.Extensions.Logging;

namespace ClassAttendanceWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly INativeAuthenticationService _authenticationService;

        public AccountController(INativeAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            var model = new LoginModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authenticationService.SignIn(this.HttpContext, model.Email, model.Password);

            if (result.Success)
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                model.Error = result.Error;
                return View(model);
            }
        }


        public async Task<IActionResult> Logout()
        {
            await _authenticationService.SignOut(this.HttpContext);

            return Redirect("/");
        }
    }
}
