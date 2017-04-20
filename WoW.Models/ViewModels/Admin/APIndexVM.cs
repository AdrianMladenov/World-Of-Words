namespace WoW.Models.ViewModels.Admin
{
    using System.Collections.Generic;
    using Words;

    public class APIndexVM
    {
        public IEnumerable<AllWordsOfUser> AllWordsForValidate { get; set; }

        public IEnumerable<APUsersInfoVM> UsersInfo { get; set; }
    }
}
