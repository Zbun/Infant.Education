using Infant.Education.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infant.Education.Framework
{
    public class EfDbContext : DbContext
    {
        public IDbSet<Log> LogDbSet { get; set; }

        public EfDbContext() : base("Default")
        { }
    }
}
