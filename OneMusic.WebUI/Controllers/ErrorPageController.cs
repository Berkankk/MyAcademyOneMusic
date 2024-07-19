using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult AccessDenied()  //Yetkisi olmayan kişlerde 403 hatası aldırdık 
        {
            return View();
        }

        public IActionResult Error404() 
        {
            return View();
        }
    }
}
