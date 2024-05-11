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
            
            return View();
        }
        [HttpGet]
        public IActionResult ChildCategoryList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMainCategory()
        {
            MainCategoryDTO dto=new MainCategoryDTO();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMainCategory(MainCategoryDTO dto)
        {
            Categories categories = new Categories();
           
            categories.MainCategoryId = null;
            categories.Status = false;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Məlumatları tam doldurun!");
              
                return View(dto);
            }
            _category.Create(categories);
            CategoryLanguage azFormat = new CategoryLanguage();
            CategoryLanguage trFormat = new CategoryLanguage();
            CategoryLanguage enFormat = new CategoryLanguage();
            CategoryLanguage ruFormat = new CategoryLanguage();
            azFormat.CategoryId = categories.Id;
            azFormat.LanguageId = 1;
            azFormat.CategoryName = dto.CategoryName_az;
            trFormat.CategoryId = categories.Id;
            trFormat.LanguageId = 2;
            trFormat.CategoryName = dto.CategoryName_tr;
            enFormat.CategoryId = categories.Id;
            enFormat.LanguageId = 3;
            enFormat.CategoryName = dto.CategoryName_en;
            ruFormat.CategoryId = categories.Id;
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
            dto.MainCategoryList = _db.Categories.Include(x => x.MainCategory).ToList();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddChildCategory(AddChildCategoryDTO dto)
        {

            dto.MainCategoryList = _db.Categories.Include(x => x.MainCategory).ToList();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");

                return View(dto);
            }
       
            Categories categories = new Categories();
            
            categories.MainCategoryId = dto.MainCategoryId;
            categories.Status = false;
            _category.Create(categories);
            CategoryLanguage azFormat= new CategoryLanguage();
            CategoryLanguage trFormat= new CategoryLanguage();
            CategoryLanguage enFormat = new CategoryLanguage();
            CategoryLanguage ruFormat = new CategoryLanguage();
            azFormat.CategoryId = categories.Id;
            azFormat.LanguageId = 1;
            azFormat.CategoryName = dto.CategoryName_az;
            trFormat.CategoryId = categories.Id;
            trFormat.LanguageId = 2;
            trFormat.CategoryName = dto.CategoryName_tr;
            enFormat.CategoryId = categories.Id;
            enFormat.LanguageId = 3;
            enFormat.CategoryName = dto.CategoryName_en;
            ruFormat.CategoryId = categories.Id;
            ruFormat.LanguageId = 4;
            ruFormat.CategoryName = dto.CategoryName_ru;
            _db.Add(azFormat);
            _db.Add(trFormat);
            _db.Add(enFormat);
            _db.Add(ruFormat);
            _db.SaveChanges();


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
            DTO.MainCategoryList = _db.Categories.Include(x => x.MainCategory).Where(x => x.MainCategoryId == null && x.Status==false).ToList();
            DTO.MainCategoryId =(int)categories.MainCategoryId;
            

            return View(DTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateChildCategory(UpdateChildCategoryDTO updateDTO,int categoryId)
        {
            updateDTO.MainCategoryList = _db.Categories.Include(x => x.MainCategory).Where(x=>x.MainCategoryId==null && x.Status==false).ToList();
            
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

            UpdateMainCategoryDTO DTO = new UpdateMainCategoryDTO();
            Categories categories = _category.GetById(categoryId);
           
            

            return View(DTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMainCategory(UpdateMainCategoryDTO DTO, int categoryId)
        {
            Categories categories = _category.GetById(categoryId);
            

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
