using AutoParts.DataAccess.Repository.IRepository;
using AutoParts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoPartsBank.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Part> partList = _unitOfWork.Part.GetAll(includeProperties:"Category");
            return View(partList);
        }

        public IActionResult PartDetails(int partId)
        {
            Part part = _unitOfWork.Part.Get( u=>u.PartId==partId,includeProperties: "Category");
            return View(part);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
