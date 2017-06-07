using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework
{
    public class EfUnitOfWorkContext : UnitOfWorkContextBase
    {
        /// <summary>
        ///     获取或设置 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get { return EfContext; }
        }

        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>

        public EfDbContext EfContext { get; set; } = new EfDbContext();
    }
}
