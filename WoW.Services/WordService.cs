using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Data;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.Words;

namespace WoW.Services
{
   public class WordService : Service
    {
        public void AddWord(AddWordVM model)
        {
            WordForValidate word = new WordForValidate();
            //var user = Context.Users.SingleOrDefault(u => u.UserName == model.User.UserName);
            word.Name = model.Name;
            word.Description = model.Description;
            //word.User = user;
            
            
            this.Context.WordsForValidation.Add(word);
            this.Context.SaveChanges();
        }

        //public void IsWordExisting(WordForValidate word)
        //{

        //}
    }
}
