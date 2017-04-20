namespace WoW.Data
{
    using System.Data.Entity;
    using Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ModelConfiuration;

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

            //modelBuilder.Entity<WordForValidate>().Property(wv => wv.dateAdded).HasColumnName("dateAdded");
            //modelBuilder.Entity<WordForValidate>().Property(wv => wv.dateAdded).HasColumnType("datetime2");
           
            base.OnModelCreating(modelBuilder);
        }

        public static WoWContext Create()
        {
            return new WoWContext();
        }
    }

}