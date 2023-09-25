using AutoPartsBank.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsBank.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<CarPart> CarParts { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarPart>().HasData(
                new CarPart { PartId = 1, Manufacturer = "Toyota", Model = "Corolla", Year = "2023", PartName = "Bonnet", DisplayOrder = 1 },
                new CarPart { PartId = 2, Manufacturer = "VW", Model = "Golf", Year = "2019", PartName = "Right Guard", DisplayOrder = 2 },
                new CarPart { PartId = 3, Manufacturer = "Audi", Model = "A8", Year = "2016", PartName = "Right Door", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId= 1, Street="10 Park Road", State= "NSW", Suburb= "Auburn", Postcode= "2144"},
                new Address { AddressId = 2, Street = "42 Swan Avenue", State = "NSW", Suburb = "Strathfield", Postcode = "2135" }
                );
        }
    }
}
