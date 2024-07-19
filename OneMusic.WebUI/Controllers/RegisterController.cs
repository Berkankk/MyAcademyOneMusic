using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Models;

namespace OneMusic.WebUI.Controllers
{
    [AllowAnonymous] // authorizedan muaf tuttuk bununla
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(RegisterViewModel model)
        {
            AppUser user = new AppUser //direkt modeli versek hata alıyorduk appuser türünde nesne beklemesinin sebebi=== yukarıda constr da appuser verdik diye.
            {
                Email = model.Email,
                UserName = model.UserName,
                Surname = model.Surname,
                Name = model.Name,
                // identity burada bizim yerimize şifreyi doğruluyor ve farklı bir formatta veri tabanına kaydediyor
            };

            if(model.Password == model.ConfirmPassword)// eğerki girilen iki şifrede eşitse bu aralıkta işlemlerini gerçekleştir
            {
                var result = await _userManager.CreateAsync(user, model.Password);  // asenkron metotların başına await koyarız user vermemizin sebebi ise modelden gelen değeri yakalasın model password da bu işlemi sorguluyor
                if (result.Succeeded) //sonuç başarılı olursa
                {
                    await _userManager.AddToRoleAsync(user, "Visitor");
                    return RedirectToAction("Index", "Login"); // başarılı olursa login sayfasının indexine yönlendir 
                }
                foreach (var item in result.Errors)  // eğer hata alırsa buraya gir ve hatalar içinde dön
                {
                    ModelState.AddModelError("", item.Description); // hatanın açıklamasını modelstate ekledik burada 
                }
            }
            



           

           
          
            return View();  //bu sayfayı bize tekrar  geri dön 
        }

    }
}
