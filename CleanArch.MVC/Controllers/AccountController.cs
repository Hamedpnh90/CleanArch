using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CleanArch.Application.ViewModels.AccountViewModel;
using static CleanArch.Application.ViewModels.CheckUserEnum;

namespace CleanArch.MVC.Controllers
{
    
   
    public class AccountController : Controller
    {
        IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel Register)
        {

            if(!ModelState.IsValid) 

                return View(Register);


            CheckUser check= _userServices.checkUser(Register.UserName,Register.UserEmail);

            if(check!=CheckUser.Ok)
            {
                ViewBag.check = check;
                return View(Register);
            }


            User user = new User()
            {
                UserName=Register.UserName, 
                UserEmail=Register.UserEmail.Trim().ToLower(),
                PassWord=PasswordHelper.EncodePasswordMd5(Register.PassWord), 
                
            };
            _userServices.RegisterUser(user);
          
            return View("SuccessRegisteration",Register);
        }


        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login); 
            }

            if(!_userServices.IsUserExist(login.PassWord,login.UserEmail))
            {
                ModelState.AddModelError("UserEmail", "User Not Found");
                return View(login); 

            }

            var claims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name,login.UserEmail)
            };

            var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principle=new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principle, properties); 

            return Redirect("/");
        }
    }
}
