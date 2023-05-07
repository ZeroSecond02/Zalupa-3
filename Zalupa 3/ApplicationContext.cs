using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zalupa_3
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
