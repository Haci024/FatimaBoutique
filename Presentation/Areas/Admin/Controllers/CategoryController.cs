using Bussiness.Services;
using DAL.DbConnection;
using DTO.CategoryDTO;
using Entity.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CategoryController : Controller
    {
        private readonly Context _db;
        private readonly ICategoryService _category;
        private readonly IBlogService _blogService;
        private readonly ICategoryLanguageService _categoryLanguageService;
        private readonly IBlogImagesService _blogImagesService;

        public CategoryController(Context db, ICategoryService category, IBlogService blogService, ICategoryLanguageService categoryLanguageService, IBlogImagesService blogImagesService)
        {
            _db = db;
            _category = category;
            _blogService = blogService;
            _categoryLanguageService = categoryLanguageService;
            _blogImagesService = blogImagesService;
        }

        [HttpGet]
        public IActionResult MainCategoryList()
        {
            CategoryListDTO dto= new CategoryListDTO();
            dto.ActiveMainCategoryList = _categoryLanguageService.ActiveMainCategoryList();
            return View(dto);
        }
        [HttpGet]
        public IActionResult ChildCategoryList()
        {
            CategoryListDTO dto = new CategoryListDTO();
            dto.ActiveChildCategoryList = _categoryLanguageService.ActiveChildCategoryList();
            return View(dto);
        }
        [HttpGet]
        public IActionResult AddMainCategory()
        {
            AddMainCategoryDTO dto=new AddMainCategoryDTO();

            return View(dto);
        }
        [HttpGet]
        public IActionResult ChildCategoryListByMain(int MainCategoryId,string MainCategoryName)
        {
               CategoryListDTO dto=new CategoryListDTO();
            dto.ChildCategoryListByMain = _categoryLanguageService.ChildCategoryListByMain(MainCategoryId);
            dto.MainCategoryName= MainCategoryName;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMainCategory(AddMainCategoryDTO dto)
        {
         
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Məlumatları tam doldurun!");
              
                return View(dto);
            }
            Categories categories = new Categories();

            categories.MainCategoryId = null;
            categories.Status = false;
            _category.Create(categories);
            CategoryLanguage azFormat = new CategoryLanguage();
            CategoryLanguage trFormat = new CategoryLanguage();
            CategoryLanguage enFormat = new CategoryLanguage();
            CategoryLanguage ruFormat = new CategoryLanguage();
            azFormat.CategoriesId = categories.Id;
            azFormat.LanguageId = 1;
            azFormat.CategoryName = dto.CategoryName_az;
            trFormat.CategoriesId = categories.Id;
            trFormat.LanguageId = 2;
            trFormat.CategoryName = dto.CategoryName_tr;
            enFormat.CategoriesId = categories.Id;
            enFormat.LanguageId = 3;
            enFormat.CategoryName = dto.CategoryName_en;
            ruFormat.CategoriesId = categories.Id;
            ruFormat.LanguageId = 4;
            ruFormat.CategoryName = dto.CategoryName_ru;
            _categoryLanguageService.Create(azFormat);
            _categoryLanguageService.Create(trFormat);
            _categoryLanguageService.Create(enFormat);
            _categoryLanguageService.Create(ruFormat);
            return RedirectToAction("MainCategoryList");
        }
        [HttpGet]
        public IActionResult AddChildCategory()
        {
            AddChildCategoryDTO dto = new AddChildCategoryDTO();

            dto.MainCategoryList = _categoryLanguageService.ActiveMainCategoryList();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddChildCategory(AddChildCategoryDTO dto)
        {

            dto.MainCategoryList = _categoryLanguageService.ActiveMainCategoryList();
          
       
            Categories categories = new Categories();
            categories.MainCategoryId = dto.MainCategoryId;
            categories.Status = false;
            _category.Create(categories);
            CategoryLanguage azFormat= new CategoryLanguage();
            CategoryLanguage trFormat= new CategoryLanguage();
            CategoryLanguage enFormat = new CategoryLanguage();
            CategoryLanguage ruFormat = new CategoryLanguage();
            azFormat.CategoriesId = categories.Id;
            azFormat.LanguageId = 1;
            azFormat.CategoryName = dto.CategoryName_az;
            trFormat.CategoriesId = categories.Id;
            trFormat.LanguageId = 2;
            trFormat.CategoryName = dto.CategoryName_tr;
            enFormat.CategoriesId = categories.Id;
            enFormat.LanguageId = 3;
            enFormat.CategoryName = dto.CategoryName_en;
            ruFormat.CategoriesId = categories.Id;
            ruFormat.LanguageId = 4;
            ruFormat.CategoryName = dto.CategoryName_ru;
            _categoryLanguageService.Create(azFormat);
            _categoryLanguageService.Create(trFormat);
            _categoryLanguageService.Create(enFormat);
            _categoryLanguageService.Create(ruFormat);


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
            DTO.MainCategoryList = _categoryLanguageService.ActiveMainCategoryList();
            DTO.MainCategoryId =(int)categories.MainCategoryId;
            

            return View(DTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateChildCategory(UpdateChildCategoryDTO updateDTO,int categoryId)
        {
            updateDTO.MainCategoryList = _categoryLanguageService.ActiveMainCategoryList();
            
            Categories categories = _category.GetById(categoryId);
            categories.MainCategoryId= updateDTO.MainCategoryId;
            
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

            UpdateMainCategoryDTO dto = new UpdateMainCategoryDTO();
            
            CategoryLanguage azFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categoryId && x.LanguageId == 1);
            CategoryLanguage trFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categoryId && x.LanguageId == 2);
            CategoryLanguage enFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categoryId && x.LanguageId == 3);
            CategoryLanguage ruFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categoryId && x.LanguageId == 4);
            dto.CategoryName_az = azFormat.CategoryName;
            dto.CategoryName_tr = trFormat.CategoryName;
            dto.CategoryName_en=enFormat.CategoryName;
            dto.CategoryName_ru = ruFormat.CategoryName;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMainCategory(UpdateMainCategoryDTO dto, int categoryId)
        {
            
            

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");

                return View(dto);
            }
            Categories categories = _category.GetById(categoryId);
            CategoryLanguage azFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categories.Id && x.LanguageId == 1);
            CategoryLanguage trFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categories.Id && x.LanguageId == 2);
            CategoryLanguage enFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categories.Id && x.LanguageId == 3);
            CategoryLanguage ruFormat = _db.CategoryLanguages.FirstOrDefault(x => x.CategoriesId == categories.Id && x.LanguageId == 4);
            azFormat.CategoryName = dto.CategoryName_az;
            trFormat.CategoryName = dto.CategoryName_tr;
            enFormat.CategoryName = dto.CategoryName_en;
            ruFormat.CategoryName = dto.CategoryName_ru;
            _categoryLanguageService.Update(azFormat);
            _categoryLanguageService.Update(trFormat);
            _categoryLanguageService.Update(enFormat);
            _categoryLanguageService.Update(ruFormat);
           

            return RedirectToAction("MainCategoryList");
        }
        [HttpGet]
        public IActionResult BlockCategory(int categoryId)
        {
            Categories categories=_category.GetById(categoryId);
            if (categories.MainCategoryId != null)
            {
                if (categories.Status)
                {
                    categories.Status = false;
                    _category.Update(categories);
                    return RedirectToAction("MainCategoryList");
                }
                else
                {
                    categories.Status = true;
                    _category.Update(categories);
                    return RedirectToAction("MainCategoryList");
                }
    
            }
            else
            {
                if (categories.Status)
                {
                    categories.Status = false;
                    _category.Update(categories);
                    return RedirectToAction("ChildCategoryList");
                }
                else
                {
                    categories.Status = true;
                    _category.Update(categories);
                    return RedirectToAction("ChildCategoryList");
                }
            } 
        }




    }
}
