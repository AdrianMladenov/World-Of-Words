using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.Words;


namespace WoW.Models.ViewModels.User
{
    public class ProfileVM
    {
        [NotMapped]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public int WordCount { get; set; }

        public Info Info { get; set; }
        
    }
}
