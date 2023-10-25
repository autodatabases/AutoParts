using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;

namespace AutoParts.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IPartRepository Part { get; private set; }
        public IAddressRepository Address { get; private set; }
        public IVehicleRepository Vehicle { get; private set; }
        public IPartCategoryRepository PartCategory { get; private set; }
        public IVendorRepository Vendor { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Part = new PartRepository(_db);
            Address = new AddressRepository(_db);
            Vehicle = new VehicleRepository(_db);
            PartCategory = new PartCategoryRepository(_db);
            Vendor = new VendorRepository(_db);

        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
