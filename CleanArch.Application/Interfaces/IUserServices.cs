using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArch.Application.ViewModels.CheckUserEnum;

namespace CleanArch.Application.Interfaces
{
    public interface IUserServices
    {
        int RegisterUser(User user);

         CheckUser  checkUser(string UserName,string Email);

    }
}
