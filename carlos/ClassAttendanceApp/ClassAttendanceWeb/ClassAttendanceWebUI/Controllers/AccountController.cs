﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendanceCommon.Interfaces;
using ClassAttendanceWebUI.Models;
using ClassAttendanceWebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ClassAttendanceWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly INativeAuthenticationService _authenticationService;
        private readonly IApplicationUserRepository _userRepository;

        public AccountController(
            INativeAuthenticationService authenticationService,
            IApplicationUserRepository userRepository)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Secret()
        {
            var model = new SecretModel
            {
                Users = _userRepository.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userRepository.Add(model.ToApplicationUser());

            
            return LocalRedirect("/");
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
