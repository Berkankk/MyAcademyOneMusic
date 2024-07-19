using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AdminAlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IActionResult Index()
        {
            
            var value = _albumService.TGetList();
            return View(value);
        }
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateAlbum()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAlbum(Album album)
        {
            _albumService.TCreate(album);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAlbum(int id)
        {
            var value = _albumService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAlbum(Album album)
        {
            _albumService.TUpdate(album);
            return RedirectToAction("Index");
        }
    }
}
