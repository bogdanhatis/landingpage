using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBModels;
using LandingPage.Models.CMSDetailsViewModels;
using Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using test;

namespace LandingPage.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CMSDetailsController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public CMSDetailsController(IHostingEnvironment emv)
        {
            _hostingEnvironment = emv;
        }

        [Route("admin/cmsdetails/getall")]
        public JsonResult GetAll()
        {
            var all = new CMSDetailsManager().GetAll();
            return Json(new { data = all });
        }
        [Route("admin/cmsdetails")]
        public IActionResult Index()
        {
            var all = new CMSDetailsManager().GetAll();
            return View(all);
        }



        [Route("admin/cmsdetails/deleteItem")]
        public JsonResult DeleteItem(int ItemId)
        {
            var _cmsDetailsItemManager = new CMSDetailsManager();
            var item = _cmsDetailsItemManager.GetById(ItemId);
            if (item.Id > 0)
            {
                _cmsDetailsItemManager.Delete(ItemId);

                return Json(true);
            }
            else
                return Json(false);
        }

        [Route("admin/cmsdetails/createItem")]
        [HttpGet]
        public IActionResult Create(int id)

        {
            ViewBag.CMSId = new SelectList(new CMSManager().GetAll(), "Id", "Name");
            ViewBag.HtmlTypeId = new SelectList(new HtmlTypesManager().GetAll(), "Id", "Name");

            var viewModel = new CMSDetailsViewModels();
            if (id > 0)
            {
                viewModel = (CMSDetailsViewModels)(new CMSDetailsManager().GetById(id));
            }

            return View(viewModel);

        }

        [Route("admin/cmsdetails/createItem")]
        [HttpPost]
        public async Task<IActionResult> Create(CMSDetailsViewModels item, IFormFile FileUploadId)
        {
            var content = "";
            if (item.HtmlTypeId == 1)
            {
                content = item.ContentId;
            }
            else
                if (item.HtmlTypeId == 2)
            {
                content = item.TextAreaId;
            }
            else

                if (item.HtmlTypeId == 3)
            {
                content = item.HtmlEditorId;
            }
            else
            {
                if (item.FileUploadId != null)
                {
                    var filename = item.FileUploadId.FileName;
                    var path = Path.Combine(_hostingEnvironment.WebRootPath + "\\siteimages", filename);
                    var relpath = "/siteimages/" + filename;

                    content = relpath;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await item.FileUploadId.CopyToAsync(stream);
                    }
                }
            }
            ViewBag.CMSId = new SelectList(new CMSManager().GetAll(), "Id", "Name");
            ViewBag.HtmlTypeId = new SelectList(new HtmlTypesManager().GetAll(), "Id", "Name");
            item.Content = content;


            if (ModelState.IsValid)
            {
                if (item.Id > 0)
                {
                    if (string.IsNullOrWhiteSpace(item.Content))
                    {
                        var oldItem = new CMSDetailsManager().GetById(item.Id);
                        item.Content = oldItem.Content;
                    }
                    new CMSDetailsManager().Update(new CMSDetailsViewModels().Transform(item));
                }
                else
                    new CMSDetailsManager().Create(new CMSDetailsViewModels().Transform(item));

                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
