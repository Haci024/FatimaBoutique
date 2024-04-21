using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
