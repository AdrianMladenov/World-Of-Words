﻿
namespace WoW.Models.EntityModels
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using ViewModels.Words;

    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            this.IsDeleted = false;
            this.Words = new HashSet<Word>();
            this.Questions = new HashSet<Question>();
            this.Answers = new HashSet<Answer>();
        }

        public bool? IsDeleted { get; set; }
        
        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        
        public virtual UserInfo UserInfo { get; set; }

        public virtual ICollection<Word> Words { get; set; }

        public virtual ICollection<WordForValidate> WordsForValidate { get; set; }

        public override string ToString()
        {
            return $"{this.UserName}";
        }

        //public virtual  AddWordVM wordsForValidation { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
    }
}
