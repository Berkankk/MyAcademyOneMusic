﻿using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultLatestAlbumComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
