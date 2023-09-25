using AutoPartsBank.Data;
using AutoPartsBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsBank.Controllers
{
    public class AddressController : Controller
    {
        ApplicationDbContext _db;
        public AddressController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            List<Address> objAddress = _db.Addresses.ToList();
            return View(objAddress);
        }

        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(Address obj)
        {
            if (ModelState.IsValid)
            {
                _db.Addresses.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Address Created Successfully";
                return RedirectToAction("Index", "Address");
            }
            return View();
        }

        public IActionResult EditAddress(int? addressId)
        {
            if (addressId == null || addressId == 0)
            {
                return NotFound();
            }
            Address? addressFromDb = _db.Addresses.Find(addressId);
            if (addressFromDb == null)
            {
                return NotFound();
            }
            return View(addressFromDb);
        }

        [HttpPost]
        public IActionResult EditAddress(Address obj)
        {
            if (ModelState.IsValid)
            {
                _db.Addresses.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Address Updated Successfully";
                return RedirectToAction("Index", "Address");
            }
            return View();
        }

        public IActionResult DeleteAddress(int? addressId)
        {
            if (addressId == null || addressId == 0)
            {
                return NotFound();
            }

            Address? addressFromDb = _db.Addresses.Find(addressId);
            if (addressFromDb == null)
            {
                return NotFound();
            }
            return View(addressFromDb);
        }

        [HttpPost, ActionName("DeleteAddress")]
        public IActionResult RemoveAddress(int? addressId)
        {
            Address? addressFromDb = _db.Addresses.Find(addressId);
            if (addressFromDb == null)
            {
                return NotFound();
            }
            _db.Addresses.Remove(addressFromDb);
            _db.SaveChanges();
            TempData["success"] = "Address Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
