using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using ML.Mapper;

namespace UIL.Controllers
{
    public class AccountVerificationController : Controller
    {
		private readonly ILogger _logger;
        private readonly IRegistrationService _registrationService;
		public AccountVerificationController(ILogger<AccountVerificationController> logger, IRegistrationService registrationService)
        {
			_logger = logger;
            _registrationService = registrationService;
		}
        #region Get
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
        #endregion

      //   #region Post
      //   [HttpPost]
      //   [ValidateAntiForgeryToken]
      //   public async Task<IActionResult> Login(LoginModel model)
      //   {
      //       if (ModelState.IsValid)
      //       {
      //           var userFromModel = _mapper.Map<AuthUserModel, User>(model.User);
      //           var user = AccountController.GetUser(userFromModel);
      //           if (user != null)
      //           {
      //               if (AccountController.CheckUser(user))
      //               {
      //                   Console.WriteLine(user.EMail);
      //                   await Authenticate(user);
      //                   _logger.LogInformation($"Пользователь вошел под EMail: {model.User.Email}");
      //
						// return RedirectToAction("Index", "Home");
      //               }
      //               
      //           }
      //           ModelState.AddModelError("", "Некорректные логин и(или) пароль");
      //       }
      //       return View("Autentification", model);
      //   }

      //   [HttpPost]
      //   [ValidateAntiForgeryToken]
      //   public async Task<IActionResult> Register(RegisterModel model)
      //   {
      //       await Console.Out.WriteLineAsync(model.User.Email + "\t" + model.User.Password);
      //       if (ModelState.IsValid)
      //       {
      //           var userFromModel = _mapper.Map<AuthUserModel, User>(model.User);
      //
      //           var user = AccountController.GetUser(userFromModel);
      //           if (user == null)
      //           {
      //               if (AccountController.Create(userFromModel))
      //               {
      //                   await Authenticate(userFromModel);
						// _logger.LogInformation($"Пользователь зарегистрировался под EMail: {model.User.Email}");
						// return RedirectToAction("Index", "Home");
      //               }
      //               else
      //               {
      //                   ModelState.AddModelError("", "Некорректные логин и(или) пароль");
      //               }
      //           }
      //           else
      //           {
      //               ModelState.AddModelError("", "Некорректные логин и(или) пароль");
      //           }
      //       }
      //       return View("Registration", model);
      //   }
      //   #endregion

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
          
      }
      
        // private async Task Authenticate(User user)
        // {
        //     var claims = new List<Claim>
        //     {
        //         new Claim(ClaimTypes.Email, user.EMail),
        //         new Claim(ClaimTypes.Role, user.Role)
        //     };
        //
        //     ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //
        //     var principal = new ClaimsPrincipal(id);
        //
        //     await HttpContext.SignInAsync(
        //         CookieAuthenticationDefaults.AuthenticationScheme,
        //         principal,
        //         new AuthenticationProperties()
        //         {
        //             IsPersistent = true,
        //         });
        // }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
