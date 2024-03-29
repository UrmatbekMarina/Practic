﻿// <auto-generated />
using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(KIContext))]
    partial class KIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category_name");

                    b.Property<int?>("GoodsId")
                        .HasColumnType("int")
                        .HasColumnName("goods_id");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("DeliveryPrice")
                        .HasColumnType("int")
                        .HasColumnName("delivery_price");

                    b.Property<string>("DeliveryStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("delivery_status");

                    b.Property<int?>("GoodsId")
                        .HasColumnType("int")
                        .HasColumnName("goods_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.HasIndex("UserId");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Good", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int?>("Discount")
                        .HasColumnType("int")
                        .HasColumnName("discount");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int")
                        .HasColumnName("manufacturer_id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int?>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<int?>("Value")
                        .HasColumnType("int")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Domain.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Inn")
                        .HasColumnType("int")
                        .HasColumnName("INN");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer", (string)null);
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_address");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_name");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_password");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_role");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.HasOne("Domain.Models.Good", "Goods")
                        .WithMany("Categories")
                        .HasForeignKey("GoodsId")
                        .HasConstraintName("FK__Category__goods___300424B4");

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Domain.Models.Delivery", b =>
                {
                    b.HasOne("Domain.Models.Good", "Goods")
                        .WithMany("Deliveries")
                        .HasForeignKey("GoodsId")
                        .HasConstraintName("FK__Delivery__goods___31EC6D26");

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Deliveries")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Delivery__user_i__30F848ED");

                    b.Navigation("Goods");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Good", b =>
                {
                    b.HasOne("Domain.Models.Customer", "Customer")
                        .WithMany("Goods")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Goods__customer___2E1BDC42");

                    b.HasOne("Domain.Models.Manufacturer", "Manufacturer")
                        .WithMany("Goods")
                        .HasForeignKey("ManufacturerId")
                        .HasConstraintName("FK__Goods__manufactu__2F10007B");

                    b.Navigation("Customer");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Domain.Models.Good", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("Domain.Models.Manufacturer", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
