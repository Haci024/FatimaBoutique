using Bussiness.Services;
using DAL.DbConnection;
using DTO.CategoryDTO;
using DTO.MainCategoryDTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class CategoryController : Controller
    {
        private readonly Context _db;
        private readonly ICategoryService _category;
        private readonly IBlogService _blogService;
        private readonly IBlogImagesService _blogImagesService;

        public CategoryController(Context context,IBlogService blogs, IBlogImagesService blogImagesService,ICategoryService category)
        {
            _blogImagesService = blogImagesService;
            _blogService = blogs;
            _category = category;
            _db = context;


        }

        [HttpGet]
        public IActionResult MainCategoryList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMainCategory()
        {
            MainCategoryDTO newCategory=new MainCategoryDTO();

            return View(newCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMainCategory(MainCategoryDTO mainCategory)
        {
            Categories categories = new Categories();
            //categories.CategoryName = mainCategory.CategoryName;
            categories.MainCategoryId = null;
            categories.Status = false;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Məlumatları tam doldurun!");
              
                return View(mainCategory);
            }
            _category.Create(categories);
            return RedirectToAction("MainCategoryList");
        }
        [HttpGet]
        public IActionResult AddChildCategory()
        {
            AddChildCategoryDTO newCategory = new AddChildCategoryDTO();
            newCategory.Categories = _db.Categories.Include(x => x.MainCategory).ToList();

            return View(newCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddChildCategory(AddChildCategoryDTO mainCategory)
        {

            mainCategory.Categories = _db.Categories.Include(x => x.MainCategory).ToList();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");

                return View(mainCategory);
            }
            Categories categories = new Categories();
            //categories.CategoryName = mainCategory.CatgegoryName;
            categories.MainCategoryId = mainCategory.MainCategoryId;
            categories.Status = false;
           
            _category.Create(categories);

            return RedirectToAction("MainCategoryList");
        }
        [HttpGet]
        public IActionResult BlogListByCategory(int categoryId)
        {
          

            List<Blogs> blogs=_db.Blogs.Include(x=>x.Categories).ThenInclude(x=>x.MainCategory).Where(x=>x.CategoryId==categoryId).ToList();
          
            return View(blogs);
        }
        [HttpGet]
        public IActionResult UpdateChildCategory(int categoryId)
        {

            UpdateChildCategoryDTO DTO = new UpdateChildCategoryDTO();
            Categories categories=_category.GetById(categoryId);
            DTO.Categories = _db.Categories.Include(x => x.MainCategory).Where(x => x.MainCategoryId == null && x.Status==false).ToList();
            DTO.MainCategoryId =(int)categories.MainCategoryId;
            //DTO.CategoriesName = categories.CategoryName;

            return View(DTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateChildCategory(UpdateChildCategoryDTO updateDTO,int categoryId)
        {
            updateDTO.Categories = _db.Categories.Include(x => x.MainCategory).Where(x=>x.MainCategoryId==null && x.Status==false).ToList();
            
            Categories categories = _category.GetById(categoryId);
            categories.MainCategoryId= updateDTO.MainCategoryId;
            //categories.CategoryName= updateDTO.CategoriesName;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");
              
                return View(updateDTO);
            }
            _category.Update(categories);
            return RedirectToAction("ChildCategoryList");
        }
        [HttpGet]
        public IActionResult UpdateMainCategory(int categoryId)
        {

            UpdateMainCategoryDTO DTO = new UpdateMainCategoryDTO();
            Categories categories = _category.GetById(categoryId);
           
            //DTO.CategoriesName = categories.CategoryName;

            return View(DTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMainCategory(UpdateMainCategoryDTO DTO, int categoryId)
        {
            Categories categories = _category.GetById(categoryId);
            //categories.CategoryName = DTO.CategoriesName;

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");

                return View(DTO);
            }
            _category.Update(categories);
            return RedirectToAction("ChildCategoryList");
        }
        [HttpGet]
        public IActionResult BlockCategory(int categoryId)
        {
            Categories categories=_category.GetById(categoryId);
            if(categories.Status)
            {
                if (categories.MainCategoryId==null)
                {
                    categories.Status = true;
                    _category.Update(categories);
                    return RedirectToAction("MainCategoryList");
                }
                else
                {
                    categories.Status = true;
                    _category.Update(categories);
                    return RedirectToAction("ChildCategoryList");
                }
              
                
            }
            else
            {
                if (categories.MainCategoryId == null)
                {
                    categories.Status = false;
                    _category.Update(categories);
                    return RedirectToAction("MainCategoryList");
                }
                else
                {
                    categories.Status = false;
                    _category.Update(categories);
                    return RedirectToAction("ChildCategoryList");
                }
            }

            
        }




    }
}
