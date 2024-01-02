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
    public class PartCategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        [TempData]
        public string Message { get; set; }
        public PartCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<PartCategory> objPartCategory = _unitOfWork.PartCategory.GetAll(includeProperties: "Vehicle").ToList();
            
            return View(objPartCategory);
        }

        public IActionResult AddPartCategory()
        {
            PartCategoryVM partCategoryVM = new() { 
                VehicleList = _unitOfWork.Vehicle
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.VehicleId.ToString(),
                    Value = u.VehicleId.ToString(),
                }),
                PartCategory = new PartCategory()
            };
            
            return View(partCategoryVM);
        }

        [HttpPost]
        public IActionResult AddPartCategory(PartCategoryVM partCategoryVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PartCategory.Add(partCategoryVM.PartCategory);
                _unitOfWork.Save();
                Message = "Part Category Added Successfully";
                return RedirectToAction("Index", "PartCategory");
            }
            else{
                partCategoryVM.VehicleList = _unitOfWork.Vehicle
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.VehicleId.ToString(),
                    Value = u.VehicleId.ToString()
                });
                return View(partCategoryVM);
            }
            
        }

        public IActionResult EditPartCategory(PartCategoryVM? partCategoryVM, int? categoryId)
        {
            
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            else 
            {
                partCategoryVM.VehicleList = _unitOfWork.Vehicle
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.VehicleId.ToString(),
                    Value = u.VehicleId.ToString()
                });
                partCategoryVM.PartCategory = _unitOfWork.PartCategory.Get(u => u.CategoryId == categoryId);
                return View(partCategoryVM);
            }
            
        }

        [HttpPost]
        public IActionResult EditPartCategory(PartCategoryVM partCategoryVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PartCategory.Update(partCategoryVM.PartCategory);
                _unitOfWork.Save();
                Message = "Part Category Updated Successfully";
                return RedirectToAction("Index", "PartCategory");
            }
            else
            {
                
                return View(partCategoryVM);
            }
        }

        public IActionResult DeletePartCategory(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }

            PartCategory? partCategoryFromDb = _unitOfWork.PartCategory.Get(u => u.CategoryId == categoryId);
            if (partCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(partCategoryFromDb);
        }

        [HttpPost, ActionName("DeletePartCategory")]
        public IActionResult RemovePartCategory(int? categoryId)
        {
            PartCategory? partCategoryFromDb = _unitOfWork.PartCategory.Get(u => u.CategoryId == categoryId);
            if (partCategoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.PartCategory.Remove(partCategoryFromDb);
            _unitOfWork.Save();
            Message = "Part Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
