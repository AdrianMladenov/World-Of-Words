namespace WoW.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using ModelConfiuration;
    using Migrations;

    public class WoWContext : IdentityDbContext<ApplicationUser>
    {
        public WoWContext()
            : base("WoWContext", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<WoWContext, Configuration>());
        }

        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<UserInfo> UsersInfo { get; set; }
        //public virtual DbSet<System.Enum> Enumerations { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<WordForValidate> WordsForValidation { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WordConfiguration());
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new DescriptionConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
           
            base.OnModelCreating(modelBuilder);
        }

        public static WoWContext Create()
        {
            return new WoWContext();
        }
    }

}