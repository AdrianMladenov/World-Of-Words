using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.Admin;
using WoW.Models.ViewModels.Words;

namespace WoW.Services
{
  public class AdminService : Service
    {
        public APIndexVM ShowAdminPage()
        {
            APIndexVM page = new APIndexVM();

            IEnumerable<WordForValidate> wordsForValidate = this.Context.WordsForValidation.Where(u => u.IsDeleted == false && u.IsValid == false);
            IEnumerable<Word> words = Context.Words;
            IEnumerable<ApplicationUser> users = Context.Users;

            IEnumerable<AllWordsOfUser> allwords = Mapper.Map<IEnumerable<WordForValidate>, IEnumerable<AllWordsOfUser>>(wordsForValidate);

            IEnumerable<APUsersInfoVM> usersInfo = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<APUsersInfoVM>>(users);

            page.AllWordsForValidate = allwords;
            page.UsersInfo = usersInfo;

            return page;
        }
    }
}
