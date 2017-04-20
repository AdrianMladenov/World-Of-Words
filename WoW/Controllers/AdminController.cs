using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoW.Models.ViewModels.Admin;
using WoW.Services;

namespace WoW.Web.Controllers
{
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
            return RedirectToAction("Info", "User");
        }
    }
}