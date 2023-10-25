using EcommerceRazor.Data;
using EcommerceRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazor.Pages.CarParts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<CarPart> CarPartList { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CarPartList = _db.CarParts.ToList();
        }
    }
}
