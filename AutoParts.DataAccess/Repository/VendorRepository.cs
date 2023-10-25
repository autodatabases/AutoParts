using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;

namespace AutoParts.DataAccess.Repository
{
    internal class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        private ApplicationDbContext _db;

        public VendorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Vendor obj)
        {
            _db.Vendors.Update(obj);
        }
    }
}
