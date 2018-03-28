using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LandingPage.Models.NewsletterUsersViewModels;
using Service;

namespace LandingPage.Areas.Admin.Controllers
{
    [Area("admin")]
    public class NewsletterUsersController : Controller
    {
        [Route("admin/NewsletterUsers/getall")]
        public JsonResult GetAll()
        {
            var _repo = new NewsletterUsersManager();
            return Json(new { data = _repo.GetAll() });
        }

        [Route("admin/NewsletterUsers/deleteUser")]
        public JsonResult Delete(int id)
        {
            var _repo = new NewsletterUsersManager();
            var user = _repo.GetById(id);
            if (user.Id > 0)
            {
                _repo.Delete(user.Id);
                return Json(true);
            }
            else return Json(false);
        }
        [Route("admin/NewsletterUsers/Create")]
        public JsonResult Create(string email)
        {
            var _repo = new NewsletterUsersManager();
            var user = _repo.GetByEmail(email);
            if(user!=null)
            {
                return Json(false);
            }
            else
            {
                var date = new DateTime();
                _repo.Create(email, DateTime.Now,Request.HttpContext.Connection.RemoteIpAddress.ToString());
                return Json(true);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}