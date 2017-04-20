namespace WoW.Models.ViewModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;

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
