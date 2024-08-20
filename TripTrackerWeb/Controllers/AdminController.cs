using Microsoft.AspNetCore.Mvc;

namespace TripTrackerWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAdmin()
        {
            return View();
        }
        public IActionResult UpdateAdmin()
        {
            return View();
        }
        public IActionResult DeleteAdmin()
        {
            return View();
        }
    }
}
