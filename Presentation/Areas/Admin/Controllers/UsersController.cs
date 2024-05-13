using Bussiness.Services;
using DAL.DbConnection;
using DTO.CustomerListDTO;
using Entity.Models;
//using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Runtime.CompilerServices;
using System.Text;


namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _db;
        private readonly RoleManager<IdentityRole> _role;
        private readonly ISubscriberService _subscribers;
        private readonly SignInManager<AppUser> _signIn;
        public UsersController(UserManager<AppUser> userManager,ISubscriberService subscriber, Context db, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> role)
        {

            _db = db;
            _userManager = userManager;
            _subscribers = subscriber;
            _role = role;
            _signIn = signInManager;
        }
    
        [HttpGet]
        public async Task<IActionResult> AdminList()
        {
            var role =await _role.FindByNameAsync("Admin");

          
            CustomerListDTO dto=new CustomerListDTO();
            dto.AdminList= await _userManager.GetUsersInRoleAsync(role.Name);

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var role = await _role.FindByNameAsync("User");

            CustomerListDTO dto = new CustomerListDTO();
            dto.CustomerList = await _userManager.GetUsersInRoleAsync(role.Name);

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> SubscriberList()
        {

             CustomerListDTO dto = new CustomerListDTO();
            dto.Subscribers=_subscribers.GetList();


            return View(dto);
        }
        [HttpGet]
        public IActionResult BlockCustomer(string Id)
        {
            
            AppUser appUser=_db.Users.FirstOrDefault(x=>x.Id == Id);
            if (appUser.Status)
            {
                appUser.Status = false;
                
            }
            else
            {
                appUser.Status=true;
            }
            _userManager.UpdateAsync(appUser);
            return View("CustomerList");
        }
        [HttpGet]
        public IActionResult Logout()
        {

            _signIn.SignOutAsync();
            return RedirectToAction("Index","Home",new {area=""});
        }
        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
           
            return View(appUser);
        }


    }
}
