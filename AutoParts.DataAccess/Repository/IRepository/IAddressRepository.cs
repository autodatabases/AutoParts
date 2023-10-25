using AutoParts.Models;

namespace AutoParts.DataAccess.Repository.IRepository
{
    public interface IAddressRepository : IRepository<Address>
    {
        void Update(Address obj);
    }
}
