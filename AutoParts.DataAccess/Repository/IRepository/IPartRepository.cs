using AutoParts.Models;

namespace AutoParts.DataAccess.Repository.IRepository
{
    public interface IPartRepository : IRepository<Part>
    {
        void Update(Part obj);
    }
}
