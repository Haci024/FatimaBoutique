using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
