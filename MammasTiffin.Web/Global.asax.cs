using MammasTiffin.Web.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MammasTiffin.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperConfig.RegisterAutoMapperConfigurations();
        }
        protected void Application_BeginRequest()
        {

        }
        protected void Application_AuthenticateRequest()
        {

        }
        protected void Application_PostResolveRequestCache()
        {

        }
    }
}
