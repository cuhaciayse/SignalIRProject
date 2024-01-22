using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
