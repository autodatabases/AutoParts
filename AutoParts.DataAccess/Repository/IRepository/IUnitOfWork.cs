
namespace AutoParts.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPartRepository Part { get; }
        IAddressRepository Address { get; }
        IVehicleRepository Vehicle { get; }
        IPartCategoryRepository PartCategory { get; }

        void Save();
    }
}
