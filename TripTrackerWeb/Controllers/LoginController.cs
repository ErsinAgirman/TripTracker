using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;
using TripTrackerWeb.Models;

namespace TripTrackerWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
		private readonly UserManager<Staff> _userManager;
		private readonly SignInManager<Staff> _signInManager;

		public LoginController(UserManager<Staff> userManager, SignInManager<Staff> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterDto p)
		{
			if (!ModelState.IsValid)
			{
				// Model doğrulama hataları varsa, formu tekrar göster
				return View(p);
			}



			// Şifreyi doğrula
			List<string> passwordErrors;
			bool isPasswordValid = PasswordValidator.ValidatePassword(p.Password, out passwordErrors);

			if (!isPasswordValid)
			{
				foreach (var error in passwordErrors)
				{
					ModelState.AddModelError("", error);
				}

				return View(p);
			}

			Staff staff = new Staff()
			{
				Name = p.Name,
				Surname = p.Surname,
				Email = p.Mail,
				UserName = p.Username,
				AdminId = p.AdminId,
				isAdmin = false,
				Active = true
			};

			if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(staff, p.Password);

				if (result.Succeeded)
				{
					// Kullanıcı başarıyla kaydoldu
					TempData["SuccessMessage"] = "Kayıt başarılı!";
					return RedirectToAction("SignIn");
				}
				else
                {
                    foreach(var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
                }
            }

            return View(p);
		}
		
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}




	}
}
