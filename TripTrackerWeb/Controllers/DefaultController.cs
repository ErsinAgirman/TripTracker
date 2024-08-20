using Microsoft.AspNetCore.Mvc;

namespace TripTrackerWeb.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
