using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WoW.Models.EntityModels
{
    public class Enum
    {
        public int EnumId { get; set; }

        public enum SocialStatus
        {
            [Display(Name ="Ученик")]
            SchollBoy = 0,

            [Display(Name = "Студент")]
            Student = 1,

            [Display(Name = "Работник в частния сектор")]
            EmployeeInPrivateSector = 2,

            [Display(Name = "Работник в държавния сектор")]
            EmployeeInPublicSector = 3,

            [Display(Name = "Ръкововдител в частния сектор")]
            ManagerInPrivateSector = 4,

            [Display(Name = "Ръкововдител в държавния сектор")]
            ManagerInPublicSector = 5,

            [Display(Name = "Не работя в момента")]
            NotWorkingAtTheMoment = 6,

            [Display(Name = "Нещо друго")]
            SomethingElse = 7
        }

        public enum Gender
        {
            [Description("Мъж")]
            Male = 0,

            [Description("Жена")]
            Female = 1
        }

        public enum EducationDegree
        {
            [Display(Name ="Начално")]
            Basic = 0,

            [Display(Name = "Основно")]
            PrimaryEducation = 1,

            [Display(Name = "Средно")]
            SecondaryEducation = 2,

            [Display(Name = "Средно-специално")]
            SecondarySpecialEducation = 3,

            [Display(Name = "Полувисше")]
            HalfHighEducation = 4,

            [Display(Name = "Висше")]
            HighEducation = 5,                          
        }

        public enum WorkingSphere
        {
            [Display(Name ="ИТ")]
            IT = 0,
            [Display(Name = "Здравеопазване")]
            HealthCare = 1,

            [Display(Name = "Култура и изкуство")]
            CultureAndArt = 2,

            [Display(Name = "Маркетинг и реклама")]
            MarketingAndCommercials = 3,

            [Display(Name = "Образование и наука")]
            EducationAndScience = 4,

            [Display(Name = "Промишленост")]
            Industry = 5,

            [Display(Name = "спорт")]
            Sport = 6,

            [Display(Name = "Търговия")]
            Trading = 7,

            [Display(Name = "Услуги")]
            Utilities = 8,

            [Display(Name = "Банково дело и финанси")]
            BankAndFinance = 9,

            [Display(Name = "Нещо друго")]
            SomethingElse = 10
        }
    }
}
