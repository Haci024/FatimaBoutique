using Bussiness.Services;
using DTO.ContactUsDTO;
using Entity.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IEmailService _emailService;
        public ContactUsController(IContactUsService service,IEmailService emailService)
        {
            _contactUsService = service;
            _emailService = emailService;   
        }
        [HttpGet]
        public IActionResult UnReadMessageList()
        {
            ContactMessageListDTO dto =new ContactMessageListDTO();
                dto.UnReadMessages = _contactUsService.UnReadMessageList();
            return View(dto);
        }
        [HttpGet]
        public IActionResult ReadMessageList()
        {
            ContactMessageListDTO dto = new ContactMessageListDTO();
            dto.UnReadMessages = _contactUsService.UnReadMessageList();
            return View(dto);
        }
        [HttpGet]
        public IActionResult ReadMessage(int Id)
        {

            ReadContactUsDTO dto = new ReadContactUsDTO();
            ContactUs newContact = _contactUsService.GetById(Id);
            dto.Id = newContact.Id;
            dto.PhoneNumber = newContact.PhoneNumber;
            dto.FullName = newContact.FullName;
            dto.Description = newContact.Description;
           
            dto.Gmail = newContact.Email;
            dto.Status = newContact.Viewed;


            return View(dto);
        }
        [HttpGet]
        public IActionResult ReplyMessage(int Id)
        {
            ReplyMessageDTO dto = new ReplyMessageDTO();
            ContactUs newContact = _contactUsService.GetById(Id);
            dto.Id = Id;
            dto.FullName = newContact.FullName;
            dto.Gmail = newContact.Email;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReplyMessage(ReplyMessageDTO dto)
        {
            ContactUs newContact = _contactUsService.GetById(dto.Id);
            dto.Gmail= newContact.Email;    
            dto.FullName= newContact.FullName;

            if (dto.Title==null || dto.Description==null)
            {
                ModelState.AddModelError("", "Məlumatları tam doldurun!");
                return View(dto);
            }
            else
            {
                _emailService.ReplyMessageToCustomer(dto);
                return RedirectToAction("ReadMessageList");
            }
         
        }
    }
}
