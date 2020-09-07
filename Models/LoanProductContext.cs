using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinance.Models
{
    public class LoanProductContext: DbContext
    {
        public LoanProductContext(DbContextOptions<LoanProductContext> options) : base(options)
        {

        }
        public DbSet<LoanProduct> LoanProduct { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LoanProduct>(entity =>
            {
                entity.Ignore(b => b.Banks);
                entity.Ignore(b => b.LoanTypes);
                entity.Property(b => b.Name)
                .IsRequired();
                entity.HasOne(b => b.Banks)
                .WithMany(navigationExpression: e => e.LoanProducts);
                entity.HasOne(b => b.LoanTypes)
                .WithMany(navigationExpression: e => e.LoanProducts);
                entity.Property(b => b.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(b => b.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });
        }
    }
}
