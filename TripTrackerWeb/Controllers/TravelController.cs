using Microsoft.AspNetCore.Mvc;

namespace TripTrackerWeb.Controllers
{
    public class TravelController : Controller
    {
        public IActionResult Index()
        {      
            return View();
        }

        public IActionResult CreateTravel()
        {
            return View();
        }

        public IActionResult UpdateTravel()
        {
            return View();
        }

        public IActionResult DeleteTravel() 
        {
            return View();
        }
    }
}
