using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Models.ViewModels.Words
{
    public class SearchedWordVM
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Думата която търсите")]
        public string Word { get; set; }

        [Display(Name = "Описание")]
        public string Content { get; set; }

    }
}
