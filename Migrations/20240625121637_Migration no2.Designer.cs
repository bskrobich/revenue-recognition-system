﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RevenueRecognitionSystem.Contexts;

#nullable disable

namespace RevenueRecognitionSystem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240625121637_Migration no2")]
    partial class Migrationno2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<decimal>("PercentageValue")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PercentageValue");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareId");

                    b.ToTable("Discount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Happy June Discount",
                            PercentageValue = 10.5m,
                            SoftwareId = 1,
                            StartDate = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Graphic Design Week Discount",
                            PercentageValue = 5m,
                            SoftwareId = 2,
                            StartDate = new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("RevenueRecognitionSystem.Models.Clients.CompanyClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("KRS")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("KRS");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "rondo Daszyńskiego 2, 00-843 Warsaw",
                            Email = "contact@techcompany.com",
                            KRS = "000123456789",
                            Name = "Tech Company",
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            Address = "al. Jana Pawła II 19, 00-854 Warsaw",
                            Email = "contact@financecompany.com",
                            KRS = "000987654321",
                            Name = "Finance Company",
                            PhoneNumber = "987654321"
                        });
                });

            modelBuilder.Entity("RevenueRecognitionSystem.Models.Clients.PersonClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("PESEL");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Koszykowa 86, 02-008 Warsaw",
                            Email = "john.doe@gmail.com",
                            FirstName = "John",
                            IsDeleted = false,
                            LastName = "Doe",
                            PESEL = "12345678901",
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            Address = "plac Politechniki 1, 00-661 Warsaw",
                            Email = "jane.doe@gmail.com",
                            FirstName = "Jane",
                            IsDeleted = false,
                            LastName = "Doe",
                            PESEL = "01987654321",
                            PhoneNumber = "987654321"
                        });
                });

            modelBuilder.Entity("RevenueRecognitionSystem.Models.Software.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Software");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Business",
                            Description = "A collection of applications and services available from Microsoft servers.",
                            Name = "Microsoft 365"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Graphic Design",
                            Description = "A graphic program intended for creating and processing raster graphics.",
                            Name = "Adobe Photoshop"
                        });
                });

            modelBuilder.Entity("RevenueRecognitionSystem.Models.Software.SoftwareVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int")
                        .HasColumnName("SoftwareId");

                    b.Property<decimal>("Version")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareId");

                    b.ToTable("Software_Version");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SoftwareId = 1,
                            Version = 2405m
                        },
                        new
                        {
                            Id = 2,
                            SoftwareId = 1,
                            Version = 2406m
                        },
                        new
                        {
                            Id = 3,
                            SoftwareId = 2,
                            Version = 25.8m
                        },
                        new
                        {
                            Id = 4,
                            SoftwareId = 2,
                            Version = 25.9m
                        });
                });

            modelBuilder.Entity("Discount", b =>
                {
                    b.HasOne("RevenueRecognitionSystem.Models.Software.Software", "Software")
                        .WithMany("Discounts")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Software");
                });

            modelBuilder.Entity("RevenueRecognitionSystem.Models.Software.SoftwareVersion", b =>
                {
                    b.HasOne("RevenueRecognitionSystem.Models.Software.Software", "Software")
                        .WithMany("Versions")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Software");
                });

            modelBuilder.Entity("RevenueRecognitionSystem.Models.Software.Software", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
