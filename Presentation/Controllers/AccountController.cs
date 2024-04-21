using Bussiness.Services;
using DAL.DbConnection;
using DTO.UserDTO;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Presentation.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly Context _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;


        [HttpGet]
        public IActionResult Login()
        {
            LoginUserDTO loginUserDTO= new LoginUserDTO();

            return View(loginUserDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginUserDTO dto)
        {

            return View();
        }
    
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            EmailForResetPasswordDTO forResetPasswordDTO= new EmailForResetPasswordDTO();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(EmailForResetPasswordDTO dto)
        {
            Random random = new Random();
            int AccessCode = random.Next(100000, 1000000);
       
            if (dto.Email == null)
            {
                ModelState.AddModelError("", "Elektron ünvanızı  daxil edin");
                return View(dto);
            }
            AppUser user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz elektron ünvanla heç bir istifadəçi qeydiyyatdan keçməyib!");
                return View(dto);
            }
            if (user.Email == dto.Email)
            {
                _emailService.ForgetPasswordEmail(user,dto.Email, AccessCode);
                TempData["Mail"] = dto.Email;
                user.ForgetPasswordCode =  AccessCode;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("ConfirmCode", "Account", new { email = dto.Email });

            }
            else
            {
                ModelState.AddModelError("", "Daxil edilən təsdiq kodu yalnışdır.Diqqətli daxil edin!");
                return View(dto);
            }
          
        }
        [HttpGet]
        public IActionResult ConfirmCode(string email)
        {
            var value = TempData["Mail"];
            ViewBag.Email = value;
            ConfirmCodeDTO dto= new ConfirmCodeDTO();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmCode(ConfirmCodeDTO DTO, string email)
        {
            if (email==null)
            {

                return View("Error");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Elektron ünvanızı düzgün daxil edin!");

                return View(DTO);
            }
            if (user.ForgetPasswordCode == DTO.ConfirmCode)
            {


                await _userManager.UpdateAsync(user);


                return RedirectToAction("NewPassword", "Account", new { email });
            }
            else
            {
                ModelState.AddModelError("", "Daxil edilən təsdiq kodu yalnışdır. Zəhmət olmasa kodu  düzgün daxil edin!");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> NewPassword(string email)
        {
            if (email == null)
            {

                return View("Error");
            }
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            ResetPasswordDTO dto= new ResetPasswordDTO();
            if (appUser == null)
            {
                return View("Error");
            }
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> NewPassword(ResetPasswordDTO DTO, string Email)
        {

            var user = await _userManager.FindByEmailAsync(Email);
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Şifrənizi və şifrə təkrarını daxil edin!");
                return View();
            }
            if (user != null)
            {
                if (DTO.Password.Length < 6)
                {
                    ModelState.AddModelError("", "Şifrə ən az 6 simvol uzunluğunda olmalıdır.");
                    return View();
                }
                if (!DTO.Password.Any(char.IsNumber))
                {
                    ModelState.AddModelError("", "Şifrənizdə minimum 1 rəqəm olmalıdır!");
                    return View();
                }

                if (!DTO.Password.Any(char.IsUpper) || !DTO.Password.Any(char.IsLower))
                {
                    ModelState.AddModelError("", "Şifrədə ən az bir böyük hərf ve bir kiçik hərf olmalıdır.");

                    return View();
                }
            }

            if (DTO.Password == DTO.ConfirmPassword)
            {
                if (!string.IsNullOrEmpty(DTO.Password))
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, DTO.Password);

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Yeni şifrəni daxil etmədiniz");
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifrələr eyni deyil!");
            }

            return View(DTO);
        }

        [HttpGet]
        public IActionResult Register()
        {
         RegisterUserDTO registerUserDTO=new RegisterUserDTO();

            return View(registerUserDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterUserDTO registerUserDTO)
        {
            return RedirectToAction("Login","Account");
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
