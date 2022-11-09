﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sales_management.Models;

#nullable disable

namespace sales_management.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("sales_management.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("invoiceId")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("productsId")
                        .HasColumnType("int");

                    b.Property<double>("quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("invoiceId");

                    b.HasIndex("productsId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("sales_management.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("sales_management.Models.Company_info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cloud_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("E_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Print_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tax_Number")
                        .HasColumnType("float");

                    b.Property<string>("Twitter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Whatsapp")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone_number")
                        .HasColumnType("int");

                    b.Property<int>("thermal_printing")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Company_infos");
                });

            modelBuilder.Entity("sales_management.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Agent_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Opening_balance")
                        .HasColumnType("float");

                    b.Property<int>("Phone_number")
                        .HasColumnType("int");

                    b.Property<string>("Trade_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("typeID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("sales_management.Models.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("sales_management.Models.invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<bool?>("iscofirm")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("customerId");

                    b.ToTable("invoices");
                });

            modelBuilder.Entity("sales_management.Models.products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.Property<double>("highestPrice")
                        .HasColumnType("float");

                    b.Property<double>("lowestPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UnitsId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("sales_management.Models.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("sales_management.ModelView.DisplayInvoicsModelView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("totale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DisplayInvoicsModelView");
                });

            modelBuilder.Entity("sales_management.ModelView.ProductCarRepoModelView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("prices")
                        .HasColumnType("float");

                    b.Property<double>("quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ProductCarRepoModelView");
                });

            modelBuilder.Entity("sales_management.Models.Car", b =>
                {
                    b.HasOne("sales_management.Models.invoice", "invoice")
                        .WithMany("car")
                        .HasForeignKey("invoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sales_management.Models.products", "products")
                        .WithMany("car")
                        .HasForeignKey("productsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("invoice");

                    b.Navigation("products");
                });

            modelBuilder.Entity("sales_management.Models.Customer", b =>
                {
                    b.HasOne("sales_management.Models.CustomerType", "CustomerType")
                        .WithMany("Customer")
                        .HasForeignKey("typeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("sales_management.Models.invoice", b =>
                {
                    b.HasOne("sales_management.Models.Customer", "Customer")
                        .WithMany("invoice")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("sales_management.Models.products", b =>
                {
                    b.HasOne("sales_management.Models.Category", "Category")
                        .WithMany("products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sales_management.Models.Units", "Units")
                        .WithMany("products")
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("sales_management.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("sales_management.Models.Customer", b =>
                {
                    b.Navigation("invoice");
                });

            modelBuilder.Entity("sales_management.Models.CustomerType", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("sales_management.Models.invoice", b =>
                {
                    b.Navigation("car");
                });

            modelBuilder.Entity("sales_management.Models.products", b =>
                {
                    b.Navigation("car");
                });

            modelBuilder.Entity("sales_management.Models.Units", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
