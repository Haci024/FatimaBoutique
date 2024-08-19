using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Layout
{
    public class FooterViewComponent:ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
