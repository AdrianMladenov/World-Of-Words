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
    [RoutePrefix("word")]
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

        
        [Authorize(Roles = "User, Admin")]
        public ActionResult GetWordsOfUser()
        {
            string userName = User.Identity.Name;
            IEnumerable<AllWordsOfUser> awou = this.wordService.GetWordsOfUserByName(userName);
            return this.View(awou);
        }

        // GET: Word/Edit/5
        [HttpGet, Route("edit/{id}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(int id)
        {
            string userName = User.Identity.Name;
            AddWordVM wordForEdit = this.wordService.GetSpecificWord(id);
            if (wordForEdit == null)
            {
                return HttpNotFound();
            }
            return this.PartialView("_Edit", wordForEdit);
        }

        // POST: Word/Edit/5
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit([Bind(Include = "Name, Description")] AddWordVM word, string id)
        {
            if (this.ModelState.IsValid)
            {
                this.wordService.EditWord(word, id);
                return RedirectToAction("GetWordsOfUser");
            }
            return View(word);
        }

        // GET: Word/Delete/5
        [HttpGet, Route("delete/{id}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(int id)
        {
            AddWordVM wordForDelete = this.wordService.GetSpecificWord(id);
            if (wordForDelete == null)
            {
                return HttpNotFound();
            }
            
            return this.PartialView("_Delete", wordForDelete);
        }

        // POST: Word/Delete/5
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete([Bind(Include = "Name, Description")] string id)
        {
            if (this.ModelState.IsValid)
            {
                this.wordService.DeleteWord(id);
                return RedirectToAction("GetWordsOfUser");
            }
            return RedirectToAction("GetWordsOfUser");
        }
    }
}
