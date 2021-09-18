using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Managemail.DAL.Entities
{
    public partial class ManagemailContext : DbContext
    {
        public ManagemailContext(DbContextOptions<ManagemailContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailHistory> EmailHistories { get; set; }
        public virtual DbSet<ImportanceType> ImportanceTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmailHistory>(entity =>
            {
                entity.ToTable("EmailHistory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CcemailAddress)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("CCEmailAddress");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FromEmailAddress)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ToEmailAddress)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.ImportanceType)
                    .WithMany(p => p.EmailHistories)
                    .HasForeignKey(d => d.ImportanceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailHistory_ImportanceType");
            });

            modelBuilder.Entity<ImportanceType>(entity =>
            {
                entity.ToTable("ImportanceType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Abrv)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
