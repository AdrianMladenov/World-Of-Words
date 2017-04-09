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

        // GET: User
        public ActionResult Info()
        {
            string userName = this.User.Identity.Name;
            ProfileVM user = this.userService.GetUser(userName);

            return this.View(user);
        }
    }
}