using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Models.ViewModels.QandA
{
    public class AddAVM
    {
        public int Id { get; set; }

        [Required]
        public string Answer { get; set; }
        
        public string User { get; set; }

        public string Question { get; set; }
    }
}
