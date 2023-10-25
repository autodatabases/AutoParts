using AutoParts.Models;


namespace AutoParts.DataAccess.Repository.IRepository
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        void Update(Vendor obj);
    }
}

