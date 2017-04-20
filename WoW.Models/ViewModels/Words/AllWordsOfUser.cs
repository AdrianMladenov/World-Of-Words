namespace WoW.Models.ViewModels.Words
{
    using EntityModels;

    public class AllWordsOfUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //[Display(Name ="Описание:")]
        public string Description { get; set; }

       // [Display(Name = "Статус:")]
        public bool IsValid { get; set; }

        public ApplicationUser  User { get; set; }

    }
}
