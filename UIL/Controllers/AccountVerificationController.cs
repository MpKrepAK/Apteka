using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ML.Mapper;
using IAuthenticationService = BLL.Services.Interfaces.IAuthenticationService;
using IAuthorizationService = BLL.Services.Interfaces.IAuthorizationService;

namespace UIL.Controllers
{
    public class AccountVerificationController : Controller
    {
		private readonly ILogger _logger;
        private readonly IRegistrationService _registrationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IAuthenticationService _authenticationService;
		public AccountVerificationController(ILogger<AccountVerificationController> logger, 
            IRegistrationService registrationService,
            IAuthorizationService authorizationService,
            IAuthenticationService authenticationService)
        {
			_logger = logger;
            _registrationService = registrationService;
            _authorizationService = authorizationService;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        public IActionResult Autentification()
        {
            return View("Autentification");
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View("Registration");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration user)
      {
          if (ModelState.IsValid)
          {
              var result = await _registrationService.RegisterUser(user);

              if (!result)
              {
                  return View("Registration");
              }

              return RedirectToAction("","Home");
          }
          _logger.LogInformation("Пользователь зарегистрировался под EMail:\t"+user.EMail);
          return View("Registration");
      }

        [HttpPost]
        public async Task<IActionResult> Authenticate(UserAuth user)
        {
            var identity = await _authenticationService.AuthenticateUser(user);

            if (identity == null)
            {
                return View("Autentification");
            }
            
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties()
                {
                    IsPersistent = true,
                });
            _logger.LogInformation("Пользователь вошел под EMail:\t"+user.EMail);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("Пользователь вышел под EMail:\t"+User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.Email).Value);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
