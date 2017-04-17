namespace WoW.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Models.EntityModels;
    using System.IO;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<WoWContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WoWContext context)
        {
             context.Database.Initialize(true);
            //context.Roles.AddOrUpdate(r => new IdentityRole("User"));
            //if (!context.Roles.Any(role => role.Name == "User"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var userRole = new IdentityRole("Guest");
            //    manager.Create(userRole);
            //}

            if (!context.Roles.Any(role => role.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var userRole = new IdentityRole("User");
                manager.Create(userRole);
            }

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole("Admin");
                manager.Create(adminRole);
            }

            var PasswordHash = new PasswordHasher();
            ApplicationUser userAl = new ApplicationUser
            {
                UserName = "Alexander",
                PasswordHash = PasswordHash.HashPassword("123Abb"),
                Email = "al@mail.bg",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            ApplicationUser userAm = new ApplicationUser
            {
                UserName = "Adriankata",
                PasswordHash = PasswordHash.HashPassword("123Abb"),
                Email = "am@mail.bg",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            ApplicationUser userNl = new ApplicationUser
            {
                UserName = "Lutaka",
                PasswordHash = PasswordHash.HashPassword("123Abb"),
                Email = "nl@mail.bg",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            ApplicationUser userZk = new ApplicationUser
            {
                UserName = "Bate Zdravko",
                PasswordHash = PasswordHash.HashPassword("123Abb"),
                Email = "zk@mail.bg",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            UserInfo alexanderInfo = new UserInfo(22, "Alexander", "Lazarov",
                Models.EntityModels.Enum.Gender.Male,
                Models.EntityModels.Enum.SocialStatus.Student,
                Models.EntityModels.Enum.EducationDegree.HalfHighEducation,
                Models.EntityModels.Enum.WorkingSphere.IT);

            UserInfo adrianInfo = new UserInfo(23, "Adrian", "Mladenov",
                Models.EntityModels.Enum.Gender.Male,
                Models.EntityModels.Enum.SocialStatus.Student,
                Models.EntityModels.Enum.EducationDegree.HighEducation,
                Models.EntityModels.Enum.WorkingSphere.IT);

            UserInfo nikolaiInfo = new UserInfo(21, "Nikolai", "Lutakov",
                Models.EntityModels.Enum.Gender.Male,
                Models.EntityModels.Enum.SocialStatus.EmployeeInPrivateSector,
                Models.EntityModels.Enum.EducationDegree.SecondarySpecialEducation,
                Models.EntityModels.Enum.WorkingSphere.IT);

            UserInfo zdravkoInfo = new UserInfo(25, "Zdravko", "Katsarov",
                Models.EntityModels.Enum.Gender.Male,
                Models.EntityModels.Enum.SocialStatus.EmployeeInPrivateSector,
                Models.EntityModels.Enum.EducationDegree.HighEducation,
                Models.EntityModels.Enum.WorkingSphere.IT);

            userAl.UserInfo = alexanderInfo;
            userAm.UserInfo = adrianInfo;
            userNl.UserInfo = nikolaiInfo;
            userZk.UserInfo = zdravkoInfo;

            context.Users.AddOrUpdate(u => u.UserName, userAl);
            context.Users.AddOrUpdate(u => u.UserName, userAm);
            context.Users.AddOrUpdate(u => u.UserName, userNl);
            context.Users.AddOrUpdate(u => u.UserName, userZk);

            context.SaveChanges();

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            userManager.AddToRole(userAl.Id, "Admin");
            userManager.AddToRole(userAm.Id, "Admin");
            userManager.AddToRole(userNl.Id, "Admin");
            userManager.AddToRole(userZk.Id, "Admin");

            //context.SaveChanges();
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


            string[] words = File.ReadAllLines(userFolderName + @"\Words.txt");

            string[] descriptions = File.ReadAllLines(userFolderName + @"\WordsDescriptions.txt");


            //string[] words = File.ReadAllLines(@"C:\Users\AleksandarLazarov\Documents\GitHub\World-Of-Words\Words.txt");

            //string[] descriptions = File.ReadAllLines(@"C:\Users\AleksandarLazarov\Documents\GitHub\World-Of-Words\WordsDescriptions.txt");


            for (int i = 0; i < words.Length; i++)
            {
                Word currentWord = new Word();
                int charCounter = 0;
                currentWord.Name = words[i];

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
                }
                currentWord.LetterCount = charCounter;
                
                Description currentDescription = new Description();
                currentDescription.Content = descriptions[i];
                //currentWord.Descriptions.Add(currentDescription);

                if (context.Words.Any(w => w.Name == currentWord.Name))
                {
                    var existingWord = context.Words.Include(ew => ew.Descriptions).SingleOrDefault(ew => ew.Name == currentWord.Name);

                    if (existingWord.Descriptions.Any(d => d.Content == currentDescription.Content))
                    {
                        ChooseUser(context, userAl, userAm, userNl, userZk, i, words, currentWord);
                        context.SaveChanges();
                    }
                    else
                    {
                        existingWord.Descriptions.Add(currentDescription);
                        context.SaveChanges();
                    }

                }

                else if (context.Descriptions.Any(d => d.Content == currentDescription.Content))
                {
                    var existingDescription = context.Descriptions.Include(ew => ew.Words).SingleOrDefault(ew => ew.Content == currentDescription.Content);
                    existingDescription.Words.Add(currentWord);
                    ChooseUser(context, userAl, userAm, userNl, userZk, i, words, currentWord);
                    context.SaveChanges();
                }

                else
                {
                    currentWord.Descriptions.Add(currentDescription);
                    //context.Words.Add(currentWord);
                    context.Descriptions.Add(currentDescription);
                    ChooseUser(context, userAl, userAm, userNl, userZk, i, words, currentWord);
                    context.SaveChanges();
                }
            }
        }

        private static void ChooseUser(WoWContext context, ApplicationUser userAl, ApplicationUser userAm, ApplicationUser userNl, ApplicationUser userZk, int i , string[] words, Word currentWord)
        {
            if (i % 2 != 0 && i <= words.Length / 2)
            {
                userAl.Words.Add(currentWord);
                //currentWord.Users.Add(userAl);
            }

            else if (i % 2 == 0 && i <= words.Length / 2)
            {
                userAm.Words.Add(currentWord);
                //currentWord.Users.Add(userAm);
            }

            else if (i % 2 == 0 && i > words.Length / 2)
            {
                userNl.Words.Add(currentWord);
                //currentWord.Users.Add(userNl);
            }

            else if (i % 2 != 0 && i > words.Length / 2)
            {
                userZk.Words.Add(currentWord);
                //currentWord.Users.Add(userZk);

            }
        }
    }
}
