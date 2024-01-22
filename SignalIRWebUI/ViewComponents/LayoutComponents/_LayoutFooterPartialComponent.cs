using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
