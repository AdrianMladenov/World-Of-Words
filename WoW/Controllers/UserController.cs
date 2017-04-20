using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoW.Models.ViewModels.User;
using WoW.Services;

namespace WoW.Web.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController()
        {
            this.userService = new UserService();
        }

        // GET: User info
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Info()
        {
            string userName = this.User.Identity.Name;
            ProfileVM user = this.userService.GetUser(userName);

            return this.View(user);
            
        }

        //POST: User info
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Info(ProfileVM userDetails)
        {
            if (this.ModelState.IsValid)
            {
                var user = User.Identity.Name;
                this.userService.AddInfo(userDetails, user);
                return this.RedirectToAction("Info");
            }

            return this.View();
        }
        
    }
}