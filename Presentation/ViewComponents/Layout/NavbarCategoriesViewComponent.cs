using Bussiness.Services;
using DTO.CategoryDTO.Child;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents.Layout
{
    public class NavbarCategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public NavbarCategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            IEnumerable<NavbarCategoryListDTO> navbarCategories=_categoryService.NavbarCategoryList();
            return View(navbarCategories);
        }

    }
}
