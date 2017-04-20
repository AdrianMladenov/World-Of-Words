namespace WoW.Models.ViewModels.User
{
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class ProfileVM
    {
        [NotMapped]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public int WordCount { get; set; }

        public int WordForValidateCount { get; set; }

        public int QuestionCount { get; set; }

        public int AnswerCount { get; set; }

        public Info Info { get; set; }
    }
}
