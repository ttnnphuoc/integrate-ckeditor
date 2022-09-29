using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.DAL;
using WebApplication3.Models.Entites;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UnitOfWork unitOfWork = new UnitOfWork();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = unitOfWork.MenuRepository.Get();
            return View(list);
        }

        public IActionResult AddMenu()
        {
            return View();
        }
        public IActionResult EditMenu(int Id)
        {
            var menu = unitOfWork.MenuRepository.GetById(Id);
            return View(menu);
        }

        public JsonResult DetailMenu(int Id)
        {
            var menu = unitOfWork.MenuRepository.GetById(Id);
            return new JsonResult(menu);
        }

        public IActionResult SaveMenu(Menu menu)
        {
            unitOfWork.MenuRepository.Insert(menu);
            unitOfWork.Save();
            return RedirectToAction("Menu", "Manager");
        }
        public IActionResult UpdateMenu(Menu menu)
        {
            unitOfWork.MenuRepository.Update(menu);
            unitOfWork.Save();
            return RedirectToAction("Menu", "Manager");
        }

        public IActionResult AddFile()
        {
            return View();
        }

        public IActionResult EditFile(int Id)
        {
            var menu = unitOfWork.FileRepository.GetById(Id);
            return View(menu);
        }

        public IActionResult DetailFile(int Id)
        {
            var menu = unitOfWork.FileRepository.GetById(Id);
            return View(menu);
        }

        public IActionResult SaveFile(FileContent fileContent)
        {
            unitOfWork.FileRepository.Insert(fileContent);
            unitOfWork.Save();
            return RedirectToAction("File", "Manager");
        }

        public IActionResult UpdateFile(FileContent fileContent)
        {
            unitOfWork.FileRepository.Update(fileContent);
            unitOfWork.Save();
            return RedirectToAction("File", "Manager");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}