using Infant.Education.Common;
using Infant.Education.Framework.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework.Entities
{
    [SerializableAttribute()]
    public partial class SysAdmin : Entity
    {

        public SysAdmin()
        { }

        public SysAdmin(string username,string password,string realname, UserType usertype)
        {
            UserName = username;
            PassWord = Md5.Encrypt(password);
            RealName = realname;
            LoginTimes = 0;
            Enabled = 1;
            IdentityType = usertype;
        }
        #region 属性

        /// <summary>
        /// 自增编号
        /// </summary>		
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空！")]
        [StringLength(20, ErrorMessage = "用户名长度不能超过20个字符！")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string PassWord { get; set; }

        /// <summary>
        /// 所属角色ID,逗号隔开
        /// </summary>
        [StringLength(50, ErrorMessage = "*")]
        public string RoleIds { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(50, ErrorMessage = "*")]
        public string RealName { get; set; }

        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        [StringLength(50, ErrorMessage = "*")]
        public string LastLoginIP { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        [RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        [Required(ErrorMessage = "*")]
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int LoginTimes { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Required(ErrorMessage = "*")]
        [RegularExpression("-?\\d+", ErrorMessage = "*")]
        public int Enabled { get; set; }

        /// <summary>
        /// 添加人
        /// </summary>
        [StringLength(50, ErrorMessage = "*")]
        public string AddUser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [RegularExpression("^\\d{4}(\\-|\\/|\\.)\\d{1,2}\\1\\d{1,2}(\\s\\d{1,2}:\\d{1,2}:\\d{1,2})?$", ErrorMessage = "*")]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(50, ErrorMessage = "*")]
        public string UpdateUser { get; set; }

        /// <summary>
        /// 性别0男 1女
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType IdentityType { get; set; }
        #endregion

    }
}
