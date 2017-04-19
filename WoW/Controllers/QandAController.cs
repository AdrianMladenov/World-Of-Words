using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.QandA;
using WoW.Services;

namespace WoW.Web.Controllers
{
    [RoutePrefix("q&a")]
    [Authorize(Roles = "User, Admin")]
    public class QandAController : Controller
    {
        private QandAService QandAService;

        public QandAController()
        {
            this.QandAService = new QandAService();
        }

        // GET: QandA
        public ActionResult AllQuestionsOfUsers()
        {
           IEnumerable<QADetails> all =  this.QandAService.GetAllQuestionsAndAnswers();
            return View(all);
        }

        // GET: QandA/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QandA/Create
        public ActionResult AddQuestion()
        {
            return View();
        }

        // POST: QandA/Create
        [HttpPost]
        public ActionResult AddQuestion([Bind(Include = "Word, Content")] AddQVM question)
        {

            if (this.ModelState.IsValid)
            {
                var user = User.Identity.Name;
                this.QandAService.AddQuestion(question, user);
                //return this.RedirectToAction("AllQuestionsOfUsers");
                return Json(new { result = "Redirect", url = Url.Action("AllQuestionsOfUsers", "QandA") });
            }

            return this.View();
        }

        [HttpGet, Route("addAnswer/{id}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult AddAnswer(int id)
        {
           AddQVM question =  this.QandAService.GetQuestion(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return this.PartialView("_AddAnswer", question);
        }

        // POST: QandA/Create
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnswer(AddQVM currentAnswer)
        {
            if (this.ModelState.IsValid)
            {
                var user = User.Identity.Name;
                int id = currentAnswer.Id;
                this.QandAService.AddAnswerToQuestion(currentAnswer, user, id);
                return this.RedirectToAction("AllQuestionsOfUsers");
            }

            return this.View();
        }

        //// GET: QandA/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: QandA/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: QandA/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: QandA/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
