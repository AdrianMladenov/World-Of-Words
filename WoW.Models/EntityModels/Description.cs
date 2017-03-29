using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW.Models.EntityModels
{
   public class Description
    {
        private ICollection<Word> words;

        public Description()
        {

        }

        public Description(string content)
        {
            this.Content = content;
            this.Words = new HashSet<Word>(); 
        }

        public int Id { get; set; }

        public string Content { get; set; }  //Validation, Required

        public virtual ICollection<Word> Words // Navigation property
        {
            get { return this.words; }
            set { this.words = value; }
        }
    }
}
