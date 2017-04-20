namespace WoW.Web.Controllers
{
    using System.Web.Mvc;
    using Models.ViewModels.Admin;
    using Services;

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private AdminService adminService;

        public AdminController()
        {
            this.adminService = new AdminService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            APIndexVM page = this.adminService.ShowAdminPage();
            return this.View(page);
        }

        public ActionResult Import()
        {
            this.adminService.ImportEntitiesInDB();
            return RedirectToAction("GetUser", "User");
        }
    }
}