using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace FinanceApi.Infrastructure.Persistence
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }


        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Transaction> Transactions { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}