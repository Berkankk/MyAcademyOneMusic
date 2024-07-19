using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Models;

namespace OneMusic.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAssignController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                // Kullanıcı bulunamadıysa hata mesajı gösterebiliriz
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Index");
            }

            TempData["userid"] = user.Id;

            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> roleAssignList = new List<RoleAssignViewModel>();

            foreach (var item in roles)
            {
                var model = new RoleAssignViewModel
                {
                    RoleId = item.Id,
                    RoleName = item.Name,
                    RoleExist = userRoles.Contains(item.Name)
                };
                roleAssignList.Add(model);
            }

            return View(roleAssignList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            if (TempData["userid"] == null)
            {
                // Eğer TempData["userid"] null ise hata mesajı gösterebiliriz
                TempData["ErrorMessage"] = "User ID not found.";
                return RedirectToAction("Index");
            }

            int userid = (int)TempData["userid"];
            var user = await _userManager.FindByIdAsync(userid.ToString());

            if (user == null)
            {
                // Kullanıcı bulunamadıysa hata mesajı gösterebiliriz
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Index");
            }

            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
