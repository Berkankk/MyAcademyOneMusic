using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultAlbumComponent : ViewComponent
    {
        private readonly IAlbumService _albumService;

        public _DefaultAlbumComponent(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _albumService.TGetAlbumswithArtist();
            return View(value);
        }
    }
}
