using EcommerceRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<CarPart> CarParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarPart>().HasData(
                    new CarPart { PartId=1, Manufacturer="Nissan", Model="Maxima", Year="2006", PartName="Compressor", DisplayOrder=1},
                    new CarPart { PartId = 2, Manufacturer = "Ford", Model = "Ecosports", Year = "2010", PartName = "Rear Prop Shaft", DisplayOrder = 3 },
                    new CarPart { PartId = 3, Manufacturer = "Hyundai", Model = "Tucson", Year = "2020", PartName = "Combination Switch", DisplayOrder = 4 }
                );
        }
    }
}
