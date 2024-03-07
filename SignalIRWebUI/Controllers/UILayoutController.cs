using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
