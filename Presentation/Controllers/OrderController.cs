using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
