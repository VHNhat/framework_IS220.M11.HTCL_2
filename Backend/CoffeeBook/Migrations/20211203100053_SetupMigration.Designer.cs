﻿// <auto-generated />
using System;
using CoffeeBook.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeBook.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211203100053_SetupMigration")]
    partial class SetupMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("CoffeeBook.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("CoffeeBook.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 12, 3, 17, 0, 52, 782, DateTimeKind.Local).AddTicks(2195));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("PayBy")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasDefaultValue("Đang chờ thanh toán");

                    b.Property<string>("Time")
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasDefaultValue("15-20 phút");

                    b.Property<long>("TotalPrice")
                        .HasColumnType("bigint");

                    b.Property<int>("Validated")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("CoffeeBook.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("Avata")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("Username", "Email", "Phone")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CoffeeBook.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Photo")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Value")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("CoffeeBook.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<long>("Salary")
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasDefaultValue("Hoạt động");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("StoreId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CoffeeBook.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Bonus")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<long>("Salary")
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)")
                        .HasDefaultValue("Hoạt động");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("CoffeeBook.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("News");
                });

            modelBuilder.Entity("CoffeeBook.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CoffeeBook.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("CoffeeBook.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CoffeeBook.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 12, 3, 17, 0, 52, 798, DateTimeKind.Local).AddTicks(7662));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("CoffeeBook.Models.ShoppingCart_Product", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2021, 12, 3, 17, 0, 52, 805, DateTimeKind.Local).AddTicks(4603));

                    b.Property<string>("TilteSize")
                        .HasColumnType("text")
                        .HasDefaultValue("Nhỏ");

                    b.HasKey("ShoppingCartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCart_Product");
                });

            modelBuilder.Entity("CoffeeBook.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Store");
                });

            modelBuilder.Entity("CoffeeBook.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("CoffeeBook.Models.Account", b =>
                {
                    b.HasOne("CoffeeBook.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CoffeeBook.Models.Bill", b =>
                {
                    b.HasOne("CoffeeBook.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CoffeeBook.Models.Employee", b =>
                {
                    b.HasOne("CoffeeBook.Models.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("CoffeeBook.Models.Product", b =>
                {
                    b.HasOne("CoffeeBook.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeBook.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("CoffeeBook.Models.ShoppingCart", b =>
                {
                    b.HasOne("CoffeeBook.Models.Customer", "Customer")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CoffeeBook.Models.ShoppingCart_Product", b =>
                {
                    b.HasOne("CoffeeBook.Models.Product", "Product")
                        .WithMany("ShoppingCart_Products")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeBook.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCart_Products")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("CoffeeBook.Models.Store", b =>
                {
                    b.HasOne("CoffeeBook.Models.Manager", "Manager")
                        .WithOne("Store")
                        .HasForeignKey("CoffeeBook.Models.Store", "ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("CoffeeBook.Models.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("CoffeeBook.Models.Manager", b =>
                {
                    b.Navigation("Store");
                });

            modelBuilder.Entity("CoffeeBook.Models.Product", b =>
                {
                    b.Navigation("ShoppingCart_Products");
                });

            modelBuilder.Entity("CoffeeBook.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CoffeeBook.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("CoffeeBook.Models.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCart_Products");
                });

            modelBuilder.Entity("CoffeeBook.Models.Store", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("CoffeeBook.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}