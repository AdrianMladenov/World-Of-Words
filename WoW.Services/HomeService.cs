namespace WoW.Services
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using Models.EntityModels;
    using Models.ViewModels;

    public class HomeService : Service
    {
        public IEnumerable<WordsVM> GetWords()
        {
            IEnumerable<Word> words = this.Context.Words.OrderByDescending(w => w.DateOfCreation).Take(10);
            IEnumerable<WordsVM> wvm = Mapper.Map<IEnumerable<Word>, IEnumerable<WordsVM>>(words);
            return wvm;
        }
    }
}
