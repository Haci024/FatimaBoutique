using DAL.DbConnection;
using DTO.BlogsDTO;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            Blogs Product = _context.Blogs
                .Include(x => x.BlogImages)
                .Include(x => x.Categories).ThenInclude(x => x.CategoryLanguages)
                .Include(x => x.BlogLanguages)
                .FirstOrDefault(x => x.Id == id);

            //if (Product == null) return View("Error");

            ProductDetailDTO productDTO = new ProductDetailDTO
            {
                Product = Product,
                RelatedProducts = _context.Blogs.Include(x=>x.BlogLanguages)
                                                .Include(x => x.BlogImages)
                                                .Include(x => x.Categories).ThenInclude(x => x.CategoryLanguages)
                                                .Where(x => x.CategoryId == Product.CategoryId)
                                                .ToList(),
            };

            return View(productDTO);
        }

        public IActionResult ProductDetail(int id)
        {
            Blogs product = _context.Blogs
                .Include(x => x.BlogLanguages)
                .Include(x => x.BlogImages)
                .Include(x => x.Categories).ThenInclude(x => x.CategoryLanguages)
                .FirstOrDefault(x => x.Id == id);

            if (product == null) return View("Error");

            return PartialView("Modals/_QuickViewPartial", product);
        }
    }
}
