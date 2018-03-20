using DBModels;
using test.Models.MenuItemViewModels;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Threading.Tasks;

namespace test.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MenuItemsController : Controller
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
            var all = new MenuItemManager().GetAll();
            return View(all);
        }


            [Route("admin/menuitem/deleteItem")]
    
    public JsonResult DeleteItem(int ItemId)
    {
        var _menuItemManager = new MenuItemManager();
        var item =  _menuItemManager.GetById(ItemId);
        if (item != null)
        {
            _menuItemManager.Delete(ItemId);
           
            return Json(true);
        }
        else
            return Json(false);
    }
        [Route("admin/menuitem/createItem")]
        [HttpGet]
        public IActionResult Create()
        {

            var viewModel = new MenuItemViewModels();
            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Create(MenuItem menuItem)
        {
            return RedirectToAction("Index");

        }
    }


   





}