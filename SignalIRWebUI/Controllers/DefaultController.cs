using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
