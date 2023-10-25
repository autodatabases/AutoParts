using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;

namespace AutoParts.DataAccess.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private ApplicationDbContext _db;
        public AddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Address obj)
        {
            _db.Addresses.Update(obj);
        }
    }
}
