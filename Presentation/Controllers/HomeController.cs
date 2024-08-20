using Bussiness.Services;
using DAL.DbConnection;
using DTO.ContactUsDTO;
using DTO.FrequentlyQuestionsDTO;
using DTO.ProductsDTO;
using DTO.SubscriberDTO;
using Entity.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFrequentlyQuestionService _faqService;
        private readonly IContactUsService _contactUsService;
        private readonly IEmailService _emailService;
        private readonly IProductService _productService;
        private readonly Context _db;
        private readonly ISubscriberService _subscriberService; 
            

        public HomeController(IContactUsService contactUs,IProductService productService
            ,ISubscriberService service,Context db,IEmailService emailService, IFrequentlyQuestionService faq)
        {
            _db = db;
            _productService = productService;
            _subscriberService = service;
            _faqService = faq;  
            _contactUsService = contactUs;
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult SearchBar(string query)
        {
            return ViewComponent("SearchBar", new { query = query });
        }
        [HttpGet]
        public IActionResult SetLanguage(string culture)
        {

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) 
                }
            );

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AboutUs(string data)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            AddContactUsDTO dto = new AddContactUsDTO();
            ViewBag.Success = false;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(AddContactUsDTO dto)
        {
            
            if (!ModelState.IsValid)
            {

                ViewBag.EmptyData = "Zəhmət olmasa bütün xanaları doldurun ki,sizinlə əlaqə saxlayanda problem yaşamayaq!";
                ViewBag.Success = false;

                return View(dto);
            };
            try
            {
            ContactUs contactUs=new ContactUs();
            contactUs.Viewed = false;
            contactUs.Email = dto.Email;
            contactUs.PhoneNumber = dto.PhoneNumber;
            contactUs.FullName = dto.FullName;
            contactUs.Description=dto.Description;
                contactUs.SendingDate = DateTime.UtcNow;
                ViewBag.Success = true;
                _emailService.ContactUsAvtoMessageForUser(dto);
                _contactUsService.Create(contactUs);
                return RedirectToAction("ContactUs", "Home");
            }
            catch (Exception ex)
            {
               
                TempData["ErrorMessage"] = "Model oluşturma sırasında bir hata oluştu: " + ex.Message;
                return View();
            }

          
        }


     
        public async Task<IActionResult> Faq()
        {
            IEnumerable<FaqListDTO> frequentlyQuestions =await  _faqService.ActiveFaqList();

            return View(frequentlyQuestions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSubscriber(NewSubscriberDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bu elektron ünvan artıq abunə olub");

                return RedirectToAction("Index", "Home");
            }
            Subscribers subscribers = new Subscribers();
            bool alreadySubscribe=_db.Subscribers.Any(x=>x.Email==dto.Gmail);
            if (alreadySubscribe)
            {
                ModelState.AddModelError("", "Bu elektron ünvan artıq abunə olub");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                subscribers.Email = dto.Gmail;
                _subscriberService.Create(subscribers);
                _emailService.NewSubscriberMail(dto.Gmail);
                return RedirectToAction("Index","Home");
            }
           
        }

        [HttpGet]
        public IActionResult UnSubscribe()
        {
            UnsubcribeDTO dto = new UnsubcribeDTO();
          
            return View(dto);
        }
        [HttpPost]
        public IActionResult UnSubscribe(UnsubcribeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Zəhmət olmasa elektron ünvanınızı daxil edin!");
              
                return View();
            }
            Subscribers subscribers = _db.Subscribers.Where(x => x.Email == dto.Email).FirstOrDefault();
            if (subscribers == null)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz elektron ünvan abunə olmayıb!");
               
                return View();
            }
            else
            {
                if (subscribers.Status == false)
                {
                 
                    subscribers.Status = true;
                    _subscriberService.Update(subscribers);
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Daxil etdiyiniz elektron ünvan abunəliyi dayandırılıb!");

                    return View();
                }
                
            }
           
           
        }
    }
}
