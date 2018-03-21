using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace LandingPage.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HtmlTypesController : Controller
    {   [Route("admin/HtmlTypes/getall")]
        public JsonResult GetAll()
        {
            var _repo = new HtmlTypesManager();
            return Json(new { data = _repo.GetAll() });
        }

        [Route("admin/HtmlTypes/deleteItem")]
        public JsonResult Delete(int id)
        {
            var _repo = new HtmlTypesManager();
            var item = _repo.GetById(id);
            if (item.Id > 0)
            {
                _repo.Delete(item.Id);
                return Json(true);
            }
            else return Json(false);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}