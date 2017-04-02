using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoW.Models.ViewModels;
using WoW.Services;

namespace WoW.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService;

        public HomeController()
        {
            this.homeService = new HomeService();
        }


        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<WordsVM> wvm = this.homeService.GetWords();
            return this.View(wvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}