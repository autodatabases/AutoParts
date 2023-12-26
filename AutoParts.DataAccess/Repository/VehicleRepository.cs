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
            var objFromDb = _db.Vehicles.FirstOrDefault(u => u.VehicleId == obj.VehicleId);
            if (objFromDb != null)
            {
                objFromDb.VIN = obj.VIN;
                objFromDb.Manufacturer = obj.Manufacturer;
                objFromDb.Model = obj.Model;
                objFromDb.BuildYear = obj.BuildYear;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
