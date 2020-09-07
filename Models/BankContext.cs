using Microsoft.EntityFrameworkCore;


namespace EasyFinance.Models
{
    public class BankContext :DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
        public DbSet<Banks> Banks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Banks>(entity =>
            {
                entity.Property(b => b.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(b => b.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });
        }
    }
}
