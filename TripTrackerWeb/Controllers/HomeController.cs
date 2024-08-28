using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TripTrackerCore.DTOs;
using TripTrackerCore.DTOs.UIDtos;
using TripTrackerCore.Models;
using TripTrackerWeb.Models;

namespace TripTrackerWeb.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly UserManager<Staff> _userManager;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, UserManager<Staff> userManager)
		{
			_logger = logger;
			_userManager = userManager;
		}
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound("Kullanıcı bulunamadı.");
			}


			var userProfile = new UserProfileDto
			{
				FirstName = user.Name,
				LastName = user.Surname,
				Email = user.Email,
				RegistrationDate = user.CreatedDate,
				AdminFirstName = user.Admin?.Name,
				AdminLastName = user.Admin?.Surname
			};

			return View(userProfile);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
