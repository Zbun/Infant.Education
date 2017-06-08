using Infant.Education.Framework;
using Infant.Education.Framework.Entities;
using Infant.Education.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.IProvider
{
    public interface ISysAdminProvider : IRepository<SysAdmin>
    {
        Task<SysAdmin> Login(string userName, string password, UserType usetype);
    }
}
