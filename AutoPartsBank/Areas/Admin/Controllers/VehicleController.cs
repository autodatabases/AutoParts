using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {
        private IUnitOfWork _unitOfWork;
        [TempData]
        public string Message { get; set; }
        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Vehicle> objVehicle = _unitOfWork.Vehicle.GetAll().ToList();
            IEnumerable<SelectListItem> VendorList = _unitOfWork.Vendor
                .GetAll().Select(u=> new SelectListItem{ 
                    Text = u.Manufacturer,
                    Value = u.VendorId.ToString()
                });
            return View(objVehicle);
        }

        public IActionResult AddVehicle()
        {
            IEnumerable<SelectListItem> VendorList = _unitOfWork.Vendor
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Manufacturer,
                    Value = u.VendorId.ToString()
                });
            ViewBag.VendorList = VendorList;
            return View();
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Vehicle.Add(obj);
                _unitOfWork.Save();
                Message = "Vehicle Added Successfully";
                return RedirectToAction("Index", "Vehicle");
            }
            return View();
        }

        public IActionResult EditVehicle(string? VIN)
        {
            if (VIN == null || VIN == "")
            {
                return NotFound();
            }
            Vehicle? vehicleFromDb = _unitOfWork.Vehicle.Get(u => u.VIN == VIN);
            if (vehicleFromDb == null)
            {
                return NotFound();
            }
            return View(vehicleFromDb);
        }

        [HttpPost]
        public IActionResult EditVehicle(Vehicle obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Vehicle.Update(obj);
                _unitOfWork.Save();
                Message = "Vehicle Updated Successfully";
                return RedirectToAction("Index", "Vehicle");
            }
            return View();
        }

        public IActionResult DeleteVehicle(string? VIN)
        {
            if (VIN == null || VIN == "")
            {
                return NotFound();
            }

            Vehicle? vehicleFromDb = _unitOfWork.Vehicle.Get(u => u.VIN == VIN);
            if (vehicleFromDb == null)
            {
                return NotFound();
            }
            return View(vehicleFromDb);
        }

        [HttpPost, ActionName("DeleteVehicle")]
        public IActionResult RemoveVehicle(string? VIN)
        {
            Vehicle? vehicleFromDb = _unitOfWork.Vehicle.Get(u => u.VIN == VIN);
            if (vehicleFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Vehicle.Remove(vehicleFromDb);
            _unitOfWork.Save();
            Message = "Vehicle Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
