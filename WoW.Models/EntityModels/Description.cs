
namespace WoW.Models.EntityModels
{
    using System.Collections.Generic;

    public class Description
    {
        private ICollection<Word> words;
        
        public Description()
        {
            this.Words = new HashSet<Word>(); 
        }

        public int Id { get; set; }

        public string Content { get; set; }  //Validation, Required

        public virtual ICollection<Word> Words // Navigation property
        {
            get { return this.words; }
            set { this.words = value; }
        }


        public override string ToString()
        {
            return $"{this.Content};\t ";
        }
    }
}
