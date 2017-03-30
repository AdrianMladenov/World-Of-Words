using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Data.ModelConfiuration
{
   public class DescriptionConfiguration : EntityTypeConfiguration<Description>
    {
        public DescriptionConfiguration()
        {
            this.ToTable("Descriptions");

            this.HasKey(d => d.Id);

            this.Property(d => d.Content)
                .IsRequired()
                .HasColumnName("Description");
        }
    }
}
