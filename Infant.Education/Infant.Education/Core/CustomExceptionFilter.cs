using Infant.Education.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infant.Education.Core
{
    public class CustomExceptionFilter : HandleErrorAttribute
    {
        public CustomExceptionFilter()
        {
            base.Order = 1;
        }

        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            //如果是AJAX请求返回json
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                 //   Data = MessageViewModel.Faild(data: filterContext.Exception.Message)
                };
            }
            else
            {
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                filterContext.Result = new ViewResult()
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary(model),
                    TempData = filterContext.Controller.TempData
                };
            }
            if (!filterContext.HttpContext.IsDebuggingEnabled)
            {
                //string userInfo = "商户id" + Library.App + ",会员信息：" + JsonConvert.SerializeObject(Library.MemberInfo);
                //Logger.Error(new LogModel("自定义异常过滤器", "controller:" + controllerName + "，action:" + actionName, userInfo), filterContext.Exception);
            }
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}