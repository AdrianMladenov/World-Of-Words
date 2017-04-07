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
        }

        public void GetQuestion(Answer answer, string user)
        {
            Question specificQuestion = Context.Questions.SingleOrDefault(q => q.Content == answer.Question.Content);
            specificQuestion.Answers.Add(answer);

            ApplicationUser specificUser = Context.Users.SingleOrDefault(u => u.UserName == user);
            specificUser.Answers.Add(answer);

            this.Context.SaveChanges();
        }

        public IEnumerable<QADetails> GetAllQuestionsAndAnswers()
        {
           IEnumerable<Question> all = Context.Questions.OrderByDescending(q => q.DateOfCreation).ToList();
           IEnumerable<QADetails> collection = Mapper.Map<IEnumerable<Question>, IEnumerable<QADetails>>(all);
            return collection;
        }
    }
}
