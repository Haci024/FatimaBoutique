using Bussiness.Services;
using DAL.DbConnection;
using DTO.ContactUsDTO;
using DTO.FrequentlyQuestionsDTO;
using DTO.SubscriberDTO;
using Entity.Models;
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

        private readonly Context _db;
        private readonly ISubscriberService _subscriberService; 
            

        public HomeController(IContactUsService contactUs,ISubscriberService service,Context db,IEmailService emailService, IFrequentlyQuestionService faq)
        {
            _db = db;
            _subscriberService = service;
            _faqService = faq;  
            _contactUsService = contactUs;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            AddContactUsDTO dto = new AddContactUsDTO();
            ViewBag.IsExsist = false;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(AddContactUsDTO dto)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.EmptyData = "Zəhmət olmasa bütün xanaları doldurun ki,sizinlə əlaqə saxlayanda problem yaşamayaq!";
                ViewBag.IsExsist = false;

                return View(dto);
            };
            
            ContactUs contactUs=new ContactUs();
            contactUs.Viewed = false;
            contactUs.Gmail = dto.Gmail;
            contactUs.PhoneNumber = dto.PhoneNumber;
            contactUs.FullName = dto.FullName;
            contactUs.Description=dto.Description;
            contactUs.Title = dto.Title;
            try
            {
                ViewBag.IsExsist = true;
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


        public IActionResult Blogs()
        {
            return View();
        }

        public IActionResult Faq()
        {
            IEnumerable<FrequentlyQuestions> frequentlyQuestions = _faqService.GetList();
            FrequentlyQuestionListDTO dto =new FrequentlyQuestionListDTO();
            dto.FrequentlyQuestions = _faqService.GetList();
            return View(dto);
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
            
            return View();
        }
        [HttpPost]
        
    }
}
