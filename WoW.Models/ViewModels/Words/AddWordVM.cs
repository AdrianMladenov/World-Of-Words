namespace WoW.Models.ViewModels.Words
{
    using System.ComponentModel.DataAnnotations;
    using EntityModels;

    public class AddWordVM
    {
        public int Id { get; set; }
      
        [Display(Name = "Дума")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Required]
        public string Description { get; set; }

        public ApplicationUser User { get; set; }

    }
}
