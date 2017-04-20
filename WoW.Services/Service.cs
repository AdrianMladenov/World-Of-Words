namespace WoW.Services
{
    using Data;

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
