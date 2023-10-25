using EcommerceRazor.Data;
using EcommerceRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazor.Pages.CarParts
{
    public class EditPartModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public CarPart CarPart { get; set; }

        public EditPartModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? partId)
        {
            if (partId != null || partId != 0)
            {
                CarPart = _db.CarParts.Find(partId);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.CarParts.Update(CarPart);
                _db.SaveChanges();
                return RedirectToPage("/CarParts/Index");
            }
            return Page();
        }
    }
}
