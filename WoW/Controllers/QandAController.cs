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
    [RoutePrefix("Q&A")]
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
                return this.RedirectToAction("AllQuestionsOfUsers");
            }

            return this.View();
        }

        public ActionResult AddAnswer()
        {
            return View();
        }

        // POST: QandA/Create
        [HttpPost]
        public ActionResult AddAnswer([Bind(Include = "Answer, Question")] Answer answer)
        {

            if (this.ModelState.IsValid)
            {
                var user = User.Identity.Name;
                this.QandAService.GetQuestion(answer, user);
                return this.RedirectToAction("AllQuestionsOfUsers");
            }

            return this.View();
        }

        // GET: QandA/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QandA/Edit/5
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

        // GET: QandA/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QandA/Delete/5
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
