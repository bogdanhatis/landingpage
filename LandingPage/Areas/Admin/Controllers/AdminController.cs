﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace LandingPage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}