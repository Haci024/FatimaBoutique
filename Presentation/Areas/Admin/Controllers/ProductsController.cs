using Business.Services;
using Bussiness.Services;
using DAL.DbConnection;
using DTO.ProductsDTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ProductsController : Controller
    {
        public readonly IProductService _products;
        private readonly Context _db;
        private readonly ICategoryService _category;
        private readonly IGoogleCloudStorageService _googleService;
        private readonly IProductImageService _imageService;

        public ProductsController(IProductService product,IGoogleCloudStorageService googleService,Context db ,IProductImageService productImageService, ICategoryService category)
        {
            _imageService = productImageService;
            _category = category;
            _products = product;
            _db= db;
            _googleService= googleService;
        }
        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            var dto = await _products.AllProducts();

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DeactiveProductList()
        {
            ProductListDTO dto = new ProductListDTO();

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> SalesProductList()
        {
            ProductListDTO dto = new ProductListDTO();

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> BlockProduct(int BlogId)
        {
            Products data = _products.GetById(BlogId);
            if (data.Status)
            {
                data.Status = false;
                _products.Update(data);
                return View("AllProducts");
            }
            else
            {
                data.Status = true;
                _products.Update(data);
                return View("AllProducts");
            }

        }
        [HttpGet]
        public async Task<IActionResult> NewProduct()
        {

            AddProductDTO dto = new AddProductDTO();
            dto.ChildCategories = await _category.ActiveChildCategoryList();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewProduct(AddProductDTO dto)
        {
            dto.ChildCategories = await _category.ActiveChildCategoryList();
            Products entity = new();

            entity.AddingDate = DateTime.UtcNow;
            entity.Status = dto.Status;
            entity.CategoryId = dto.CategoryId;
            entity.Price = dto.Price;
            entity.Name = dto.Name;
            entity.Status = true;
            entity.Description = dto.Description;

            if (dto.SalesStatus)
            {
                entity.SalesStatus = true;
                entity.SalesPrice= dto.SalesPrice;
                entity.LastDateForIsSale = dto.LastDateForIsSale;
            }
            else
            {
                entity.SalesStatus = false;
                entity.SalesPrice = 0;
                entity.LastDateForIsSale = DateTime.Now;    
             
            }
             _products.Create(entity);

            foreach (var dtoImage in dto.Photos)
            {
                ProductsImages images = new ProductsImages
                {
                    ProductId = entity.Id,
                    Status = true,
                    SavedImageUrl = GenerateFileNameToSave(dtoImage.FileName),
                    ImageUrl = await _googleService.UploadFile(dtoImage, GenerateFileNameToSave(dtoImage.FileName)),
                };
                 _db.ProductImages.Add(images);
                 await _db.SaveChangesAsync();
            }
            return RedirectToAction("AllProducts");
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }


    }
}
