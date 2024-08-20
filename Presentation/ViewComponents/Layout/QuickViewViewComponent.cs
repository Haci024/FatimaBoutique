using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Layout
{
    public class QuickViewViewComponent:ViewComponent
    {
      
        public QuickViewViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
