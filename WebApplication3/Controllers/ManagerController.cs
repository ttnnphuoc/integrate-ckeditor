using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;

namespace WebApplication3.Controllers
{
    public class ManagerController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: ManagerController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            var list = unitOfWork.MenuRepository.Get();
            return View(list);
        }
        public ActionResult File()
        {
            var list = unitOfWork.FileRepository.Get();
            return View(list);
        }
    }
}
