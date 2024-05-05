using DAL.DbConnection;
using DTO.CustomerListDTO;
using Entity.Models;
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
    
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _db;
        private readonly RoleManager<IdentityRole> _role;
        private readonly SignInManager<AppUser> _signIn;
        public UsersController(UserManager<AppUser> userManager, Context db, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> role)
        {

            _db = db;
            _userManager = userManager;
            _role = role;
            _signIn = signInManager;
        }
    
        [HttpGet]
        public IActionResult AdminList()
        {
            List<AppUser> users = _db.Users.ToList();
            
            return View(users);
        }
        [HttpGet]
        public IActionResult CustomerList()
        {
            List<AppUser> users=_userManager.Users.ToList();
          
            return View(users);
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

    }
}
