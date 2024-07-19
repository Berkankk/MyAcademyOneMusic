using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
    [Area("Artist")]
    [Authorize(Roles = "Artist")] //Sadece rolü artist olanlar buraya erişebilir
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MyAlbumController(IAlbumService _albumService, UserManager<AppUser> _userManager) : Controller //Primary Constructor
    {

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userid = user.Id;
            var values = _albumService.TGetAlbumsByArtist(userid);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAlbum()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbum(Album album)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            album.AppUserID = user.Id;

            _albumService.TCreate(album);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAlbum(int id)
        {
            _albumService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAlbum(int id)
        {
            var value = _albumService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            var müzik = await _userManager.FindByNameAsync(User.Identity.Name);
            album.AppUserID = müzik.Id;
            _albumService.TUpdate(album);
            return RedirectToAction("Index"); 
        }
    }
}
