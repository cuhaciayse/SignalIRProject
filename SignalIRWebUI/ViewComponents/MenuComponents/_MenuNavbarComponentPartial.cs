using Microsoft.AspNetCore.Mvc;

namespace SignalIRWebUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
