using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
