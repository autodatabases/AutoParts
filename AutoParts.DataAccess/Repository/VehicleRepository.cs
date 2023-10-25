using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;

namespace AutoParts.DataAccess.Repository
{
    internal class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private ApplicationDbContext _db;

        public VehicleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Vehicle obj)
        {
            _db.Vehicles.Update(obj);
        }
    }
}
