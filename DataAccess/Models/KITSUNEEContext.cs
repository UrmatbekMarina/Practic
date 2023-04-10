using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class KITSUNEEContext : DbContext
    {
        public KITSUNEEContext()
        {
        }

        public KITSUNEEContext(DbContextOptions<KITSUNEEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.GoodsId).HasColumnName("goods_id");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.GoodsId)
                    .HasConstraintName("FK__Category__goods___300424B4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeliveryPrice).HasColumnName("delivery_price");

                entity.Property(e => e.DeliveryStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("delivery_status");

                entity.Property(e => e.GoodsId).HasColumnName("goods_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.GoodsId)
                    .HasConstraintName("FK__Delivery__goods___31EC6D26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Delivery__user_i__30F848ED");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Goods__customer___2E1BDC42");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK__Goods__manufactu__2F10007B");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Inn).HasColumnName("INN");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_address");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
