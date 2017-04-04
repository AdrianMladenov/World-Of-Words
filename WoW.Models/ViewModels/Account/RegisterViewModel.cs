using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Models.ViewModels.Account
{
   public class RegisterViewModel
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Ел. Поща")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде с дължина поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("Password", ErrorMessage = "Паролата не съвпада, моля попълнете полето Повтори парола отново.")]
        public string ConfirmPassword { get; set; }
    }
}
