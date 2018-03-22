using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBModels;
using LandingPage.Models.CMSViewModels;
using Service;

namespace LandingPage.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CMSController : Controller
    {

        [Route("admin/cms/getall")]
        public JsonResult GetAll()
        {
            var all = new CMSManager().GetAll();
            return Json(new { data = all });
        }
        [Route("admin/cms")]
        public IActionResult Index()
        {
            var all = new CMSManager().GetAll();
            return View(all);
        }



        [Route("admin/cms/deleteItem")]
        public JsonResult DeleteItem(int ItemId)
        {
            var _cmsItemManager = new CMSManager();
            var item = _cmsItemManager.GetById(ItemId);
            if (item.Id > 0)
            {
                _cmsItemManager.Delete(ItemId);

                return Json(true);
            }
            else
                return Json(false);
        }

        [Route("admin/cms/createItem")]
        [HttpGet]
        public IActionResult Create(int id)
        {
            var viewModel = new CMSViewModels();
            if (id > 0)
            {
                viewModel = (CMSViewModels)(new CMSManager().GetById(id));
            }

            return View(viewModel);

        }
        [Route("admin/cms/createItem")]
        [HttpPost]
        public IActionResult Create(CMSViewModels item)
        {
            if (ModelState.IsValid)
            {
                if (item.Id > 0)

                    new CMSManager().Update(new CMSViewModels().Transform(item));
                else
                    new CMSManager().Create(new CMSViewModels().Transform(item));

                return RedirectToAction("Index");
            }
            return View(item);
        }
        
    }
}