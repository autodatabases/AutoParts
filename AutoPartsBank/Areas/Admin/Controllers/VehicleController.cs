using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using AutoParts.Models.ViewModels;
using AutoParts.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetail.Role_Admin)]
    public class VehicleController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        
        public VehicleController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Vehicle> objVehicle = _unitOfWork.Vehicle.GetAll(includeProperties: null).ToList();
            return View(objVehicle);
        }

        public IActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle, IFormFile? file )
        {
            if (ModelState.IsValid)
            {
                //access to wwwroot folder
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string vehiclePath = Path.Combine(wwwRootPath, @"images\vehicles");
                //upload new image file
                using (var fileStream = new FileStream(Path.Combine(vehiclePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                vehicle.ImageUrl = @"\images\vehicles\" + fileName;
               
                _unitOfWork.Vehicle.Add(vehicle);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Vehicle");
            }
            return View();
        }

        public IActionResult EditVehicle(int? vehicleId)
        {
                if (vehicleId == null || vehicleId == 0)
                {
                    return NotFound();
                }
                Vehicle vehicleFromDb = _unitOfWork.Vehicle.Get(u=>u.VehicleId == vehicleId);
                if (vehicleFromDb == null)
                {
                    return NotFound();
                }
                return View(vehicleFromDb);
        }

        [HttpPost]
        public IActionResult EditVehicle(Vehicle vehicle, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //access to wwwroot folder
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string vehiclePath = Path.Combine(wwwRootPath, @"images\vehicles");

                    //delete if not empty
                    if (!string.IsNullOrEmpty(vehicle.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, vehicle.ImageUrl.Trim('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    //upload new image file
                    using (var fileStream = new FileStream(Path.Combine(vehiclePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    vehicle.ImageUrl = @"\images\vehicles\" + fileName;
                }
                _unitOfWork.Vehicle.Update(vehicle);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Vehicle");
            }
            return View();
        }
        public IActionResult DeleteVehicle(int? vehicleId)
        {
            if (vehicleId == null || vehicleId == 0)
            {
                return NotFound();
            }

            Vehicle? vehicleFromDb = _unitOfWork.Vehicle.Get(u => u.VehicleId == vehicleId);
            if (vehicleFromDb == null)
            {
                return NotFound();
            }
            return View(vehicleFromDb);
        }

        [HttpPost, ActionName("DeleteVehicle")]
        public IActionResult RemoveVehicle(int? vehicleId)
        {
            Vehicle? vehicleFromDb = _unitOfWork.Vehicle.Get(u => u.VehicleId == vehicleId);
            if (vehicleFromDb == null)
            {
                return NotFound();
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, vehicleFromDb.ImageUrl.Trim('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Vehicle.Remove(vehicleFromDb);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
