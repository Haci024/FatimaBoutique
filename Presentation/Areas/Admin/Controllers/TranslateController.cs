using Bussiness.Services;
using DTO.LanguageDTO;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using NuGet.Protocol;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class TranslateController : Controller
    {
        private readonly ILanguagesService _languageService;
        public TranslateController(ILanguagesService languageService)
        {
            _languageService = languageService;
        }
        [HttpGet]
        public async Task<IActionResult> TurkishFormat()
        {
            IEnumerable<DataListDTO> data = await _languageService.GetDataByLanguageKey("tr-TR"); 
            
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> RussianFormat()
        {
            IEnumerable<DataListDTO> data = await _languageService.GetDataByLanguageKey("ru-RU");

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> EnglishFormat()
        {
            IEnumerable<DataListDTO> data = await _languageService.GetDataByLanguageKey("en-US");

            return View(data);
        }
        [HttpGet]
        public IActionResult AddData()
        {
            AddDataDTO dto=new();
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddData(AddDataDTO dto)
        {
            var entity = new Language();
            entity.Culture = dto.Culture;
            entity.ResourceValue = dto.ResourceValue;
            entity.ResourceKey= dto.ResourceKey;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Zəhmət olmasa bütün xanaları doldurun!");

                return View(dto);   
            }
            _languageService.Create(entity);
            if (dto.Culture=="tr-TR")
            {
                return RedirectToAction("TurkishFormat");
            }
            else if (dto.Culture=="en-US")
            {
                return RedirectToAction("EnglishFormat");
            }
            else
            {
                return RedirectToAction("RussianFormat");
            }

          
        }
        [HttpGet]
        public async Task<IActionResult> UpdateData(Guid Id)
        {
            UpdateDataDTO dto = new ();
            var entity =await  _languageService.GetByGuidId(Id);
            dto.ResourceKey= entity.ResourceKey;
            dto.Culture = entity.Culture;
            dto.ResourceValue = entity.ResourceValue;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateData(UpdateDataDTO dto)
        {
            var entity = new Language();
            entity.Culture = dto.Culture;
            entity.ResourceValue = dto.ResourceValue;
            entity.ResourceKey = dto.ResourceKey;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Zəhmət olmasa bütün xanaları doldurun!");

                return View(dto);
            }
            _languageService.Create(entity);
            if (dto.Culture == "tr-TR")
            {
                return RedirectToAction("TurkishFormat");
            }
            else if (dto.Culture == "en-US")
            {
                return RedirectToAction("EnglishFormat");
            }
            else
            {
                return RedirectToAction("RussianFormat");
            }


        }
    }
}
