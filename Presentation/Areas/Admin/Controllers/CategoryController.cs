using Bussiness.Services;
using DAL.DbConnection;
using DTO.CategoryDTO;
using DTO.CategoryDTO.Child;
using DTO.CategoryDTO.Main;
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
        
        private readonly IProductService _products;
        private readonly ICategoryService _category;
        private readonly IProductImageService _productImages;

        public CategoryController(Context db, IProductService products, ICategoryService category, IProductImageService productImages)
        {
            _db = db;
            _products = products;
            _category = category;
            _productImages = productImages;
        }

        [HttpGet]
        public async Task<IActionResult> MainCategoryList()
        {
          IEnumerable<MainCategoryListDTO> dto=await _category.ActiveMainCategoryList();
            
           
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> ChildCategoryList()
        {
            IEnumerable<ChildCategoryListDTO> dto = await _category.ActiveChildCategoryList();
            return View(dto);
        }
        [HttpGet]
        public IActionResult AddMainCategory()
        {
            NewMainCategoryDTO dto = new NewMainCategoryDTO();
         
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> ChildCategoryListByMain(int MainCategoryId)
        {
            IEnumerable<ChildCategoryListDTO> dto =await _category.ChildCategoryListByMain(MainCategoryId);
          
            
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMainCategory(NewMainCategoryDTO dto)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");

                return View(dto);
            }
            Categories categories = new Categories();

            categories.MainCategoryId = null;
            categories.Status = true;
            categories.Name = dto.Name;
            _category.Create(categories);
          
           
            return RedirectToAction("MainCategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> AddChildCategory()
        {
            AddChildCategoryDTO dto = new AddChildCategoryDTO();

            dto.MainCategories =await  _category.ActiveMainCategoryList();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddChildCategory(AddChildCategoryDTO dto)
        {
            dto.MainCategories = await _category.ActiveMainCategoryList();
            if (dto.MainCategoryId == null && dto.Name == null)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");
                return View(dto);
            }

            Categories categories = new Categories();
            categories.MainCategoryId = dto.MainCategoryId;
            categories.Name=dto.Name;
            categories.Status = true;
            _category.Create(categories);
            return RedirectToAction("ChildCategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateChildCategory(int categoryId)
        {
            var entity = _category.GetById(categoryId);
            UpdateChildCategoryDTO dto = new UpdateChildCategoryDTO();
            dto.MainCategoryId =(int) entity.MainCategoryId;
            dto.MainCategories =await  _category.ActiveMainCategoryList();
            dto.Name=entity.Name;
            
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateChildCategory(UpdateChildCategoryDTO dto, int categoryId)
        {
            dto.MainCategories =await  _category.ActiveMainCategoryList();
            if (dto.MainCategoryId==null && dto.Name==null)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");
                return View(dto);
            }
           
            Categories categories = _category.GetById(categoryId);
            categories.Name =dto.Name;
            categories.MainCategoryId=dto.MainCategoryId;
            _category.Update(categories);
            return RedirectToAction("ChildCategoryList");
        }
        [HttpGet]
        public IActionResult UpdateMainCategory(int categoryId)
        {
            UpdateMainCategoryDTO dto = new UpdateMainCategoryDTO();
            Categories category=_category.GetById(categoryId);
            dto.Name=category.Name;
            
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult UpdateMainCategory(UpdateMainCategoryDTO dto, int categoryId)
        {
            if (dto.MainCategoryId == null && dto.Name == null)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");

                return View(dto);
            }
            Categories categories = _category.GetById(categoryId);
            categories.Name=dto.Name;
            _category.Update(categories);

           return RedirectToAction("MainCategoryList");
        }
        [HttpGet]
        public IActionResult BlockCategory(int categoryId)
        {
            Categories categories = _category.GetById(categoryId);
            if (categories.MainCategoryId != null)
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
            else
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
        }
    }
}
