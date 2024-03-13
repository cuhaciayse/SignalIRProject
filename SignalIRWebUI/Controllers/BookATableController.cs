using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
