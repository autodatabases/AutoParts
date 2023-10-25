using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddressController : Controller
    {
        private IUnitOfWork _unitOfWork;
        [TempData]
        public string Message { get; set; }
        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Address> objAddress = _unitOfWork.Address.GetAll().ToList();
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
                _unitOfWork.Address.Add(obj);
                _unitOfWork.Save();
                Message = "Address Created Successfully";
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
            Address? addressFromDb = _unitOfWork.Address.Get(u => u.AddressId == addressId);
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
                _unitOfWork.Address.Update(obj);
                _unitOfWork.Save();
                Message = "Address Updated Successfully";
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

            Address? addressFromDb = _unitOfWork.Address.Get(u => u.AddressId == addressId);
            if (addressFromDb == null)
            {
                return NotFound();
            }
            return View(addressFromDb);
        }

        [HttpPost, ActionName("DeleteAddress")]
        public IActionResult RemoveAddress(int? addressId)
        {
            Address? addressFromDb = _unitOfWork.Address.Get(u => u.AddressId == addressId);
            if (addressFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Address.Remove(addressFromDb);
            _unitOfWork.Save();
            Message = "Address Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
