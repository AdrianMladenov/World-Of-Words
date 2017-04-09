using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WoW.Models.EntityModels;
using WoW.Models.ViewModels;
using WoW.Models.ViewModels.QandA;
using WoW.Models.ViewModels.User;
using WoW.Models.ViewModels.Words;

namespace WoW
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(exp =>
            {
                exp.CreateMap<Word, WordsVM>();
                exp.CreateMap<WordForValidate, AddWordVM>();
                exp.CreateMap<WordForValidate, AllWordsOfUser>();
                exp.CreateMap<Question, AddQVM>();
                exp.CreateMap<Question, QADetails>();
                exp.CreateMap<ApplicationUser, ProfileVM>();
            });
        }
    }
}
