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

            var transaction = modelBuilder.Entity<Transaction>();

            transaction.HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            transaction.HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            transaction.Property(y => y.Description)
                .HasMaxLength(500);

            transaction.Property(y => y.Amount)
                .HasPrecision(18, 2);

            var user = modelBuilder.Entity<User>();

            user.Property(u => u.Nickname)
                .HasMaxLength(50)
                .IsRequired();

            user.Property(u => u.Email)
                .HasMaxLength(254)
                .IsRequired();

            user.HasIndex(u => u.Email)
                .IsUnique();

            var account = modelBuilder.Entity<Account>();

            account.Property(o => o.Name)
                .HasMaxLength(100)
                .IsRequired();

            account.Property(e => e.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            var financialGoal = modelBuilder.Entity<FinancialGoal>();

            financialGoal.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            financialGoal.Property(e => e.TargetAmount)
                .HasPrecision(18, 2);

            financialGoal.Property(e => e.CurrentAmount)
                .HasPrecision(18, 2);
        }
    }
}
