﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Dashboard : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
