using Business.Services;
using DAL.DbConnection;
using DTO.ProductImagesDTO;
using DTO.SearchDTO;
using DTO.ShopDTO;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Presentation.Controllers
{
    public class ShopController : Controller
    {
        private readonly Context _context;
        private readonly IGoogleCloudStorageService _googleService;

        public ShopController(Context context,IGoogleCloudStorageService service)
        {
            _context = context;
            _googleService = service;
        }
        public IActionResult Index(double? minPrice = null, double? maxPrice = null, string sort = "AtoZ")
        {
            ShopListDTO shopListDTO = new ShopListDTO
            {
                
            };

            var query = _context.Products.Include(x => x.ProductsImages)
                                        .Include(x => x.Categories)
                                        .AsQueryable();

            if (minPrice != null && maxPrice != null)
                query = query.Where(x => x.SalesPrice >= (decimal)minPrice && x.SalesPrice <= (decimal)maxPrice);

            switch (sort)
            {
                case "AtoZ":
                    query = query.OrderBy(x => x.Name);
                    break;
                case "ZtoA":
                    query = query.OrderByDescending(x =>x.Name);
                    break;
                case "LowToHigh":
                    query = query.OrderBy(x => x.SalesPrice);
                    break;
                case "HighToLow":
                    query = query.OrderByDescending(x => x.SalesPrice);
                    break;
                case "AddingDate":
                    query = query.OrderByDescending(x => x.AddingDate);
                    break;
            }

            ViewBag.SortList = new List<SelectListItem>
            {
                new SelectListItem {Value="AtoZ",Text= "A-Z",Selected=sort=="AtoZ"},
                new SelectListItem { Value = "ZtoA", Text = "Z-A", Selected = sort == "ZtoA" },
                new SelectListItem { Value = "LowToHigh", Text = "Lowest Price", Selected = sort == "LowToHigh" },
                new SelectListItem { Value = "HighToLow", Text = "Highest Price", Selected = sort == "HighToLow" },
            };

            shopListDTO.Products = query.ToList();
            foreach (var item in shopListDTO.Products)
            {
                GenerateSignedUrl(item.ProductsImages);
            }
            ViewBag.MaxPriceLimit = _context.Products.Max(x => x.SalesPrice);
            ViewBag.MinPrice = minPrice ?? 0;
            ViewBag.MaxPrice = maxPrice ?? ViewBag.MaxPriceLimit;

            return View(shopListDTO);
        }
        private async Task GenerateSignedUrl(List<ProductsImages> images)
        {
            foreach (var item in images)
            {
                if (!string.IsNullOrWhiteSpace(item.ImageUrl))
                {
                    item.ImageUrl = await _googleService.GetSignedUrl(item.SavedImageUrl);
                }
            }

        }

        public IActionResult Search(string search)
        {
            SearchDTO searchDto = new SearchDTO
            {
                Products = _context.Products.Include(x => x.Categories)
                                         .Include(x => x.ProductsImages)
                                         .ToList(),
            };

            var query = _context.Products.Include(x => x.Categories)
                                            .Include(x => x.ProductsImages)
                                            .AsQueryable();

            if (search != null)
                query = query.Where(x => x.Name.Contains(search));
                 
            searchDto.Products = query.ToList();

            ViewBag.Search = search;

            return View(searchDto);
        }

    }
}
