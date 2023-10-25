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
    [Migration("20230915110612_SeedCarPartAndAddressTable")]
    partial class SeedCarPartAndAddressTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.1.23419.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoPartsBank.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("AutoPartsBank.Models.CarPart", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartId");

                    b.ToTable("CarParts");

                    b.HasData(
                        new
                        {
                            PartId = 1,
                            DisplayOrder = 1,
                            Manufacturer = "Toyota",
                            Model = "Corolla",
                            PartName = "Bonnet",
                            Year = "2023"
                        },
                        new
                        {
                            PartId = 2,
                            DisplayOrder = 2,
                            Manufacturer = "VW",
                            Model = "Golf",
                            PartName = "Right Guard",
                            Year = "2019"
                        },
                        new
                        {
                            PartId = 3,
                            DisplayOrder = 3,
                            Manufacturer = "Audi",
                            Model = "A8",
                            PartName = "Right Door",
                            Year = "2016"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}