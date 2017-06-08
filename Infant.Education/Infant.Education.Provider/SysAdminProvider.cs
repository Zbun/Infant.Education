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
        public SysAdminProvider(IUnitOfWork UnitOfWork,
             IRepository<SysAdmin> _sysAdminRepository) : base(UnitOfWork)
        {
            sysAdminRepository = _sysAdminRepository;
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
            }
            return userInfo;
        }
    }
}
