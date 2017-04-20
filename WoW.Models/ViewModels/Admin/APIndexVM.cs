using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.ViewModels.Words;

namespace WoW.Models.ViewModels.Admin
{
   public class APIndexVM
    {
        public IEnumerable<AllWordsOfUser> AllWordsForValidate { get; set; }

        public IEnumerable<APUsersInfoVM> UsersInfo { get; set; }
    }
}
