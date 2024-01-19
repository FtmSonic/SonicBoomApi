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
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractEvent> ContractEvents { get; set; }

        public SonicDbContext(DbContextOptions options)
    : base(options)
        {
        }

    }
}
