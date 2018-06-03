using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject; 
using Ninject.Web.Mvc;
using BLL.Infrastructure;
using WebApp.Util;

namespace WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

       //     GlobalConfiguration.Configure(WebApiConfig.Register);
       

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule  lotsModulle = new LotsModulle();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(lotsModulle, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
