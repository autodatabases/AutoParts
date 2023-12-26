using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;

namespace AutoParts.DataAccess.Repository
{
    public class PartRepository : Repository<Part>, IPartRepository
    {
        private ApplicationDbContext _db;

        public PartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Part obj)
        {
            var objFromDb = _db.Parts.FirstOrDefault(u => u.PartId == obj.PartId);
            if (objFromDb != null)
            {
                objFromDb.PartName = obj.PartName;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
