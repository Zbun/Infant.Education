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
            MessageInfo messageInfo = new MessageInfo(model,"欢迎使用由tom团队为您定制开发的后台管理系统，该平台支持响应式操作，您可以在手机上、pad上直接操作管理后台，如果您有什么问题可以电话联系我13673661182");
            context.MessageInfoDbSet.Add(messageInfo);
            context.SaveChanges();
        }
    }
}
