namespace WoW.Web.Controllers
{
    using System.Web.Mvc;
    using Models.ViewModels.User;
    using Services;

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