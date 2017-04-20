namespace WoW.Data.ModelConfiuration
{
    using System.Data.Entity.ModelConfiguration;
    using Models.EntityModels;

    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            this.ToTable("Questions");

            this.HasKey(q => q.Id);

            this.Property(q => q.Content)
                .IsRequired()
                .HasColumnName("Content");

            this.Property(q => q.Word)
                .IsRequired()
                .HasColumnName("Word")
                .HasMaxLength(30);

            this.HasRequired(a => a.User)
                .WithMany(u => u.Questions);
        }
    }
}
