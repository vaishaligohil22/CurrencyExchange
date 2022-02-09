using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CurrecyExchangeDB.Models
{
    public partial class ExchangeRateContext : DbContext
    {
        public ExchangeRateContext()
        {
        }

        public ExchangeRateContext(DbContextOptions<ExchangeRateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NOOSL5V4Q4Y2;Initial Catalog=ExchangeRate;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.ToTable("ExchangeRate");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.CurrFromNavigation)
                    .WithMany(p => p.ExchangeRateCurrFromNavigations)
                    .HasForeignKey(d => d.CurrFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeRate_Currency");

                entity.HasOne(d => d.CurrToNavigation)
                    .WithMany(p => p.ExchangeRateCurrToNavigations)
                    .HasForeignKey(d => d.CurrTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeRate_Currency1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
