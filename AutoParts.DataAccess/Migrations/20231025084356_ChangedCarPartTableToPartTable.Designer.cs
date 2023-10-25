﻿// <auto-generated />
using AutoParts.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoParts.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231025084356_ChangedCarPartTableToPartTable")]
    partial class ChangedCarPartTableToPartTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.1.23419.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoParts.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            Postcode = "2144",
                            State = "NSW",
                            Street = "10 Park Road",
                            Suburb = "Auburn"
                        },
                        new
                        {
                            AddressId = 2,
                            Postcode = "2135",
                            State = "NSW",
                            Street = "42 Swan Avenue",
                            Suburb = "Strathfield"
                        });
                });

            modelBuilder.Entity("AutoParts.Models.Part", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PartId");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            PartId = 1,
                            Description = "Engine Cover",
                            PartName = "Bonnet"
                        },
                        new
                        {
                            PartId = 2,
                            Description = "Above Right Wheel",
                            PartName = "Right Guard"
                        },
                        new
                        {
                            PartId = 3,
                            Description = "Cover Driver",
                            PartName = "Right Door"
                        });
                });

            modelBuilder.Entity("AutoParts.Models.PartCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("PartCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Front End Parts"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Rear End Parts"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Mechanical Parts"
                        });
                });

            modelBuilder.Entity("AutoParts.Models.Vehicle", b =>
                {
                    b.Property<string>("VIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("buildYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("VIN");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VIN = "1234ASDF",
                            buildYear = "2001"
                        },
                        new
                        {
                            VIN = "1235",
                            buildYear = "2020"
                        },
                        new
                        {
                            VIN = "1236",
                            buildYear = "2010"
                        });
                });

            modelBuilder.Entity("AutoParts.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorId"));

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorId");

                    b.ToTable("Vendors");

                    b.HasData(
                        new
                        {
                            VendorId = 1,
                            Manufacturer = "Toyota",
                            Model = "Corolla"
                        },
                        new
                        {
                            VendorId = 2,
                            Manufacturer = "BMW",
                            Model = "4 Series"
                        },
                        new
                        {
                            VendorId = 3,
                            Manufacturer = "VW",
                            Model = "Golf"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
