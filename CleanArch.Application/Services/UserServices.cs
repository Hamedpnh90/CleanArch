using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class UserServices : IUserServices
    {

        IUserRepository _UserRepository;

        public UserServices(IUserRepository userRepository)
        {
            _UserRepository = userRepository;   
        }
        public int RegisterUser(User user)
        {
           _UserRepository.AddUser(user);
            _UserRepository.Save();
            return user.UserId; 
        }

        public CheckUserEnum.CheckUser checkUser(string UserName, string Email)
        {
           bool Emailnotvalid=_UserRepository.ISEmailExist(Email.Trim().ToLower());
           bool UserNotValid=_UserRepository.IsUserExist(UserName);
            if(Emailnotvalid && UserNotValid)
            {
                return CheckUserEnum.CheckUser.UserAndEmailNotValid;
            }
            else if(Emailnotvalid)
            {
                return CheckUserEnum.CheckUser.EmailExicted;
            }
            else if (UserNotValid)
            {
                return CheckUserEnum.CheckUser.USerExisted;
            }

            return CheckUserEnum.CheckUser.Ok;   
        }

        public bool IsUserExist(string password, string Email)
        {
            return _UserRepository.IsUserValid(PasswordHelper.EncodePasswordMd5(password), Email.Trim().ToLower());
        }
    }
}
