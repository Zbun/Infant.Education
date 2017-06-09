using Infant.Education.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infant.Education.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取用户列表数据
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetUserInfoList()
        {
            return Json("");
        }
    }
}