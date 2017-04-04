using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Models.ViewModels.Words
{
    public class AddWordVM
    {

        [Display(Name = "Дума")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public ApplicationUser User { get; set; }

    }
}
