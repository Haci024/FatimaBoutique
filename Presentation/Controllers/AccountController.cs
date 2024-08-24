using Bussiness.Services;
using DAL.DbConnection;
using DTO.UserDTO;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;
using System.Net.WebSockets;
using Validation.AppUserVal;
using Validation.AppUserValidator;

namespace Presentation.Controllers
{

    public class AccountController : Controller
    {
        private readonly Context _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IBasketService _basketService;
        private readonly IOrdersService _orderService;

        public AccountController(Context db, IBasketService basketService, IOrdersService orderService ,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _basketService =basketService;
            _orderService= orderService;    
        }
        #region Giriş
        [HttpGet]
        public IActionResult Login()
        {
            LoginUserDTO loginUserDTO = new LoginUserDTO();

            return View(loginUserDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDTO dto)
        {
            if (dto.UserName == null && dto.Password == null)
            {
                ModelState.AddModelError("", "Elektron ünvanınızı və şifrənizi daxil edin!");

                return View(dto);
            }
           
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, true);
            AppUser appUser =await _userManager.FindByNameAsync(dto.UserName);
           
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Məlumatlarınızı 5 dəfə səhv daxil etdiyiniz  hesabınız 3 dəqiqə müddətinə blok edildi!");

                return View(dto);
            }
            if (result.Succeeded)
            {
                if (!appUser.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Bu hesab aktivləşdirilmədiyi üçün  sistem tərəfindən silindi.Buna görə cəhdiniz uğursuzdur.Hesabınızı aktivləşdirmək " +
                        "üçün yenidən qeydiyyatdan keçin və təsdiq kodunu daxil edin");

                   await _userManager.DeleteAsync(appUser);

                    return View(dto);
                }


                var roles = await _userManager.GetRolesAsync(appUser);
              
                if (roles.Contains("Admin") || roles.Contains("SuperAdmin"))
                {
                   
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                {
                    
                    return RedirectToAction("MyProfile", "Account");
                }

            }
            else
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yalnışdır!");
                return View(dto);
            }
          
        }

        #endregion
        #region Qeydiyyat
        [HttpGet]
        public IActionResult Register()
        {
            RegisterUserDTO registerUserDTO = new RegisterUserDTO();

            return View(registerUserDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDTO dto)
        {
            var validator = new RegisterValidator();
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);

                    return View(dto);
                }

            }
            Random random = new Random();
            int confirmCode = random.Next(100000, 999999);
            AppUser appUser = new AppUser()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                ConfirmationCode = confirmCode,


            };

            var result = await _userManager.CreateAsync(appUser, dto.Password);
            //var addRole = await _userManager.AddToRoleAsync(appUser, "Admin");
            if (result.Succeeded)
            {
                _emailService.SendActivateAccountCode(appUser);
                return RedirectToAction("ConfirmMail", "Account", new { appUser.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(dto);
            }
        }
        #endregion
        #region Hesab doğrulama
        [HttpGet]
        public IActionResult ConfirmMail(string email)
        {
            if (email == null)
            {
                return View("Error");
            }
            var User = _userManager.FindByEmailAsync(email);
            if (User == null)
            {

                return View("Error");
            }
            ConfirmCodeDTO dto = new ConfirmCodeDTO();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmMailAsync(string email, ConfirmCodeDTO dto)
        {
            if (email == null)
            {
                return View("Error");
            }
            AppUser User = await _userManager.FindByEmailAsync(email);
            if (User == null)
            {

                return View("Error");
            }
            if (User.ConfirmationCode == dto.ConfirmCode)
            {
                User.EmailConfirmed = true;
                await _userManager.UpdateAsync(User);

                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Daxil etdiyiniz kod düzgün deyil!");

                return View(dto);
            }




        }
        #endregion
        #region Şifrəmi unutdum

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            EmailForResetPasswordDTO forResetPasswordDTO = new EmailForResetPasswordDTO();

            return View(forResetPasswordDTO);
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(EmailForResetPasswordDTO dto)
        {
            Random random = new Random();
            int AccessCode = random.Next(100000, 1000000);

            if (dto.Email == null)
            {
                ModelState.AddModelError("", "Elektron ünvanızı  daxil edin");
                return View();
            }
            AppUser user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz elektron ünvanla heç bir istifadəçi qeydiyyatdan keçməyib!");
                return View();
            }
            if (user.Email == dto.Email)
            {
               
                TempData["Mail"] = dto.Email;
                user.ForgetPasswordCode = AccessCode;
                await _userManager.UpdateAsync(user);
                _emailService.ForgetPasswordEmail(user);
                return RedirectToAction("ConfirmCode", "Account", new { email = dto.Email });

            }
            else
            {
                ModelState.AddModelError("", "Daxil edilən təsdiq kodu yalnışdır.Diqqətli daxil edin!");
                return View();
            }

        }
        [HttpGet]
        public IActionResult ConfirmCode(string email)
        {
            var value = TempData["Mail"];
            ViewBag.Email = value;
            ConfirmCodeDTO dto = new ConfirmCodeDTO();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmCode(ConfirmCodeDTO DTO, string email)
        {
            if (email == null)
            {

                return View("Error");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Elektron ünvanızı düzgün daxil edin!");

                return View();
            }
            if (user.ForgetPasswordCode == DTO.ConfirmCode)
            {


                await _userManager.UpdateAsync(user);


                return RedirectToAction("NewPassword", "Account", new { email });
            }
            else
            {
                ModelState.AddModelError("", "Daxil edilən təsdiq kodu yalnışdır. Zəhmət olmasa kodu  düzgün daxil edin!");

                return View();
            }


        }
        [HttpGet]
        public async Task<IActionResult> NewPassword(string email)
        {
            if (email == null)
            {

                return View("Error");
            }
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            ResetPasswordDTO dto = new ResetPasswordDTO();
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
                if (DTO.Password.Length < 8)
                {
                    ModelState.AddModelError("", "Şifrə ən az 8 simvol uzunluğunda olmalıdır.");
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

        #endregion
        #region Profilim

        public IActionResult MyProfile()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction(nameof(Login));
            //}
            return View();
        }
        #endregion
        #region Hesabdan çıxış
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            AppUser AppUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (AppUser==null)
            {
                return View("Error");
            }
            else
            {
               await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
          
        }
        #endregion

    }
}
