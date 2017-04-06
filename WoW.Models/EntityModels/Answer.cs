namespace WoW.Models.EntityModels
{
    public class Answer
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        //public int UserId { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }
    }
}
