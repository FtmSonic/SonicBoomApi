using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicBoomOrm
{
    public class SonicDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

    }
}
