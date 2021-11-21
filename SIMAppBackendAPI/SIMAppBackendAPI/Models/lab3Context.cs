using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SIMAppBackendAPI.Models
{
    public partial class lab3Context : DbContext
    {
        public lab3Context()
        {
        }

        public lab3Context(DbContextOptions<lab3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<StorageInfo> StorageInfos { get; set; } = null!;
        public virtual DbSet<UserTab> UserTabs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=database-lab3.cmil5mckzzne.ca-central-1.rds.amazonaws.com; database=lab3; User ID=admin; Password=Wahida.hossain2021; Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageInfo>(entity =>
            {
                entity.ToTable("storage_info");

                entity.Property(e => e.Id).HasColumnName("storage_info_id");

                entity.Property(e => e.CreateDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("create_date");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndMonth)
                    .HasMaxLength(255)
                    .HasColumnName("end_month");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.NumberOfStorage)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_storage");

                entity.Property(e => e.StartMonth)
                    .HasMaxLength(255)
                    .HasColumnName("start_month");

                entity.Property(e => e.TotalCost).HasColumnName("total_cost");
            });

            modelBuilder.Entity<UserTab>(entity =>
            {
                entity.ToTable("USER_TAB");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
