﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
