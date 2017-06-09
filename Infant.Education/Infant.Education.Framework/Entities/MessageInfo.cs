using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework.Entities
{
    /// <summary>
    /// 用户留言信息
    /// </summary>
    public class MessageInfo : Entity
    {
        public MessageInfo()
        {
        }

        public MessageInfo(SysAdmin sysAdmin,string content)
        {
            SysAdmin = sysAdmin;
            Content = content;
        }
        public int Id { get; set; }

        public SysAdmin SysAdmin { get; set; }

        [StringLength(200), Required]
        public string Content { get; set; }
    }
}
