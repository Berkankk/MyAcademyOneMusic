using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbar : ViewComponent
    {
        //burası aynı controller gibi çalışıyor.
        private readonly UserManager<AppUser> _userManager;

        public _AdminLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.username = value.Name + "  " + value.Surname;
            return View();
        }
    }
}
