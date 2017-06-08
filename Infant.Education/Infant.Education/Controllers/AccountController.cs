using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Infant.Education.Models;
using Infant.Education.IProvider;
using Infant.Education.Common;
using Infant.Education.Core;
using Infant.Education.Framework.Enums;

namespace Infant.Education.Controllers
{
    [AuthorizeType(NeedLogin =false)]
    public class AccountController : BaseController
    {
        private readonly ISysAdminProvider sysAdminProvider;
        public AccountController(ISysAdminProvider _sysAdminProvider)
        {
            sysAdminProvider = _sysAdminProvider;
        }
         
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            TempData["msg"] = "";
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "用户名或密码错误";
            }
            else
            {
                var userInfo = await sysAdminProvider.Login(model.UserName.GetSafe(), model.Password, UserType.Admin);
                if (userInfo == null)
                {
                    TempData["msg"] = "用户名或密码错误";
                }
                else
                {
                    UserContext.SetLoginSessionAndCookie(userInfo);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}