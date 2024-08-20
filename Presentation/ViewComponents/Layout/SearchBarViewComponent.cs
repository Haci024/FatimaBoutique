using Bussiness.Services;
using DTO.ProductsDTO;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Presentation.ViewComponents.Layout
{
    public class SearchBarViewComponent:ViewComponent
    {
        private readonly IProductService _productService;
        public SearchBarViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public  async Task<IViewComponentResult> InvokeAsync(string query)
        {
            IEnumerable<SearchProductDTO> products =await  _productService.SearchProduct(query);

            
           

        

            return  View("~/Views/Shared/Components/SearchBar/_SearchPartialView.cshtml", products);
            

        }
    }
}
