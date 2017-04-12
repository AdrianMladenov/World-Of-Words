
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoW.Models.EntityModels
{
   public class WordForValidate
    {
      
        public WordForValidate()
        {
            this.DateOfCreation = DateTime.Now;
            this.LastModifed = DateTime.Now;
            this.IsValid = false;
            this.IsDeleted = false;
        }


        public int Id { get; set; } //Auto-generated

        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public int UserId { get; set; }

            //TODO set max description length 
        //[Display(Name = "Описание:")]
        public string Description { get; set; }

        //[Display(Name = "Дата на добавяне:")]
        public DateTime DateOfCreation { get; set; }

        public DateTime LastModifed { get; set; }

        //[Display(Name = "Статус:")]
        public bool IsValid { get; set; }
        
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.DateOfCreation} {this.IsValid.ToString()}";
        }
    }
}
