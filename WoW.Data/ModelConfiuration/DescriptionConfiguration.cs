namespace WoW.Data.ModelConfiuration
{
    using System.Data.Entity.ModelConfiguration;
    using WoW.Models.EntityModels;

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
