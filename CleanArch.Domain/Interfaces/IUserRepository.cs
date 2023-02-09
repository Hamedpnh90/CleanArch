using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);

        bool IsUserExist(string UserName);

        bool ISEmailExist(string UserEmail);

        bool IsUserValid(string password,string email);

        void Save();
    }
}
