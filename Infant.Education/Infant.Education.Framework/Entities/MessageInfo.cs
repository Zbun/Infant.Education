using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public MessageInfo(SysAdmin sysAdmin, string content, int sort)
        {
            UserId = sysAdmin.Id;
            Content = content;
            Sort = sort;
        }
        public int Id { get; set; }

        public virtual SysAdmin SysAdmin { get; set; }

        [StringLength(200), Required]
        public string Content { get; set; }

        public int Sort { get; set; }

        [ForeignKey("SysAdmin")]
        public int UserId { get; set; }
    }
}
