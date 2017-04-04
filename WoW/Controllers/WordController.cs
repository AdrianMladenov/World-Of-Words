using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WoW.Models.ViewModels.Words;
using WoW.Services;


namespace WoW.Web.Controllers
{
    [Authorize(Roles ="User")]
    public class WordController : Controller
    {
        private WordService wordService;

        public WordController()
        {
            this.wordService = new WordService();
        }

        // GET: Word
        public ActionResult About()
        {
            return View();
        }

        // GET: Word/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Word/Create
        public ActionResult Add()
        {
            
            return View();
        }

        // POST: Word/Create
        [HttpPost]
        public ActionResult Add([Bind(Include ="Name, Description" )] AddWordVM word)
        {
            
            if (this.ModelState.IsValid)
            {
                //var user = System.Web.HttpContext.Current.User.Identity.GetUserName();
                var user = User.Identity.Name;
                this.wordService.AddWord(word, user); 
                return this.RedirectToAction("GetWordsOfUser");
            }

            return this.View();
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult GetWordsOfUser()
        {
            string userName = User.Identity.Name;
            IEnumerable<AllWordsOfUser> awou = this.wordService.GetWordsOfUserByName(userName);
            return this.View(awou);
        }

        // GET: Word/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(int id)
        {
            string userName = User.Identity.Name;
            IEnumerable<AllWordsOfUser> awou = this.wordService.GetWordsOfUserByName(userName);
            if (awou == null)
            {
                return HttpNotFound();
            }
            return View(awou);
        }

        // POST: Word/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Word/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Word/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
