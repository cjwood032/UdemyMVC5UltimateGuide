using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5UltimateGuide.Models;
using UdemyMVC5UltimateGuide.ViewModels;
using UdemyMVC5UltimateGuide.Identity;

using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using Microsoft.Owin.Security;
namespace UdemyMVC5UltimateGuide.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser() { Email = rvm.Email, UserName = rvm.Username, PasswordHash = passwordHash, 
                City = rvm.City, Country = rvm.Country, Birthday = DateTime.Parse(rvm.DateOfBirth), Address = rvm.Address, PhoneNumber = rvm.Mobile };
            IdentityResult result = userManager.Create(user);
            if(result.Succeeded)
            {
                userManager.AddToRole(user.Id, "Customer");
                var authenticationManger = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManger.SignIn(new AuthenticationProperties(), userIdentity);
            }
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid data");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user!=null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid username/password");
                return View();
            }
           
        }
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}