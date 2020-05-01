using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add below namespace for GlobalConfiguration
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.App_Start;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //intialize the auto mapper here
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            //Add GlobalConfiguration for configure webapi
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}