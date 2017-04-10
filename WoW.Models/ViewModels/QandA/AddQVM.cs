using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Models.ViewModels.QandA
{
  public  class AddQVM
    {
        public int Id { get; set; }

        //[MaxLength(30)]
        //[Display(Name = "Дължина на думата")]
        //public int LetterCount { get; set; }

        //[Required]
        [MaxLength(30)]
        [Display(Name ="Думата която търсите")]
        public string Word { get; set; }

        [Display(Name = "Описание")]
        public string Content { get; set; }

        public string Answer { get; set; }
    }
}
