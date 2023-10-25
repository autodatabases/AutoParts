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
            _db.Parts.Update(obj);
        }
    }
}
