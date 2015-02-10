using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Dashboard.SourceControl.Bitbucket.Queries;
using Dashboard.SourceControl.Contracts;
using Dashboard.Web.Controllers;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Dashboard.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // TODO move out to its own class, also register mappings etc...
            var container = new Container();

            var queryAssembly = typeof (AccountByUserNameQuery).Assembly;

            var registrations =
                queryAssembly.GetExportedTypes()
                    .Where(type => type.Namespace == "Dashboard.SourceControl.Bitbucket.Queries")
                    .Where(type => type.GetInterfaces().Any())
                    .Select(type => new {Query = type.GetInterfaces().Single(), Implementation = type});

            foreach (var reg in registrations)
            {
                container.Register(reg.Query, reg.Implementation, Lifestyle.Transient);
            }

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}