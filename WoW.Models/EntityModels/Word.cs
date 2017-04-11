
namespace WoW.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Word
    {
        private ICollection<ApplicationUser> users;
        private ICollection<Description> descriptions;


        public Word()
        {
            this.DateOfCreation = DateTime.Now;
            this.Users = new HashSet<ApplicationUser>();
            this.Descriptions = new HashSet<Description>();
        }

        
        public int Id { get; set; } //Auto-generated

        public string Name { get; set; }

        public int? LetterCount { get; set; }

        //public virtual ApplicationUser User { get; set; }

        //public int UserId { get; set; }

        //[Display(Name = "Дата на добавяне:")]
        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<ApplicationUser> Users // Navigation property
        {
            get { return this.users; }
            set { this.users = value; }
        }

        //[Display(Name = "Описание:")]
        public virtual ICollection<Description> Descriptions // Navigation property
        {
            get { return this.descriptions; }
            set { this.descriptions = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.DateOfCreation}";
        }
    }
}
