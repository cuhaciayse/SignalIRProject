using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}	
	}
}
