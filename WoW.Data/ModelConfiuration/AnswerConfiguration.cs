namespace WoW.Data.ModelConfiuration
{
    using System.Data.Entity.ModelConfiguration;
    using Models.EntityModels;

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
