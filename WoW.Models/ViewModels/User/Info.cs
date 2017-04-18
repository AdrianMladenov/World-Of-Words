using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Models.ViewModels.User
{
    public class Info
    {
        [Display(Name = "Собствено име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Години")]
        public int Age { get; set; }
        
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Пол")]
        public EntityModels.Enum.Gender Gender { get; set; }

        [Display(Name = "Степен на образование")]
        public EntityModels.Enum.EducationDegree EducationDegree { get; set; }

        [Display(Name = "Работна среда")]
        public EntityModels.Enum.WorkingSphere WorkingSphere { get; set; }
        
        [Display(Name = "Статут")]
        public EntityModels.Enum.SocialStatus SocialStatus { get; set; }
    }
}
