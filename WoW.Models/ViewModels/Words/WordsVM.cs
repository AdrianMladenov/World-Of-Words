namespace WoW.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using EntityModels;

    public class WordsVM
    {
        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }
        
        public IEnumerable<Description> Descriptions { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
        
    }
}
