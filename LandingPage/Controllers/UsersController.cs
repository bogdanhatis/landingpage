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
        private ApplicationDbContext _context;
        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public JsonResult GetUsers()
        {
            var xx = _userManager.Users;
            return Json(new { data = xx });
        }

        public async Task<JsonResult> RemoveUser(String id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user!=null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return Json(true);
                else
                    return Json(false);                                  
            }
            else
                return Json(false);
        }
       
        public IActionResult Index(LoginViewModel model)
        {
          
            return View();
        }


    }
}