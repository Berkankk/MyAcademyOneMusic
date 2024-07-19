using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultTopSingersComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
