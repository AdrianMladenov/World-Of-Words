namespace WoW.Models.ViewModels.QandA
{
    using System;
    using System.Collections.Generic;
    using EntityModels;

    public class QADetails
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
