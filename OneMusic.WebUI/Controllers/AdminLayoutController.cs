using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminLayoutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult>  Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);//giriş yapan kişinin bilgilerini viewbage buradan atayacağız.

            ViewBag.username = user.Name + "" + user.Surname;
            return View();
            //Admin layoutun indexinde burası tanımlı kullanıcı girdiği zaman buradan kimin girdiğini görebileceğiz.
        }
    }
}
