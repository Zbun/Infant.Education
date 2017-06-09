using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infant.Education.Core
{
    public class AuthorizeFilterAttribute : AuthorizeAttribute
    {

        /// <summary>
        /// 是否需要登录
        /// </summary>
        public bool IsNeedLogin { get; set; } = true;

        /// <summary>
        /// 是否启用过滤器
        /// </summary>
        public bool IsEnable { get; set; } = true;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return UserContext.CurUserInfo != null;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var actionInstance = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeFilterAttribute), true).FirstOrDefault() ?? filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AuthorizeFilterAttribute), true).FirstOrDefault();

            if (actionInstance != null)
            {
                var filter = actionInstance as AuthorizeFilterAttribute;
                if (!filter.IsEnable) return;
                if (!filter.IsNeedLogin) return;
                if (UserContext.CurUserInfo == null)
                {
                    if (filterContext.Controller.TempData.ContainsKey("msg"))
                    {
                        filterContext.Controller.TempData["msg"] = "登录超时，请重新登录";
                    }
                    else
                    {
                        filterContext.Controller.TempData.Add("msg", "登录超时，请重新登录");
                    }
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
                    return;
                }
                base.OnAuthorization(filterContext);
            }
        }
    }
}