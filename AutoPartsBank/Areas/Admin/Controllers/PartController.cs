using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using AutoParts.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PartController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Part> objPartList = _unitOfWork.Part.GetAll(includeProperties: "Category").ToList();
            
            return View(objPartList);
        }


        public IActionResult Upsert(int? partId)
        {
            PartVM partVM = new() {
                PartCategoryList = _unitOfWork.PartCategory
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                }),
                Part = new Part()
            };
            if (partId == null || partId == 0)
            {   
                //create
                return View(partVM);
            }
            else
            {
                //update
                partVM.Part = _unitOfWork.Part.Get(u => u.PartId == partId);
                return View(partVM);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(PartVM partVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //access the wwwroot folder
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\parts");
                    //delete if not empty
                    if (!string.IsNullOrEmpty(partVM.Part.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, partVM.Part.ImageUrl.Trim('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    //upload new image file
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    partVM.Part.ImageUrl = @"\images\parts\" + fileName;
                }
                if (partVM.Part.PartId == 0)
                {
                    _unitOfWork.Part.Add(partVM.Part);
                }
                else
                {
                    _unitOfWork.Part.Update(partVM.Part);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "Part Added Successfully";
                return RedirectToAction("Index", "Part");
            }
            else {
                partVM.PartCategoryList = _unitOfWork.PartCategory
                    .GetAll().Select(u => new SelectListItem{ 
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                });
                return View(partVM);
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Part> objPartList = _unitOfWork.Part.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objPartList });
        }
        [HttpDelete]
        public IActionResult DeletePart(int? partId)
        {
            var partToBeDeleted = _unitOfWork.Part.Get(u => u.PartId == partId);
            if (partToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, partToBeDeleted.ImageUrl.Trim('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Part.Remove(partToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Part deleted successfully" });
        }
        #endregion
    }
}
