using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DBModels;
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
            foreach (var item in ImportAll)
            {
                var CMSViewModel = (CMSViewModels)item;
                CMSViewModel.CMSDetails = new List<CMSDetailsViewModels>();
                CMSViewModelList.Add(CMSViewModel);
                var detail = new CMSDetailsManager().GetByCMSId(item.Id);
                if (detail.Count > 0)
                {

                    foreach (var cmsDetail in detail)
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
        [HttpPost]
        public JsonResult ContactForm(string fname, string lname, string email, string message)
        {
            try
            {
                var _contactFormManager = new ContactFormManager();
                var modelContactForm = new ContactForm();
                modelContactForm.FirstName = fname;
                modelContactForm.LastName = lname;
                modelContactForm.EmailAddress = email;
                modelContactForm.Message = message;
                var createId = _contactFormManager.Create(modelContactForm);
                return Json(true);

            }
            catch { return Json(false); };
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
