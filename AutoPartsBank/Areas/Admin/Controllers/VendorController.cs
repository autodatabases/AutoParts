using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VendorController : Controller
    {
        private IUnitOfWork _unitOfWork;
        [TempData]
        public string Message { get; set; }
        public VendorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Vendor> objVendor = _unitOfWork.Vendor.GetAll().ToList();
            return View(objVendor);
        }

        public IActionResult AddVendor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVendor(Vendor obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Vendor.Add(obj);
                _unitOfWork.Save();
                Message = "Vehicle Added Successfully";
                return RedirectToAction("Index", "Vendor");
            }
            return View();
        }

        public IActionResult EditVendor(int? vendorId)
        {
            if (vendorId == null || vendorId == 0)
            {
                return NotFound();
            }

            Vendor? vendorFromDb = _unitOfWork.Vendor.Get(u => u.VendorId == vendorId);
            if (vendorFromDb == null)
            {
                return NotFound();
            }
            return View(vendorFromDb);
        }
        [HttpPost]
        public IActionResult EditVendor(Vendor obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Vendor.Update(obj);
                _unitOfWork.Save();
                Message = "Vendor Updated Successfully";
                return RedirectToAction("Index", "Vendor");
            }
            return View();
        }
        public IActionResult DeleteVendor(int? vendorId)
        {
            if (vendorId == null || vendorId == 0)
            {
                return NotFound();
            }

            Vendor? vendorFromDb = _unitOfWork.Vendor.Get(u => u.VendorId == vendorId);
            if (vendorFromDb == null)
            {
                return NotFound();
            }
            return View(vendorFromDb);
        }

        [HttpPost, ActionName("DeleteVendor")]
        public IActionResult RemoveVendor(int? vendorId)
        {
            Vendor? vendorFromDb = _unitOfWork.Vendor.Get(u => u.VendorId == vendorId);
            if (vendorFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Vendor.Remove(vendorFromDb);
            _unitOfWork.Save();
            Message = "Vendor Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
