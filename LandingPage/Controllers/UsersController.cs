using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;
using test.Models.AccountViewModels;

namespace LandingPage.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;            
        }
        public JsonResult GetUsers()
        {
            var xx = _userManager.Users;
            return Json(new { data = xx });
        }

        public async Task<JsonResult> RemoveUser(String id)
        {
            var user = await _userManager.FindByEmailAsync(id);
            if(user!=null)
            {
                await _userManager.DeleteAsync(user);
            }
            return Json(true);
            
        }
       
        public IActionResult Index(LoginViewModel model)
        {
          
            return View();
        }


    }
}