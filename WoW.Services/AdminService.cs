using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.Admin;
using WoW.Models.ViewModels.Words;
using WoW.Data;

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
        public void ImportEntitiesInDB()
        {
            var userFolderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var userSasho = "Sasho";
            var userAdrian = "Adrian";
            if (userFolderName.Contains(userSasho))
            {
                userFolderName = userFolderName + @"\GitHub\World-Of-Words\";
            }
            else if (userFolderName.Contains(userAdrian))
            {
                userFolderName = userFolderName + @"\Visual Studio 2015\Projects\World-Of-Words\";
            }


            string[] words = File.ReadAllLines(userFolderName + @"\twords.txt");

            string[] descriptions = File.ReadAllLines(userFolderName + @"\tdescs.txt");

            var dict = new Dictionary<string, List<string>>();
            var userAl = Context.Users.FirstOrDefault(u => u.UserName == "Alexander");
            var userAm = Context.Users.FirstOrDefault(u => u.UserName == "Adriankata");
            var userNl = Context.Users.FirstOrDefault(u => u.UserName == "Lutaka");
            var userZk = Context.Users.FirstOrDefault(u => u.UserName == "Bate Zdravko");

            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(words[i].Trim()))
                {
                    dict[words[i].Trim()].Add(descriptions[i].Trim());
                }
                else
                {
                    var list = new List<string>() { descriptions[i].Trim() };
                    dict.Add(words[i].Trim(), list);
                }
            }
            var count = 0;
            foreach (var key in dict.Keys)
            {
                Word currentWord = new Word();
                int charCounter = 0;
                currentWord.Name = key.Trim();
                charCounter = GetWordCountWOspaces(dict, key.Trim(), currentWord, charCounter);

                foreach (var desc in dict[key])
                {
                    count++;
                    if (Context.Descriptions.Any(d => d.Content == desc.Trim()))
                    {
                        var existingDescription = Context.Descriptions.Include("Words").FirstOrDefault(ew => ew.Content == desc.Trim());
                        existingDescription.Words.Add(currentWord);
                        ChooseUser(Context, userAl, userAm, userNl, userZk, words, currentWord, count);
                        Context.SaveChanges();
                    }

                    else
                    {
                        Description currentDescription = new Description();
                        currentDescription.Content = desc.Trim();
                        currentWord.Descriptions.Add(currentDescription);
                        //Context.Words.Add(currentWord);
                        Context.Descriptions.Add(currentDescription);
                        ChooseUser(Context, userAl, userAm, userNl, userZk, words, currentWord, count);
                        Context.SaveChanges();
                    }
                }
            }
        }

        private void ChooseUser(WoWContext context,  ApplicationUser userAl, ApplicationUser userAm, ApplicationUser userNl, ApplicationUser userZk, string[] words, Word currentWord, int count)
        {
            if (count % 2 != 0 && count <= words.Length / 2)
            {
                userAl.Words.Add(currentWord);
                //currentWord.Users.Add(userAl);
            }

            else if (count % 2 == 0 && count <= words.Length / 2)
            {
                userAm.Words.Add(currentWord);
                //currentWord.Users.Add(userAm);
            }

            else if (count % 2 == 0 && count > words.Length / 2)
            {
                userNl.Words.Add(currentWord);
                //currentWord.Users.Add(userNl);
            }

            else if (count % 2 != 0 && count > words.Length / 2)
            {
                userZk.Words.Add(currentWord);
                //currentWord.Users.Add(userZk);

            }
        }

        private static int GetWordCountWOspaces(Dictionary<string, List<string>> dict, string key, Word currentWord, int charCounter)
        {
            for (int p = 0; p < currentWord.Name.Length; p++)
            {
                if (currentWord.Name[p] == ' ')
                {
                    continue;
                }
                else
                {
                    charCounter++;
                }
                currentWord.LetterCount = charCounter;
            }
            return charCounter;
        }
    }
}
