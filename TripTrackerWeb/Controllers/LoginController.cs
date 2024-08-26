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

		public LoginController(UserManager<Staff> userManager)
		{
			_userManager = userManager;
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

			Staff staff = new Staff()
			{
				Name = p.Name,
				Surname = p.Surname,
				Email = p.Mail,
				UserName = p.Username,
				AdminId = 53,
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
