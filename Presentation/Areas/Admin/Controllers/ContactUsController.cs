using Bussiness.Services;
using DTO.ContactUsDTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService service)
        {
            _contactUsService = service;
        }
        [HttpGet]
        public IActionResult UnReadMessageList()
        {
            IEnumerable<ContactUs> ContactList = _contactUsService.UnReadMessageList();
            return View(ContactList);
        }
        [HttpGet]
        public IActionResult ReadMessageList()
        {
            IEnumerable<ContactUs> ContactList = _contactUsService.ReadMessageList();
            return View(ContactList);
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
            dto.Title = newContact.Title;
            dto.Gmail = newContact.Gmail;
            dto.Status = newContact.Viewed;


            return View(dto);
        }
    }
}
