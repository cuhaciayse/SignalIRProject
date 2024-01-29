using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
