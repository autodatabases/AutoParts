using AutoParts.Models;

namespace AutoParts.DataAccess.Repository.IRepository
{
    public interface IVehicleRepository: IRepository<Vehicle>
    {
        void Update(Vehicle obj);
    }
}
