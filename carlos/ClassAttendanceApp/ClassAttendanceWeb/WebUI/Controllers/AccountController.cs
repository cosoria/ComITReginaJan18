using System.Threading.Tasks;
using ClassAttendance.Common.Interfaces;
using ClassAttendance.WebUI.Models;
using ClassAttendance.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.WebUI.Controllers
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
            var model = new SecretViewModel
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
        public IActionResult Register(RegisterViewModel model)
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
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
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
