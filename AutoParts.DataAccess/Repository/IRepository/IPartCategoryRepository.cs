using AutoParts.Models;


namespace AutoParts.DataAccess.Repository.IRepository
{
    public interface IPartCategoryRepository : IRepository<PartCategory>
    {
        void Update(PartCategory obj);
    }
}
