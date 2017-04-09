using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels.Words;

namespace WoW.Models.ViewModels.User
{
    public class ProfileVM
    {
        public string Name { get; set; }

        public IEnumerable<AllWordsOfUser> AllWords { get; set; }

        public UserInfo Info { get; set; }
    }
}
