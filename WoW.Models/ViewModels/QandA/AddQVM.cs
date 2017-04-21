namespace WoW.Models.ViewModels.QandA
{
    using System.ComponentModel.DataAnnotations;

    public  class AddQVM
    {
        public int Id { get; set; }

        //[MaxLength(30)]
        //[Display(Name = "Дължина на думата")]
        //public int LetterCount { get; set; }

        //[Required]
        [MaxLength(30)]
        [Display(Name ="Думата която търсите")]
        public string Word { get; set; }
        //[Required]
        [Display(Name = "Описание")]
        public string Content { get; set; }

        public string Answer { get; set; }
    }
}
