using Bussiness.Services;
using DAL.DbConnection;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SecondPagesController : Controller
    {
        private readonly Context _db;
        private readonly IContactUsService _service;

        public SecondPagesController(Context db, IContactUsService service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet]
        public IActionResult AboutUsPage()
        {

            return View();
        }
        [HttpGet]
        public IActionResult UpdateAboutUs()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAboutUs(int Id)
        {

            return View();
        }
 
        #region Tez-tez verilən suallar
        [HttpGet]
        public IActionResult FrequentlyQuestionList()
        {

            return View();
        }
        #endregion
        #region Bizimlə Əlaqə
        [HttpGet]
        public IActionResult UnReadContactMessageList()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult ReadContactMessageList()
        {

            return View();
        }
        [HttpGet]
        public IActionResult ReadMessage(int Id)
        {
          


            return View();
        }
    
        #endregion
    }

}
