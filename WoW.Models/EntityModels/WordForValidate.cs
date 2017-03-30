using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Models.EntityModels
{
   public class WordForValidate
    {
        
        public WordForValidate()
        {

        }

        public WordForValidate(string name)
        {
            this.Name = name;
            this.IsValid = false;
            this.IsCorrectWord = false;
        }


        public int Id { get; set; } //Auto-generated

        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public int UserId { get; set; }

        public string Description { get; set; }

        public bool IsValid { get; set; }

        public bool IsCorrectWord { get; set; }
    }
}
