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
        public void AddWord(AddWordVM model, string user)
        {
            WordForValidate word = new WordForValidate();
            var currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == user);
            word.Name = model.Name;
            word.Description = model.Description;
            word.dateAdded = DateTime.Now;
            currentUser.WordsForValidate.Add(word);
            
            //this.Context.WordsForValidation.Add(word);
            this.Context.SaveChanges();
        }

        //public void IsWordExisting(WordForValidate word)
        //{

        //}
    }
}
