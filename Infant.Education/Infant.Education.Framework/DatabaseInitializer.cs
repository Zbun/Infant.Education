using Infant.Education.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize()
        {
            Database.SetInitializer<EfDbContext>(
                   new ApplicationDbInitializer());
            using (var db = new EfDbContext())
            {
                db.Database.Initialize(true);
            }
        }
    }

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }
        private void InitializeIdentityForEf(EfDbContext context)
        {
            SysAdmin model = new SysAdmin("tom", "419187544@qq.com", "tom", Enums.UserType.Admin);
            context.SysAdminDbSet.Add(model);
            context.SaveChanges();
        }
    }
}
