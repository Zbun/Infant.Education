using Infant.Education.Core;
using Infant.Education.Framework;
using Infant.Education.Framework.Entities;
using Infant.Education.IProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infant.Education.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository<MessageInfo> messageInfoRepository;
        private readonly ISysAdminProvider sysAdminProvider;
        public HomeController(IRepository<MessageInfo> _messageInfoRepository,
            ISysAdminProvider _sysAdminProvider)
        {
            messageInfoRepository = _messageInfoRepository;
            sysAdminProvider = _sysAdminProvider;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.MessageInfoList = await messageInfoRepository.Entities.Where(x => !x.IsDeleted).OrderByDescending(x => x.Sort).ThenBy(x => x.AddDate).Take(11).ToListAsync();
            //获取用户信息
            var userList = await sysAdminProvider.Entities.Where(x => x.IdentityType == Framework.Enums.UserType.User && !x.IsDeleted).ToListAsync();
            return View(userList);
        }

        public ActionResult LogOff()
        {
            UserContext.LoginOut();
            return RedirectToAction("Login", "Account");
        }

    }
}