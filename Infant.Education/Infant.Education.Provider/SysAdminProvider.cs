using Infant.Education.Common;
using Infant.Education.Framework;
using Infant.Education.Framework.Entities;
using Infant.Education.Framework.Enums;
using Infant.Education.IProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Provider
{
    public class SysAdminProvider : EfRepositoryBase<EfDbContext, SysAdmin>, ISysAdminProvider
    {
        private readonly IRepository<SysAdmin> sysAdminRepository;
        private readonly IRepository<MessageInfo> messageInfoRepository;
        public SysAdminProvider(IUnitOfWork UnitOfWork,
             IRepository<SysAdmin> _sysAdminRepository,
             IRepository<MessageInfo> _messageInfoRepository) : base(UnitOfWork)
        {
            sysAdminRepository = _sysAdminRepository;
            messageInfoRepository = _messageInfoRepository;
        }

        public async Task<SysAdmin> Login(string userName, string password, UserType usetype)
        {
            var md5Str = Md5.Encrypt(password);
            var userInfo = await sysAdminRepository.Get(x => x.UserName == userName && x.PassWord == md5Str && x.IdentityType == usetype);
            if (userInfo != null)
            {
                userInfo.LastLoginTime = DateTime.Now;
                userInfo.LastLoginIP = WebHandle.UserIP;
                userInfo.LoginTimes += 1;
                sysAdminRepository.Update(userInfo);
                messageInfoRepository.Insert(new MessageInfo(userInfo, string.Format("{0} {1} 登录了系统", usetype == UserType.Admin ? "管理员" : "用户", userInfo.RealName), 1));
            }
            return userInfo;
        }
    }
}
