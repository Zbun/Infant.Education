using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infant.Education.Core
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var authorizeType = new AuthorizeTypeAttribute();

            #region 当前action是否需要进行权限判断
            string strArea = (filterContext.RouteData.Values["area"] ?? filterContext.RouteData.DataTokens["area"] ?? "").ToString();
            //手机访问不用验证登录权限
            if (strArea.ToLower().Contains("phone"))
            {
                return;
            }
            string strController = (filterContext.RouteData.Values["controller"] ?? filterContext.RouteData.DataTokens["controller"] ?? "").ToString();
            string strAction = (filterContext.RouteData.Values["action"] ?? filterContext.RouteData.DataTokens["action"] ?? "").ToString();

            var controller = ControllerBuilder.Current.GetControllerFactory().CreateController(filterContext.RequestContext, strController);
            object[] objs = controller.GetType().GetCustomAttributes(typeof(AuthorizeTypeAttribute), true);
            if (objs.Length > 0)
            {//controller上有标记
                authorizeType = objs[0] as AuthorizeTypeAttribute;
            }
            else
            {
                objs = controller.GetType().GetMethods().First(x => x.Name == strAction).GetCustomAttributes(typeof(AuthorizeTypeAttribute), true);
                if (objs != null && objs.Length > 0)
                {//action上有标记，
                    authorizeType = objs[0] as AuthorizeTypeAttribute;
                }
            }
            #endregion

            if (!authorizeType.NeedLogin)
                return;

            if (UserContext.CurUserInfo == null)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("~/Account/Login");
            }
        }
    }
}