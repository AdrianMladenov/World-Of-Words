using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Models.ViewModels.Words
{
   public class AddWordVM
    {
      
        public string Name { get; set; }

        public string Description { get; set; }

        public ApplicationUser User { get; set; }

    }
}
