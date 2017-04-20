namespace WoW.Models.ViewModels.Words
{
    using System.ComponentModel.DataAnnotations;

    public class SearchedWordVM
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Думата която търсите")]
        public string Word { get; set; }

        //public string WordWOSpaces { get; set; }

        [Display(Name = "Описание")]
        public string Content { get; set; }
    }
}
