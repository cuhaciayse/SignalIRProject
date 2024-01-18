using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
