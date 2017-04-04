using AutoMapper;
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

        public void EditWord(AddWordVM word, string id)
        {
            int wordId = Convert.ToInt32(id);
            var wordForEdit = Context.WordsForValidation.SingleOrDefault(w => w.Id == wordId);
            wordForEdit.Name = word.Name;
            wordForEdit.Description = word.Description;
            Context.SaveChanges();
        }

        public void TransferWords(WordForValidate word)
        {
            Description currentDescription = new Description(word.Description);
            Word existingWord = Context.Words.SingleOrDefault(w => w.Name == word.Name);
            Description existingDescription = Context.Descriptions.SingleOrDefault(d => d.Content == currentDescription.Content);
            if (existingWord.Name == word.Name)
            {
                existingWord.Descriptions.Add(currentDescription);
            }

            else if (currentDescription.Content == existingDescription.Content)
            {
                existingDescription.Words.Add(existingWord);
            }
            else
            {

                Word newWord = new Word();
                newWord.Name = word.Name;
                newWord.Descriptions.Add(currentDescription);
                Context.Words.Add(newWord);
            }

            Context.SaveChanges();
        }

        public IEnumerable<AllWordsOfUser> GetWordsOfUserByName(string name)
        {
            IEnumerable<WordForValidate> words = this.Context.WordsForValidation.Where(u => u.User.UserName == name);
            IEnumerable<AllWordsOfUser> awou = Mapper.Map<IEnumerable<WordForValidate>, IEnumerable<AllWordsOfUser>>(words);
            return awou;
        }

        public AddWordVM GetSpecificWord(int id)
        {
            WordForValidate editWord = Context.WordsForValidation.Find(id);
            if (editWord == null)
            {
                return null;
            }
            AddWordVM vm = Mapper.Map<WordForValidate, AddWordVM>(editWord);
            return vm;
        }
    }
}
