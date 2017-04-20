namespace WoW.Data.ModelConfiuration
{
    using System.Data.Entity.ModelConfiguration;
    using Models.EntityModels;

    public class WordConfiguration : EntityTypeConfiguration<Word>
    {
        public WordConfiguration()
        {
            this.ToTable("Words");

            this.HasKey(w => w.Id);

            this.Property(w => w.Id)
                .HasColumnName("WordId");

            this.Property(w => w.Name)
                .IsRequired()
                .HasColumnName("Name");

            this.HasMany(w => w.Descriptions)
                .WithMany(w => w.Words)
                .Map(wd =>
                {
                    wd.MapLeftKey("WordId");
                    wd.MapRightKey("DescriptiopnId");
                    wd.ToTable("WordsDescriptions");
                });

            this.HasMany(w => w.Users)
               .WithMany(w => w.Words)
               .Map(wd =>
               {
                   wd.MapLeftKey("WordId");
                   wd.MapRightKey("UserId");
                   wd.ToTable("UsersWords");
               });
        }
    }
}
