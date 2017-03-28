using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Data.ModelConfiuration
{
   public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            this.ToTable("Questions");

            this.HasKey(q => q.Id);

            this.Property(q => q.Content)
                .IsRequired()
                .HasColumnName("Content");

            this.HasRequired(a => a.User)
                .WithMany(u => u.Questions);
        }
    }
}
