using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Virus_Remote.Core.Extensions;
using Virus_Remote.Data;
using Virus_Remote.Models;
using Virus_Remote.ViewModels;

namespace Virus_Remote.Controllers
{
    public class AccountController : Controller
    {
        private readonly RemoteDbContext _dbContext;

        public AccountController(RemoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
                //Fullname = "NatiqNCA",
                //Password = ""natiq@n1n2n3"",
                //UserName = "natiq@gmail.com"
        
            if (login != null)
            {
                Administrator user = null;
                if(!string.IsNullOrWhiteSpace(login.Password) && !string.IsNullOrWhiteSpace(login.Username))
                {
                   
                    user = await _dbContext.Administrators.FirstOrDefaultAsync(x => x.UserName == login.Username);
                    if(user != null)
                    {
                        var HashPassword = Crypto.VerifyHashedPassword(user.Password, login.Password);
                        if(HashPassword)
                        {
                           await SignInAsync(user.Id, user.Fullname, user.UserName);
                            return RedirectToAction("Index","Remote");
                        }
                    }
                }
            }
            return View(login);
        }

        public async Task SignInAsync(int id,string fullname,string username)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, fullname),
                new Claim(ClaimTypes.UserData, username),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }

        public async Task SignOutAsync()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await SignOutAsync();
            return Redirect("Login");
        }
    }
}