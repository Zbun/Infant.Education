using Infant.Education.Common;
using Infant.Education.Framework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infant.Education.Core
{
    public class UserContext
    {
        private static string sessionKey = "SysAdminSession";
        private static string cookieKey = "SysAdminCookie";
        private static bool checkCookie = ConfigHelper.GetBool("AdminCookie");//当session验证失败时，是否从cookie中检查登录信息

        public static bool IsLogin { get { return CurUserInfo != null; } }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static SysAdmin CurUserInfo
        {
            get
            {
                SysAdmin user = SessionHelper.Get<SysAdmin>(sessionKey);
                //从session读取信息失败，尝试从cookies里读取加密数据
                if (user == null && checkCookie)
                {
                    HttpCookie cookie = CookieHelper.Get(cookieKey);
                    if (cookie != null)
                    {
                        string userinfoStr = (DESEncrypt.Decrypt(cookie["userinfo"] ?? string.Empty)).GetSafe();//cookie用户名解密
                    
                        if (userinfoStr.Length > 1)
                        {
                            try
                            {
                                user = JsonConvert.DeserializeObject<SysAdmin>(userinfoStr);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                return user;
            }
        }

        public static void SetLoginSessionAndCookie(SysAdmin user)
        {
            SessionHelper.Set(sessionKey, user);//session信息
            if (checkCookie)
            {
                //保存信息到cookie中
                HttpCookie cookie = CookieHelper.Set(cookieKey);
                cookie["userinfo"] = DESEncrypt.Encrypt(JsonConvert.SerializeObject(user));
                CookieHelper.Save(cookie);
            }
        }

        /// <summary>
        /// 登出操作
        /// </summary>
        public static void LoginOut()
        {
            SessionHelper.Remove(sessionKey);

            HttpCookie cookie = CookieHelper.Get(cookieKey);
            if (cookie != null)
            {
                cookie["userinfo"] = "";
                CookieHelper.Save(cookie);
                CookieHelper.Remove(cookie);
            }
        }

      
    }
}
