using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Data.ModelConfiuration
{
   public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            this.ToTable("Answer");

            this.HasKey(a => a.Id);

            this.Property(a => a.Content)
                .IsRequired()
                .HasColumnName("Content");

            this.HasRequired(a => a.Question)
                .WithMany(q => q.Answers);

            this.HasRequired(a => a.User)
                .WithMany(u => u.Answers);

        }
    }
}
