
namespace WoW.Models.EntityModels
{
    using System;
    using System.Collections.Generic;

    public class Word
    {
        private ICollection<Description> descriptions;

        public Word()
        {

        }

        public Word(string name)
        {
            this.Name = name;
            this.DateAdded = DateTime.Now;
            this.Descriptions = new HashSet<Description>();
        }

        
        public int Id { get; set; } //Auto-generated

        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public int UserId { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual ICollection<Description> Descriptions // Navigation property
        {
            get { return this.descriptions; }
            set { this.descriptions = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.DateAdded}";
        }
    }
}
