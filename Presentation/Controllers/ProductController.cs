using DAL.DbConnection;
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

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            Products product = _context.Products
                
                .Include(x => x.ProductsImages)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == id);

            if (product == null) return View("Error");

            return PartialView("Modals/_QuickViewPartial", product);
        }
    }
}
