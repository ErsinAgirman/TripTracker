using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TripTrackerCore.Models;

namespace TripTrackerWeb.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<Staff> _userManager;

		public DefaultController(UserManager<Staff> userManager)
		{
			_userManager = userManager;
		}

		public async Task <IActionResult> Index()
        {
			var userId = _userManager.GetUserId(User); // Giriş yapan kullanıcının ID'si
													   // Bu ID'yi View'a gönder
			ViewBag.UserId = userId;
			return View();
        }
    }
}
