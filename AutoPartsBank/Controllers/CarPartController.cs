using AutoPartsBank.Data;
using AutoPartsBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsBank.Controllers
{
    public class CarPartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CarPartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<CarPart> objCarPartList = _db.CarParts.ToList();
            return View(objCarPartList);
        }

        public IActionResult AddPart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPart(CarPart obj)
        {
            if (ModelState.IsValid)
            {
                _db.CarParts.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Car Part Added Successfully";
                return RedirectToAction("Index", "CarPart");
            }

            return View();
        }

        public IActionResult EditPart(int? partId)
        {
            if (partId == null || partId == 0)
            {
                return NotFound();
            }
            CarPart? carPartFromDb = _db.CarParts.Find(partId);
            if (carPartFromDb == null)
            {
                return NotFound();
            }

            return View(carPartFromDb);
        }
        [HttpPost]
        public IActionResult EditPart(CarPart obj)
        {
            if (ModelState.IsValid)
            {
                _db.CarParts.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Car Part Updated Successfully";
                return RedirectToAction("Index", "CarPart");
            }
            return RedirectToAction("Index", "CarPart");
        }

        public IActionResult DeletePart(int? partId)
        {
            if (partId == null || partId == 0)
            {
                return NotFound();
            }
            CarPart? partFromDb = _db.CarParts.Find(partId);
            if (partFromDb == null)
            {
                return NotFound();
            }
            return View(partFromDb);
        }

        [HttpPost, ActionName("DeletePart")]
        public IActionResult RemovePart(int? partId)
        {
            CarPart? partFromDb = _db.CarParts.Find(partId);
            if (partFromDb == null)
            {
                return NotFound();
            }
            _db.CarParts.Remove(partFromDb);
            _db.SaveChanges();
            TempData["success"] = "Car Part Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
