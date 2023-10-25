using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;

namespace AutoParts.DataAccess.Repository
{
    internal class PartCategoryRepository : Repository<PartCategory>, IPartCategoryRepository
    {
        private ApplicationDbContext _db;

        public PartCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PartCategory obj)
        {
            _db.PartCategories.Update(obj);
        }
    }
}
