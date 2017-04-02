using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoW.Data;

namespace WoW.Services
{
   public class Service
    {
        private WoWContext context;

        public Service()
        {
            this.context = new WoWContext();
        }

        protected WoWContext Context => this.context;
    }
}
