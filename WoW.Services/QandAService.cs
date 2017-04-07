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

        public void GetQuestion(object question, string user)
        {
            throw new NotImplementedException();
        }
    }
}
