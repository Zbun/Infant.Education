using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework.Entities
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime LogDate { get; set; }

        [StringLength(10)]
        public string LogLevel { get; set; }

        [StringLength(100)]
        public string LogIdentity { get; set; }

        [StringLength(4000)]
        public string LogMessage { get; set; }

        [StringLength(4000)]
        public string LogException { get; set; }

        [StringLength(255)]
        public string LogLogger { get; set; }

        [StringLength(1000)]
        public string LogSource { get; set; }
    }
}
