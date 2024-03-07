using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
