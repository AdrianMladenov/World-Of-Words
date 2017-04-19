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
            ProfileVM userInfo = new ProfileVM();

            ApplicationUser currentUser = Context.Users.FirstOrDefault(u => u.UserName == name);
            UserInfo currentInfo = currentUser.UserInfo;
            userInfo = Mapper.Map<ApplicationUser, ProfileVM>(currentUser);
            userInfo.WordForValidateCount = currentUser.WordsForValidate.Where(w => w.IsValid == false).Count();
            userInfo.WordCount = currentUser.Words.Count();
            userInfo.QuestionCount = currentUser.Questions.Count();
            userInfo.AnswerCount = currentUser.Answers.Count();
            userInfo.Info = Mapper.Map<UserInfo, Info>(currentUser.UserInfo);
            return userInfo;
        }

        public void AddInfo(ProfileVM userInfo, string user)
        {
            ApplicationUser currentUser = Context.Users.FirstOrDefault(u => u.UserName == user);
            if (currentUser.UserInfo == null)
            {
                UserInfo currentInfo = new UserInfo();
                currentInfo.FirstName = userInfo.Info.FirstName;
                currentInfo.LastName = userInfo.Info.LastName;
                currentInfo.Age = userInfo.Info.Age;
                currentInfo.RegistrationDate = DateTime.Now;
                currentInfo.Gender = userInfo.Info.Gender;
                currentInfo.WorkingSphere = userInfo.Info.WorkingSphere;
                currentInfo.EducationDegree = userInfo.Info.EducationDegree;
                currentInfo.SocialStatus = userInfo.Info.SocialStatus;

                currentUser.UserInfo = currentInfo;
            }
            else
            {

                UserInfo currentInfo = Context.UsersInfo.SingleOrDefault(ui => ui.User.UserName == user);
                currentInfo.FirstName = userInfo.Info.FirstName;
                currentInfo.LastName = userInfo.Info.LastName;
                currentInfo.Age = userInfo.Info.Age;
                currentInfo.Gender = userInfo.Info.Gender;
                currentInfo.WorkingSphere = userInfo.Info.WorkingSphere;
                currentInfo.EducationDegree = userInfo.Info.EducationDegree;
                currentInfo.SocialStatus = userInfo.Info.SocialStatus;
                currentUser.Email = userInfo.Email;
            }
            Context.SaveChanges();

        }
        
    }
}
