using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
