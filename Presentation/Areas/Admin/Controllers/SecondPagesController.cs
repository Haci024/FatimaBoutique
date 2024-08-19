using Bussiness.Services;
using DAL.DbConnection;
using DTO.ContactUsDTO;
using DTO.FrequentlyQuestionsDTO;

using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SecondPagesController : Controller
    {
        private readonly Context _db;
        private readonly IContactUsService _contactUsService;
        private readonly IFrequentlyQuestionService _questionService;
        

        public SecondPagesController(Context db, IContactUsService service, IFrequentlyQuestionService frequentlyQuestionService)
        {
            _db = db;
            _contactUsService = service;
            _questionService= frequentlyQuestionService;
            
        }

        [HttpGet]
        public IActionResult AboutUsPage()
        {

            return View();
        }
   
 
        #region Tez-tez verilən suallar
        [HttpGet]
        public IActionResult ActiveFaqList()
        {
           IEnumerable<FrequentlyQuestions> frequentlyQuestions=_questionService.GetList();
          
            return View(frequentlyQuestions);
        }
        [HttpGet]
        public IActionResult DeactiveFaqList()
        {
            IEnumerable<FrequentlyQuestions> frequentlyQuestions = _questionService.GetList();

            return View(frequentlyQuestions);
        }
      
        [HttpGet]
        public IActionResult AddNewQuestion()
        {
            AddQuestionDTO dto = new AddQuestionDTO();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewQuestion(AddQuestionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bütün xanaları doldurun");
               
                return View(dto);
            }
            FrequentlyQuestions entity= new FrequentlyQuestions();
            entity.Question = dto.Question;
            entity.Answer = dto.Answer;
            entity.Status = false;
            _questionService.Create(entity);
            return RedirectToAction("ActiveFaqList");
        }
        [HttpGet]
        public IActionResult UpdateQuestion(int Id)
        {
            FrequentlyQuestions frequentlyQuestions = _questionService.GetById(Id);
            UpdateQuestionDTO dto= new UpdateQuestionDTO();
            dto.Id = frequentlyQuestions.Id;
            dto.Answer = frequentlyQuestions.Answer;
            dto.Question = frequentlyQuestions.Question;
            return View(dto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuestion(UpdateQuestionDTO dto)
        {
            if (dto==null)
            {

                return View("Error");
            }
            FrequentlyQuestions entiy = _questionService.GetById(dto.Id);
            entiy.Question = dto.Question;
            entiy.Answer = dto.Answer;
            _questionService.Update(entiy);
            return RedirectToAction("ActiveFaqList");
        }
        [HttpGet]
        public IActionResult DeactiveFaq(int Id)
        {
            FrequentlyQuestions entity= _questionService.GetById(Id);
            if (entity.Status)
            {
                entity.Status = false;
                _questionService.Update(entity);
                return RedirectToAction("DeactiveFaqList");
            }
            else
            {
                entity.Status = true;
                _questionService.Update(entity);
                return RedirectToAction("ActiveFaqList");
            }
            
        }
        #endregion
        #region Bizimlə Əlaqə
        [HttpGet]
        public IActionResult UnReadContactMessageList()
        {
            IEnumerable<ContactUs> ContactList=_contactUsService.UnReadMessageList();
            return View(ContactList);
        }
        [HttpGet]
        public IActionResult ReadContactMessageList()
        {
            IEnumerable<ContactUs> ContactList = _contactUsService.ReadMessageList();
            return View(ContactList);
        }
        [HttpGet]
        public IActionResult ReadMessage(int Id)
        {
          
            ReadContactUsDTO dto=new ReadContactUsDTO();
            ContactUs newContact = _contactUsService.GetById(Id);
            //dto.Id= newContact.Id; 
            //dto.PhoneNumber= newContact.PhoneNumber;
            //dto.FullName= newContact.FullName;
            //dto.Description= newContact.Description;
            //dto.Title= newContact.Title;
            //dto.Gmail= newContact.Gmail;
            //dto.Status = newContact.Viewed;


            return View(dto);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ReadMessage(ReadContactUsDTO dto)
        //{

        //   ContactUs contactUs=_contactUsService.GetById(dto.Id);
        //    //if (dto.Status)
        //    //{

        //    //    contactUs.Viewed = true;
        //    //    _contactUsService.Update(contactUs);
        //    //    return RedirectToAction("ReadContactMessageList");
        //    //}
        //    //else
        //    //{
        //    //    contactUs.Viewed = false;
        //    //    _contactUsService.Update(contactUs);
        //    //    return RedirectToAction("UnReadContactMessageList");
        //    //}


        //}


        #endregion
        #region Videolar

        #endregion
        
    }

}
