﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoW.Models.EntityModels
{
   public class WordForValidate
    {
      
        public WordForValidate()
        {
            this.dateAdded = DateTime.Now;
            this.IsValid = false;
            this.IsDeleted = false;
        }


        public int Id { get; set; } //Auto-generated

        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public int UserId { get; set; }

        //[Display(Name = "Описание:")]
        public string Description { get; set; }

        //[Display(Name = "Дата на добавяне:")]
        public DateTime dateAdded { get; set; }

        //[Display(Name = "Статус:")]
        public bool IsValid { get; set; }
        
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.dateAdded} {this.IsValid.ToString()}";
        }
    }
}
