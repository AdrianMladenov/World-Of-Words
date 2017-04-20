namespace WoW.Services
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models.EntityModels;
    using Models.ViewModels.Words;

    public class WordService : Service
    {
        public void AddWord(AddWordVM model, string user)
        {
            WordForValidate word = new WordForValidate();
            int charCounter = TakeLetterCount(model, word);
            word.LetterCount = charCounter;
            var currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == user);
            word.Name = model.Name;
            word.Description = model.Description;
            word.DateOfCreation = DateTime.Now;
            word.LetterCount = charCounter;
            currentUser.WordsForValidate.Add(word);

            this.Context.SaveChanges();
        }

        private static int TakeLetterCount(AddWordVM model, WordForValidate word)
        {
            int charCounter = 0;
            for (int p = 0; p < model.Name.Length; p++)
            {

                if (model.Name[p] == ' ')
                {
                    continue;
                }
                else
                {

                    charCounter++;
                }
            }

            return charCounter;
        }


        public void EditWord(AddWordVM word, int id)
        {
            var wordForEdit = Context.WordsForValidation.SingleOrDefault(w => w.Id == id);
            wordForEdit.Name = word.Name;
            wordForEdit.Description = word.Description;
            int charCounter = TakeLetterCount(word, wordForEdit);
            wordForEdit.LetterCount = charCounter;
            wordForEdit.LastModifed = DateTime.Now;
            Context.SaveChanges();
        }

        public void DeleteWord(string id)
        {
            var wordId = Convert.ToInt32(id);
            var wordForDelete = Context.WordsForValidation.Find(wordId);
            wordForDelete.IsDeleted = true;
            Context.SaveChanges();
        }

        public void TransferWords(int id)
        {
            WordForValidate wordForTransfer = Context.WordsForValidation.SingleOrDefault(w => w.Id == id);
            Description currentDescription = new Description();
            currentDescription.Content = wordForTransfer.Description;
            Word existingWord = Context.Words.SingleOrDefault(w => w.Name == wordForTransfer.Name);
            Description existingDescription = Context.Descriptions.SingleOrDefault(d => d.Content == currentDescription.Content);
            if (existingWord != null && existingWord.Name == wordForTransfer.Name)
            {
                existingWord.Descriptions.Add(currentDescription);
            }

            else if (existingDescription != null && currentDescription.Content == existingDescription.Content)
            {
                existingDescription.Words.Add(existingWord);
            }
            else
            {

                Word newWord = new Word();
                newWord.Name = wordForTransfer.Name;
                newWord.Descriptions.Add(currentDescription);
                int counter = TakeLetterCountForTransferingWords(newWord);
                newWord.LetterCount = counter;
                newWord.Users.Add(wordForTransfer.User);
                Context.Words.Add(newWord);
            }

            wordForTransfer.IsValid = true;
            //Context.WordsForValidation.Remove(wordForTransfer);
            Context.SaveChanges();
        }

        private static int TakeLetterCountForTransferingWords(Word newWord)
        {
            int counter = 0;
            for (int i = 0; i < newWord.Name.Length; i++)
            {

                if (newWord.Name[i] == ' ')
                {
                    continue;
                }
                else
                {

                    counter++;
                }

            }

            return counter;
        }

        public IEnumerable<AllWordsOfUser> GetWordsOfUserByName(string name)
        {
            IEnumerable<WordForValidate> words = this.Context.WordsForValidation.Where(u => u.User.UserName == name && u.IsDeleted == false && u.IsValid == false);
            IEnumerable<AllWordsOfUser> awou = Mapper.Map<IEnumerable<WordForValidate>, IEnumerable<AllWordsOfUser>>(words);
            return awou;
        }

        public IEnumerable<SearchedWordVM> SearchWord(SearchedWordVM sWord)
        {
            if (!string.IsNullOrEmpty(sWord.Content))
            {
                var searchedWordDescr = sWord.Content;
                var searchedWordLength = sWord.Word.Length;

                var allWordsWithSearchedLength = this.Context.Words
                .Where(w => w.LetterCount == searchedWordLength && w.Descriptions.Any(d => d.Content.Contains(sWord.Content)))
                .Select(w => new { w.Descriptions, w.LetterCount, w.Name });
                var listResult = new List<SearchedWordVM>();

                foreach (var word in allWordsWithSearchedLength)
                {
                    foreach (var descr in word.Descriptions)
                    {
                        Regex searchingPattern = new Regex(sWord.Word, RegexOptions.IgnoreCase);
                        var tempWord = word.Name.Split(' ');
                        var cleanWord = string.Join("", tempWord);
                        if (searchingPattern.IsMatch(cleanWord))
                        {
                            var newSearchedWord = new SearchedWordVM();
                            newSearchedWord.Word = word.Name;
                            newSearchedWord.Content = descr.Content;
                            listResult.Add(newSearchedWord);
                        }
                    }
                }
                return listResult;
            }
            else
            {
                var searchedWordDescr = sWord.Content;
                var searchedWordLength = sWord.Word.Length;

                var allWordsWithSearchedLength = this.Context.Words
                .Where(w => w.LetterCount == searchedWordLength)
                .Select(w => new { w.Descriptions, w.LetterCount, w.Name });
                var listResult = new List<SearchedWordVM>();

                foreach (var word in allWordsWithSearchedLength)
                {
                    foreach (var descr in word.Descriptions)
                    {
                        Regex searchingPattern = new Regex(sWord.Word, RegexOptions.IgnoreCase);
                        var tempWord = word.Name.Split(' ');
                        var cleanWord = string.Join("", tempWord);
                        if (searchingPattern.IsMatch(cleanWord))
                        {
                            var newSearchedWord = new SearchedWordVM();
                            newSearchedWord.Word = word.Name;
                            newSearchedWord.Content = descr.Content;
                            listResult.Add(newSearchedWord);
                        }
                    }
                }
                return listResult;
            }
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
