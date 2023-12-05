using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsBank.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            List<PartCategory> objPartCategory = _unitOfWork.PartCategory.GetAll().ToList();
            
            return View(objPartCategory);
        }

        public IActionResult AddPartCategory()
        {
            IEnumerable<SelectListItem> VehicleList = _unitOfWork.Vehicle
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.buildYear,
                    Value = u.VIN
                });
            ViewBag.VehicleList = VehicleList;
            return View();
        }

        [HttpPost]
        public IActionResult AddPartCategory(PartCategory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PartCategory.Add(obj);
                _unitOfWork.Save();
                Message = "Part Category Added Successfully";
                return RedirectToAction("Index", "PartCategory");
            }
            return View();
        }

        public IActionResult EditPartCategory(int? categoryId)
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

        [HttpPost]
        public IActionResult EditPartCategory(PartCategory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PartCategory.Update(obj);
                _unitOfWork.Save();
                Message = "Part Category Updated Successfully";
                return RedirectToAction("Index", "PartCategory");
            }
            return View();
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
