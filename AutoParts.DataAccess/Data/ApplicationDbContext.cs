using AutoParts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoParts.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<PartCategory> PartCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                new Vehicle { VehicleId = 1, BuildYear = "2001", ImageUrl = "", Manufacturer = "Toyota", Model = "Corolla", VIN = "1234"},
                new Vehicle { VehicleId = 2, BuildYear = "2020", ImageUrl = "", Manufacturer = "BMW", Model = "Series 3", VIN = "1235"},
                new Vehicle { VehicleId = 3, BuildYear = "2010", ImageUrl = "", Manufacturer = "Kia", Model = "Rio", VIN = "1236"}
                );
            modelBuilder.Entity<PartCategory>().HasData(
                new PartCategory { CategoryId = 1, CategoryName = "Front End Parts", VehicleId = 1 },
                new PartCategory { CategoryId = 2, CategoryName = "Rear End Parts", VehicleId = 2 },
                new PartCategory { CategoryId = 3, CategoryName = "Mechanical Parts", VehicleId = 3 }
                );
        }
    }
}
