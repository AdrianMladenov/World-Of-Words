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
using WoW.Models.ViewModels.Admin;
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
                exp.CreateMap<UserInfo, Info>();
                exp.CreateMap<ApplicationUser, APUsersInfoVM>()
                .ForMember(vm => vm.Username, 
                configExpr => configExpr.MapFrom(user => user.UserName))
                .ForMember(vm => vm.Role,
                configExpr => configExpr.MapFrom(user => user.Roles))
                .ForMember(vm => vm.FirstName,
                configExpr => configExpr.MapFrom(user => user.UserInfo.FirstName))
                .ForMember(vm => vm.LastName,
                configExpr => configExpr.MapFrom(user => user.UserInfo.LastName));
            });
        }
    }
}
