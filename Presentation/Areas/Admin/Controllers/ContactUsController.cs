﻿using Bussiness.Services;
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
            dto.Title = newContact.Title;
            dto.Gmail = newContact.Gmail;
            dto.Status = newContact.Viewed;


            return View(dto);
        }
    }
}
