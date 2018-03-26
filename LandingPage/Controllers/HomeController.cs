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
            foreach(var CMS in ImportAll)
            {
                var CMSViewModel = (CMSViewModels)CMS;
                CMSViewModelList.Add(CMSViewModel);
            }
            

            var screenshots = new Service.CMSDetailsManager().GetByCMSId(38);
            var screenshotsDetailsVMList = new List<CMSDetailsViewModels>();
            foreach(var screenshotsDetail in screenshots)
            {
                var screenshotsDetailVM = (CMSDetailsViewModels)screenshotsDetail;
                screenshotsDetailsVMList.Add(screenshotsDetailVM);
            }

            var team = new Service.CMSDetailsManager().GetByCMSId(39);
            var teamDetailsVMList = new List<CMSDetailsViewModels>();
            foreach(var teamDetail in team)
            {
                var teamDetailVM = (CMSDetailsViewModels)teamDetail;
                teamDetailsVMList.Add(teamDetailVM);
            }

            var reviews = new Service.CMSDetailsManager().GetByCMSId(40);
            var reviewsDetails = new Service.CMSDetailsManager().GetByCMSId(40);
            var listCMSDetailsVM = new List<CMSDetailsViewModels>();
            foreach(var reviewDetail in reviewsDetails)
            {
                var reviewDetailViewModel = (CMSDetailsViewModels)reviewDetail;
                listCMSDetailsVM.Add(reviewDetailViewModel);
                
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
