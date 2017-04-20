using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels;

namespace WoW.Services
{
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
