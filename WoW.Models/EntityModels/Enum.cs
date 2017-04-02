namespace WoW.Models.EntityModels
{
    public class Enum
    {
        public int EnumId { get; set; }

        public enum SocialStatus
        {
            SchollBoy = 0,
            Student = 1,
            EmployeeInPrivateSector = 2,
            EmployeeInPublicSector = 3,
            ManagerInPrivateSector = 4,
            ManagerInPublicSector = 5,
            NotWorkingAtTheMoment = 6,
            SomethingElse = 7
        }

        public enum Gender
        {
            Male = 0,
            Female = 1
        }

        public enum EducationDegree
        {
            Basic = 0,                                  //Начално   
            PrimaryEducation = 1,                       //Основно
            SecondaryEducation = 2,                     //Средно
            SecondarySpecialEducation = 3,              //Средно специално
            HalfHighEducation = 4,                      //Полувисше
            HighEducation = 5,                          //Висше
        }

        public enum WorkingSphere
        {
            IT = 0,
            HealthCare = 1,
            CultureAndArt = 2,
            MarketingAndCommercials = 3,
            EducationAndScience = 4,
            Industry = 5,
            Sport = 6,
            Trading = 7,
            Utilities = 8,
            BankAndFinance = 9,
            SomethingElse = 10
        }
    }
}
