using AutoParts.DataAccess.Data;
using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Part> objPartList = _unitOfWork.Part.GetAll().ToList();
            return View(objPartList);
        }

        public IActionResult AddPart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPart(Part obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Part.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Part Added Successfully";
                return RedirectToAction("Index", "Part");
            }

            return View();
        }

        public IActionResult EditPart(int? partId)
        {
            if (partId == null || partId == 0)
            {
                return NotFound();
            }
            Part? partFromDb = _unitOfWork.Part.Get(u => u.PartId == partId);
            if (partFromDb == null)
            {
                return NotFound();
            }

            return View(partFromDb);
        }
        [HttpPost]
        public IActionResult EditPart(Part obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Part.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Part Updated Successfully";
                return RedirectToAction("Index", "Part");
            }
            return RedirectToAction("Index", "Part");
        }

        public IActionResult DeletePart(int? partId)
        {
            if (partId == null || partId == 0)
            {
                return NotFound();
            }
            Part? partFromDb = _unitOfWork.Part.Get(u => u.PartId == partId);
            if (partFromDb == null)
            {
                return NotFound();
            }
            return View(partFromDb);
        }

        [HttpPost, ActionName("DeletePart")]
        public IActionResult RemovePart(int? partId)
        {
            Part? partFromDb = _unitOfWork.Part.Get(u => u.PartId == partId);
            if (partFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Part.Remove(partFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Part Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
