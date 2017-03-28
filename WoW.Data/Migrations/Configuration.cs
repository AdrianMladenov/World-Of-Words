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

            ApplicationUser userAl = new ApplicationUser
            {
                UserName = "Alexander",
                PasswordHash = "123Abb",
                Email = "al@mail.bg"
            };

            ApplicationUser userAm = new ApplicationUser
            {
                UserName = "Adriankata",
                PasswordHash = "123Abb",
                Email = "am@mail.bg"
            };

            ApplicationUser userNl = new ApplicationUser
            {
                UserName = "Lutaka",
                PasswordHash = "123Abb",
                Email = "nl@mail.bg"
            };

            ApplicationUser userZk = new ApplicationUser
            {
                UserName = "Bate Zdravko",
                PasswordHash = "123Abb",
                Email = "zk@mail.bg",
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

            string[] words = File.ReadAllLines(@"C:\Users\2351x\Documents\Visual Studio 2015\Projects\World-Of-Words-master\World-Of-Words-master/Words.txt");

            string[] descriptions = File.ReadAllLines(@"C:\Users\2351x\Documents\Visual Studio 2015\Projects\World-Of-Words-master\World-Of-Words-master/WordsDescriptions.txt");


            for (int i = 0; i < words.Length; i++)
            {
                Word currentWord = new Word(words[i]);

                for (int j = 0; j < descriptions.Length; j++)
                {
                    Description currentDescription = new Description(descriptions[j]);
                    currentWord.Descriptions.Add(currentDescription);
                }

                if (i % 2 != 0 && i <= 30)
                {
                    userAl.Words.Add(currentWord);
                    context.SaveChanges();
                }

                else if (i % 2 == 0 && i <= 30)
                {
                    userAm.Words.Add(currentWord);
                    context.SaveChanges();
                }

                else if (i % 2 == 0 && i >= 30)
                {
                    userNl.Words.Add(currentWord);
                    context.SaveChanges();
                }

                else if (i % 2 != 0 && i >= 30)
                {
                    userZk.Words.Add(currentWord);
                    context.SaveChanges();
                }


            }
        }
    }
}
