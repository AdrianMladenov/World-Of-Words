namespace WoW.Models.ViewModels.QandA
{
    using System.ComponentModel.DataAnnotations;

    public class AddAVM
    {
        public int Id { get; set; }

        
        [Display(Name ="Отговор")]
        public string Answer { get; set; }
        
        public string User { get; set; }

        public string Question { get; set; }
    }
}
