using AutoParts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoParts.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<PartCategory> PartCategories { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>().HasData(
                new Part { PartId = 1, PartName = "Bonnet", Description="Engine Cover", CategoryId = 1, ImageUrl=""},
                new Part { PartId = 2, PartName = "Right Guard", Description = "Above Right Wheel", CategoryId = 2, ImageUrl= "" },
                new Part { PartId = 3, PartName = "Right Door", Description = "Cover Driver", CategoryId = 3, ImageUrl = "" }
                );
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId= 1, Street="10 Park Road", State= "NSW", Suburb= "Auburn", Postcode= "2144"},
                new Address { AddressId = 2, Street = "42 Swan Avenue", State = "NSW", Suburb = "Strathfield", Postcode = "2135" }
                );
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VIN = "1234ASDF", buildYear = "2001", VendorId = 2},
                new Vehicle { VIN = "1235", buildYear = "2020", VendorId = 3 },
                new Vehicle { VIN = "1236", buildYear = "2010", VendorId = 2 }
                );
            modelBuilder.Entity<PartCategory>().HasData(
                new PartCategory { CategoryId = 1, CategoryName = "Front End Parts", VIN = "1234ASDF" },
                new PartCategory { CategoryId = 2, CategoryName = "Rear End Parts", VIN = "1235" },
                new PartCategory { CategoryId = 3, CategoryName = "Mechanical Parts", VIN = "1236" }
                );
            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { VendorId = 2, Manufacturer = "BMW", Model = "4 Series" },
                new Vendor { VendorId = 3, Manufacturer = "VW", Model = "Golf" }
                );
        }
    }
}
