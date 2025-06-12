using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers
{
    public class SedesController : Controller
    {
        public IActionResult VerSedes()
        {
            return View();
        }

        public IActionResult VerHabitacionesSedePrincipal()
        {
            return View();
        }
    }
}
