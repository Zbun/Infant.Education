using Infant.Education.Controllers;
using Infant.Education.Core.IocFactory;
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

        protected void Application_Error(object sender, EventArgs e)
        {
            var httpContext = ((MvcApplication)sender).Context;
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = "";
            var currentAction = "";
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                !string.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }
                if (currentRouteData.Values["action"] != null &&
                !string.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }
            var ex = Server.GetLastError();
            IController controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";
            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;
                if (!HttpContext.Current.IsDebuggingEnabled)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //记录日志
                    sb.AppendLine("错误页面：" + Request.Url.ToString());
                    sb.AppendFormat("错误代码：{0}  异常信息：{1} 错误源:{2}\r\n", (httpEx == null ? 201 : httpEx.GetHttpCode()), ex.Message, ex.Source);
                    sb.AppendLine("堆栈信息:" + ex.StackTrace);

                    try
                    {
                        //Util.WriteLog(sb.ToString());
                    }
                    catch { }
                }
                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;
                    default:
                        action = "Index";
                        if (!HttpContext.Current.IsDebuggingEnabled)
                        {
                            //Logger.Error(new LogModel("全局异常", httpEx.InnerException.Message, "商户Id：" + Library.App + ",会员信息：" + JsonConvert.SerializeObject(Library.MemberInfo)), httpEx);
                        }
                        break;
                }
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;
            routeData.Values["handleError"] = new HandleErrorInfo(ex, currentController, currentAction);
            routeData.Values["isCustomError"] = HttpContext.Current.IsCustomErrorEnabled;
            controller.Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            httpContext.Response.End();
        }
    }
}
