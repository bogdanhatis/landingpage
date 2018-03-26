using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var lista = new MenuItemManager().GetAll().Select(obj => obj.ItemId);
            var dictionary = new Dictionary<int, Tuple<String, String>>();
            List<string> dummy = null;
            foreach(var menuItem in lista)
            {
                var details = new CMSManager().GetByMenuItemId(menuItem);
                foreach(var detail in details)
                {
                    var det = new CMSDetailsManager().GetByCMSId(detail.Id);
                    dummy = new List<string>();
                    foreach(var x in det)
                    {
                        dummy.Add(x.ToString());
                    }
                }
                
            }
            var ImportAll = new CMSManager().GetAll();
            return View(ImportAll);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
