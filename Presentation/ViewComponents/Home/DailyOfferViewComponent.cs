using Bussiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Home
{
    public class DailyOfferViewComponent:ViewComponent
    {
        private readonly IProductService _productService;
        public DailyOfferViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {

            return View();
        }

    }
}
