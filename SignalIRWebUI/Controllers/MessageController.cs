using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
