using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Data.ModelConfiuration
{
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
