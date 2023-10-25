
namespace AutoParts.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPartRepository Part { get; }
        IAddressRepository Address { get; }
        IVehicleRepository Vehicle { get; }
        IPartCategoryRepository PartCategory { get; }
        IVendorRepository Vendor { get; }

        void Save();
    }
}
