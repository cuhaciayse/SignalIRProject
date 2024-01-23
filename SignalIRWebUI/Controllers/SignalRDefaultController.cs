using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
