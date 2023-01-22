using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
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
                UserEmail=Register.UserEmail,
                PassWord=Register.PassWord, 
                
            };
            _userServices.RegisterUser(user);
          
            return View("SuccessRegisteration",Register);
        }
    }
}
