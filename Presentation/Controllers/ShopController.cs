using DAL.DbConnection;
using DTO.SearchDTO;
using DTO.ShopDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Presentation.Controllers
{
    public class ShopController : Controller
    {
        private readonly Context _context;

        public ShopController(Context context)
        {
            _context = context;
        }
        public IActionResult Index(double? minPrice = null, double? maxPrice = null, string sort = "AtoZ")
        {
            ShopListDTO shopListDTO = new ShopListDTO
            {
                
            };

            var query = _context.Blogs.Include(x => x.BlogLanguages)
                                        .Include(x => x.BlogImages)
                                        .Include(x => x.Categories).ThenInclude(x => x.CategoryLanguages)
                                        .AsQueryable();

            if (minPrice != null && maxPrice != null)
                query = query.Where(x => x.SalesPrice >= (decimal)minPrice && x.SalesPrice <= (decimal)maxPrice);

            switch (sort)
            {
                case "AtoZ":
                    query = query.OrderBy(x => x.BlogLanguages.FirstOrDefault().Title);
                    break;
                case "ZtoA":
                    query = query.OrderByDescending(x => x.BlogLanguages.FirstOrDefault().Title);
                    break;
                case "LowToHigh":
                    query = query.OrderBy(x => x.SalesPrice);
                    break;
                case "HighToLow":
                    query = query.OrderByDescending(x => x.SalesPrice);
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
            ViewBag.MaxPriceLimit = _context.Blogs.Max(x => x.SalesPrice);
            ViewBag.MinPrice = minPrice ?? 0;
            ViewBag.MaxPrice = maxPrice ?? ViewBag.MaxPriceLimit;

            return View(shopListDTO);
        }
    
        public IActionResult Search(string search, string languageKey = "az")
        {
            SearchDTO searchDto = new SearchDTO
            {
                Products = _context.Blogs.Include(x => x.Categories).ThenInclude(x => x.CategoryLanguages)
                                         .Include(x => x.BlogImages)
                                         .Include(x => x.BlogLanguages)
                                         .ToList(),
            };

            var query = _context.Blogs.Include(x => x.Categories).ThenInclude(x=>x.CategoryLanguages)
                                            .Include(x => x.BlogImages)
                                            .Include(x => x.BlogLanguages)
                                            .AsQueryable();

            if (search != null)
                query = query.Where(x => x.BlogLanguages.FirstOrDefault(x=>x.Language.Key == languageKey).Title.Contains(search));

            searchDto.Products = query.ToList();

            ViewBag.Search = search;

            return View(searchDto);
        }
    }
}
