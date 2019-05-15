using trapperkeeper_mvc.Models.Finances;
using Microsoft.EntityFrameworkCore;

namespace trapperkeeper_mvc.Models
{
    public class TrapperKeeperContext : DbContext
    {
        public TrapperKeeperContext() => Database.EnsureCreated();

        public TrapperKeeperContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=localhost;database=finances;user=trapperkeeper;password=Hudson666!");


        public DbSet<TransactionLedger> TransactionLedger { get; set; }
        public DbSet<TransactionEntry> TransactionEntry { get; set; }
    }
}
