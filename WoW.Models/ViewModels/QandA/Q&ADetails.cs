using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Models.EntityModels;

namespace WoW.Models.ViewModels.QandA
{
    public class QADetails
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
