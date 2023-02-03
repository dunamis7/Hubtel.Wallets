using Microsoft.EntityFrameworkCore;

namespace Hubtel.Wallets.Api.Models
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>()
                .HasOne(u => u.User)
                .WithMany(w => w.Wallets)
                .HasForeignKey(a => a.UserId);
        }
        
        
    }
}