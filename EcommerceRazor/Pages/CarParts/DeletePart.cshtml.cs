using EcommerceRazor.Data;
using EcommerceRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace EcommerceRazor.Pages.CarParts
{
    public class DeletePartModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public CarPart CarPart { get; set; }

        public DeletePartModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? PartId)
        {
            if (PartId != null && PartId !=0)
            {
                CarPart = _db.CarParts.Find(PartId);
            }
        }

        public IActionResult OnPost()
        {
            CarPart? CarPartFromDb = _db.CarParts.Find(CarPart.PartId);
            if (CarPartFromDb == null)
            {
                return NotFound();
            }
            
                _db.CarParts.Remove(CarPartFromDb);
                _db.SaveChanges();
                return RedirectToPage("/CarParts/Index");
        }
    }
}
