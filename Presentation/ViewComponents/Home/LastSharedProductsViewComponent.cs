using Bussiness.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Home
{
   
   
    public class LastSharedProductsViewComponent:ViewComponent
    {
        private readonly IProductService _productService;
        public LastSharedProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
