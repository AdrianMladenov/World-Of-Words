
using System;

namespace WoW.Models.EntityModels
{
   public class WordForValidate
    {
        
        public WordForValidate()
        {

        }

        public WordForValidate(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.dateAdded = DateTime.Now;
            this.IsValid = false;
            this.IsCorrectWord = false;
        }


        public int Id { get; set; } //Auto-generated

        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public int UserId { get; set; }

        public string Description { get; set; }

        public DateTime dateAdded { get; set; }

        public bool IsValid { get; set; }

        public bool IsCorrectWord { get; set; }
    }
}
