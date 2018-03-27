using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LandingPage.Models.CMSDetailsViewModels;
using LandingPage.Models.CMSViewModels;
using Microsoft.AspNetCore.Mvc;
using Service;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {           
            var ImportAll = new CMSManager().GetAll();

            var CMSViewModelList = new List<CMSViewModels>();
            foreach(var item in ImportAll)
            {
                var CMSViewModel = (CMSViewModels)item;
                CMSViewModel.CMSDetails = new List<CMSDetailsViewModels>();
                CMSViewModelList.Add(CMSViewModel);
                var detail = new CMSDetailsManager().GetByCMSId(item.Id);
                if(detail.Count>0)
                {
                    
                    foreach(var cmsDetail in detail)
                    {
                        var cms = (CMSDetailsViewModels)cmsDetail;
                        CMSViewModel.CMSDetails.Add(cms);
                    }
                }
            }
            return View(CMSViewModelList);
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
