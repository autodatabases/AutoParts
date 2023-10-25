using EcommerceRazor.Data;
using EcommerceRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazor.Pages.CarParts
{
    public class AddPartModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public CarPart CarPart { get; set; }
        public AddPartModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            _db.CarParts.Add(CarPart);
            _db.SaveChanges();
            return RedirectToPage("/CarParts/Index");
        }
    }
}
