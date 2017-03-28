using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Data.ModelConfiuration
{
   public class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            this.ToTable("User Info");

            this.HasKey(ui => ui.Id);


            this.Property(u => u.FirstName)
                .IsOptional()
                .HasColumnName("FirstName")
                .HasMaxLength(30);

            this.Property(u => u.LastName)
                .IsOptional()
                .HasColumnName("LastName")
                .HasMaxLength(30);

            this.Property(ui => ui.Age)
                .IsRequired()
                .HasColumnName("Age");

            this.Property(ui => ui.EducationDegree)
                .IsRequired()
                .HasColumnName("Education Degree");

            this.Property(ui => ui.Gender)
                .IsRequired()
                .HasColumnName("Gender");

            this.Property(ui => ui.SocialStatus)
                .IsRequired()
                .HasColumnName("Social Status");

            this.Property(ui => ui.WorkingSphere)
                .IsRequired()
                .HasColumnName("Working Sphere");

            this.HasRequired(u => u.User)
                .WithOptional(u => u.UserInfo);
        }
    }
}
