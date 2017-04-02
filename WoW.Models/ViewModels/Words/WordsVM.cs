using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Models.ViewModels
{
   public class WordsVM
    {
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }
        
        public IEnumerable<Description> Descriptions { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"{this.Name} {this.DateAdded}");
        //    sb.AppendLine("Описание:");
        //    foreach (var description in Descriptions)
        //    {
        //        sb.AppendLine(description.Content.ToString());

        //    }
        //    return sb.ToString();
        //}
    }
}
