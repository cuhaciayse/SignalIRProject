using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
