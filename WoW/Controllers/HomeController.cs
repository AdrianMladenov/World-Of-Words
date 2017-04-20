namespace WoW.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.ViewModels;
    using Services;

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
        
    }
}