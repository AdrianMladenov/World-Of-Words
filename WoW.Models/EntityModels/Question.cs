
namespace WoW.Models.EntityModels
{
    using System.Collections.Generic;

    public class Question
    {
        private ICollection<Answer> answers;

        public Question()
        {

        }

        public Question(string content)
        {
            this.Content = content;
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public string Word { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

    }
}
