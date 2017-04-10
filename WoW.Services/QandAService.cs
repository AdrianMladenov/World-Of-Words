using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.QandA;

namespace WoW.Services
{
    public class QandAService : Service
    {
        public void AddQuestion(AddQVM question, string user)
        {
            Question newQuestion = new Question();
            var currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == user);
            newQuestion.Word = question.Word;
            newQuestion.Content = question.Content;
            newQuestion.DateOfCreation = DateTime.Now;
            currentUser.Questions.Add(newQuestion);
            this.Context.SaveChanges();

        //    try { this.Context.SaveChanges(); }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                Trace.TraceInformation("Property: {0} Error: {1}",
        //                                        validationError.PropertyName,
        //                                        validationError.ErrorMessage);
        //            }
        //        }
        //    }
        }

        public AddQVM GetQuestion(int id)
        {
            Question specificQuestion = Context.Questions.Find(id);
            if (specificQuestion == null)
            {
                return null;
            }
            AddQVM question = Mapper.Map<Question, AddQVM>(specificQuestion);
            return question;
        }

        public IEnumerable<QADetails> GetAllQuestionsAndAnswers()
        {
           IEnumerable<Question> all = Context.Questions.OrderByDescending(q => q.DateOfCreation).ToList();
           IEnumerable<QADetails> collection = Mapper.Map<IEnumerable<Question>, IEnumerable<QADetails>>(all);
            return collection;
        }

        public void AddAnswerToQuestion(AddQVM answerInfo,string user, int id)
        {
            var question = Context.Questions.Find(id);
            var currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == user);
            Answer newAnswer = new Answer();
            newAnswer.Content = answerInfo.Answer;
            question.Answers.Add(newAnswer);
            currentUser.Answers.Add(newAnswer);
           
            Context.SaveChanges();
        }
    }
}
