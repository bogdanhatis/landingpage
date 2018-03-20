using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using DBModels;

namespace LandingPage.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MenuItemController : Controller
    {

        [Route("admin/menuitem/getall")]
        public JsonResult GetAll()
        {
            var all = new MenuItemManager().GetAll();
            return Json(new { data = all });
        }
        [Route("admin/menuitem/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}