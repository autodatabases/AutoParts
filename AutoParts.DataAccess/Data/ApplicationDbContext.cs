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
                new Part { PartId = 1, PartName = "Bonnet", Description="Engine Cover" },
                new Part { PartId = 2, PartName = "Right Guard", Description = "Above Right Wheel" },
                new Part { PartId = 3, PartName = "Right Door", Description = "Cover Driver" }
                );
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId= 1, Street="10 Park Road", State= "NSW", Suburb= "Auburn", Postcode= "2144"},
                new Address { AddressId = 2, Street = "42 Swan Avenue", State = "NSW", Suburb = "Strathfield", Postcode = "2135" }
                );
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VIN = "1234ASDF", buildYear = "2001"},
                new Vehicle { VIN = "1235", buildYear = "2020" },
                new Vehicle { VIN = "1236", buildYear = "2010" }
                );
            modelBuilder.Entity<PartCategory>().HasData(
                new PartCategory { CategoryId = 1, CategoryName = "Front End Parts" },
                new PartCategory { CategoryId = 2, CategoryName = "Rear End Parts" },
                new PartCategory { CategoryId = 3, CategoryName = "Mechanical Parts" }
                );
            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { VendorId = 1, Manufacturer = "Toyota", Model = "Corolla" },
                new Vendor { VendorId = 2, Manufacturer = "BMW", Model = "4 Series" },
                new Vendor { VendorId = 3, Manufacturer = "VW", Model = "Golf" }
                );
        }
    }
}
