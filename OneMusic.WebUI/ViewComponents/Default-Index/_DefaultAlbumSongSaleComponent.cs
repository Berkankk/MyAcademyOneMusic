using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.DataAccessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultAlbumSongSaleComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
