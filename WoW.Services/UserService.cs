using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.User;
using WoW.Models.ViewModels.Words;

namespace WoW.Services
{
    public class UserService : Service
    {
        public ProfileVM GetUser(string name)
        {
            ApplicationUser currentUser = Context.Users.FirstOrDefault(u => u.UserName == name);
            UserInfo currentInfo = currentUser.UserInfo;
            ProfileVM userInfo = Mapper.Map<ApplicationUser, ProfileVM>(currentUser);
            userInfo.AllWords = Mapper.Map<IEnumerable<WordForValidate>, IEnumerable<AllWordsOfUser> > (currentUser.WordsForValidate);
            return userInfo;
        }
    }
}
