using Microsoft.AspNetCore.Mvc;

namespace Projet2.Controllers
{
    public class TicketingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
