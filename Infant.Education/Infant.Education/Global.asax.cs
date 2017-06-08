﻿using Infant.Education.Core.IocFactory;
using Infant.Education.Framework;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Infant.Education
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            DatabaseInitializer.Initialize();
        }
    }
}
