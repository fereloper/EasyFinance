using Microsoft.EntityFrameworkCore;


namespace EasyFinance.Models
{
    public class LoanTypeContext:DbContext
    {
        public LoanTypeContext(DbContextOptions<LoanTypeContext> options) : base(options)
        {

        }
        public DbSet<LoanTypes> LoanTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanTypes>(entity =>
            {
                entity.Property(b => b.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(b => b.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(b => b.Status)
                 .HasDefaultValue(true);

            });
        }
    }
}
