using Bussiness.Services;
using DTO.BlogsDTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Validation.BlogValidator;

namespace Presentation.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BlogsController : Controller
    {
        private readonly IBlogLanguagesService _blogLanguagesService;
        private readonly ICategoryLanguageService _category; 
        public readonly IBlogService _blog;
        private readonly IBlogImagesService _blogImagesService;

        public BlogsController(IBlogLanguagesService blogLanguagesService,IBlogService blog,ICategoryLanguageService categoryLanguageService ,IBlogImagesService blogImagesService)
        {
            _blogLanguagesService = blogLanguagesService;
            _blogImagesService = blogImagesService;
            _category = categoryLanguageService;
            _blog=blog;
        }

        public async Task<IActionResult> AllProducts()
        {
            BlogListDTO dto = new BlogListDTO();
            dto.ActiveProducts = await _blogLanguagesService.GetAllProducts();
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> DeactiveProductList()
        {
            BlogListDTO dto = new BlogListDTO();
            dto.DeactiveProducts = await _blogLanguagesService.DeactiveProducts();
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> SalesProductList()
        {
            BlogListDTO dto = new BlogListDTO();
            dto.SalesProducts = await _blogLanguagesService.DiscountProducts();
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> BlockProduct(int BlogId)
        {
            Blogs blog = _blog.GetById(BlogId);
            if (blog.Status)
            {
                blog.Status = false;
                _blog.Update(blog);
                return View("AllProducts");
            }
            else
            {
                blog.Status=true;
                _blog.Update(blog);
                return View("AllProducts");
            }

        }
        [HttpGet]
        public IActionResult NewProduct() { 
        
        AddBlogDTO dto= new AddBlogDTO();   
            dto.CategoryList=_category.ActiveChildCategoryList();
        
        return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewProduct(AddBlogDTO dto)
        {
            dto.CategoryList= _category.ActiveChildCategoryList();
            AddBlogValidator validator = new();
            var validationResult=validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError("",item.ErrorMessage);

                }
                return View(dto);
            }
            Blogs blogs = new();
            blogs.Status=true;
            blogs.SalesStatus = false;
            blogs.SalesPrice= 0;
           blogs.Price=dto.Price;
            BlogsLanguage az_Format = new();
            az_Format.LanguageId = 1;
            az_Format.BlogsId = blogs.Id;
            az_Format.Description = dto.Description_az;
            az_Format.Title= dto.Title_az;
            BlogsLanguage tr_Format = new();
            tr_Format.LanguageId = 2;
            tr_Format.Description = dto.Description_tr;
            tr_Format.Title = dto.Title_tr;
            tr_Format.BlogsId = blogs.Id;
            BlogsLanguage en_Format = new();
            en_Format.LanguageId = 3;
            en_Format.Description = dto.Description_en;
            en_Format.Title = dto.Title_en;
            en_Format.BlogsId = blogs.Id;
            BlogsLanguage ru_Format = new();
            ru_Format.LanguageId = 4;
            ru_Format.Description = dto.Description_ru;
            ru_Format.Title = dto.Title_tr;
            ru_Format.BlogsId = blogs.Id;
            
            _blogLanguagesService.Create(az_Format);
            _blogLanguagesService.Create(tr_Format);
            _blogLanguagesService.Create(en_Format);
            _blogLanguagesService.Create(ru_Format);


            return RedirectToAction("AllProducts");
        }

    }
}
