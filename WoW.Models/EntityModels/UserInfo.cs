
namespace WoW.Models.EntityModels
{
    using System;

    public class UserInfo
    {
        public UserInfo()
        {

        }

        public UserInfo(int age, string firstName, string lastName, Enum.Gender gender, Enum.SocialStatus socialStatus, Enum.EducationDegree educationDegree, Enum.WorkingSphere workingSphere)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.RegistrationDate = DateTime.Now;
            this.Gender = gender;
            this.SocialStatus = socialStatus;
            this.EducationDegree = educationDegree;
            this.WorkingSphere = workingSphere;
        }

        public int Id { get; set; }

        public string FirstName { get; set; } //Optional

        public string LastName { get; set; } //Optional

        public int Age { get; set; } //Validation

        public DateTime RegistrationDate { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Enum.SocialStatus SocialStatus { get; set; }

        public Enum.Gender Gender { get; set; }

        public Enum.EducationDegree EducationDegree { get; set; }

        public Enum.WorkingSphere WorkingSphere { get; set; }
    }
}
