namespace WoW.Models.EntityModels
{
    public class Answer
    {

        public Answer()
        {

        }

        public Answer(string content)
        {
            this.Content = content;     
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        //public int UserId { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }
    }
}
