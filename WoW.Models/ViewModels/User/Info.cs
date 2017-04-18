using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Models.ViewModels.User
{
    public class Info
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
        
        public EntityModels.Enum.Gender Gender { get; set; }

        public EntityModels.Enum.EducationDegree EducationDegree { get; set; }

        public EntityModels.Enum.WorkingSphere WorkingSphere { get; set; }

        public EntityModels.Enum.SocialStatus SocialStatus { get; set; }
    }
}
