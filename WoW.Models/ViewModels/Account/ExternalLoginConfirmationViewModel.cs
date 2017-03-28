using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Models.ViewModels.Account
{
   public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
