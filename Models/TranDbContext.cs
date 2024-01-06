using Microsoft.EntityFrameworkCore;

namespace TransectionTest1.Models
{
    public class TranDbContext:DbContext
    {
        public TranDbContext(DbContextOptions<TranDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction23cs> TransactionsGP { get; set; }
    }
}
