﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Areas.Artist.Models;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new ArtistEditViewModel
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Surname = user.Surname,
                ImageUrl = user.ImageUrl,
                UserName = user.UserName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ArtistEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);

            if (model.ImageFile != null) //ımage file boş değilse 
            {
                var resource = Directory.GetCurrentDirectory();  //Projemizin olduğu yer
                var extension = Path.GetExtension(model.ImageFile.FileName); //dosya uzantısı
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/" + imageName; //kaydedeceğimiz yer
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);
                user.ImageUrl = "/images/" + imageName;
            }

          

            user.Name = model.Name;
            user.PhoneNumber = model.PhoneNumber;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.UserName = model.UserName;

            var result = await _userManager.CheckPasswordAsync(user, model.OldPassword);
            if (result == true)
            {
                if (model.NewPassword != null && model.ConfirmPassword == model.NewPassword)
                {
                    var şifre = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (!şifre.Succeeded)
                    {
                        foreach (var item in şifre.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                            return View();
                        }
                    }
                }
                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            ModelState.AddModelError("", "Mevcut Şifreniz Hatalı");
            return View();
        }
    }
}
