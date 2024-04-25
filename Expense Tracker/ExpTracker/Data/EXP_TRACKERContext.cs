using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExpTracker.Data
{
    public partial class EXP_TRACKERContext : DbContext
    {
        public EXP_TRACKERContext()
        {
        }

        public EXP_TRACKERContext(DbContextOptions<EXP_TRACKERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerExpense> CustomerExpense { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EXP_TRACKER;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustId).HasColumnName("CUST_ID");

                entity.Property(e => e.CustEmail)
                    .HasColumnName("CUST_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustFname)
                    .HasColumnName("CUST_FNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustImageUrl)
                    .HasColumnName("CUST_IMAGE_URL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustLname)
                    .HasColumnName("CUST_LNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustPassword)
                    .HasColumnName("CUST_PASSWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerExpense>(entity =>
            {
                entity.HasKey(e => e.CeId);

                entity.ToTable("CUSTOMER_EXPENSE");

                entity.Property(e => e.CeId).HasColumnName("CE_ID");

                entity.Property(e => e.CeCustId).HasColumnName("CE_CUST_ID");

                entity.Property(e => e.CeEcId).HasColumnName("CE_EC_ID");

                entity.HasOne(d => d.CeCust)
                    .WithMany(p => p.CustomerExpense)
                    .HasForeignKey(d => d.CeCustId)
                    .HasConstraintName("FK_CUSTOMER");

                entity.HasOne(d => d.CeEc)
                    .WithMany(p => p.CustomerExpense)
                    .HasForeignKey(d => d.CeEcId)
                    .HasConstraintName("FK_EXPENSE_CATEGORY");
            });

            modelBuilder.Entity<ExpenseCategory>(entity =>
            {
                entity.HasKey(e => e.EcId);

                entity.ToTable("EXPENSE_CATEGORY");

                entity.Property(e => e.EcId).HasColumnName("EC_ID");

                entity.Property(e => e.EcExpenseName)
                    .HasColumnName("EC_EXPENSE_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
