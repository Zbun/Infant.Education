using Infant.Education.Core;
using Infant.Education.Framework;
using Infant.Education.Framework.Entities;
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
        public HomeController(IRepository<MessageInfo> _messageInfoRepository)
        {
            messageInfoRepository = _messageInfoRepository;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.MessageInfoList = await messageInfoRepository.Entities.Include(x => x.SysAdmin).Where(x => !x.IsDeleted).OrderBy(x => x.AddDate).ToListAsync();
            //获取用户留言信息
            return View();
        }

        public ActionResult LogOff()
        {
            UserContext.LoginOut();
            return RedirectToAction("Login", "Account");
        }
        
    }
}