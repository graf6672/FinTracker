using Microsoft.EntityFrameworkCore;
using FinTracker.Domain.Entities;

namespace FinTracker.Infrastructure.Persistence
{
    public class FinTrackerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<FinancialGoal> FinancialGoals { get; set; }

        public FinTrackerDbContext(DbContextOptions<FinTrackerDbContext> options) : base(options)
        { 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
