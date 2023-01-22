using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {

       private UnivercityDbContext _Context;
        public UserRepository(UnivercityDbContext context)
        {
            _Context = context;
        }
        public void AddUser(User user)
        {
            _Context.user.Add(user);
        }

        public bool IsEmailExist(string UserEmail)
        {
          return  _Context.user.Any(E=>E.UserEmail == UserEmail); 
        }

        public bool IsUserExist(string UserName)
        {
          return  _Context.user.Any(u=>u.UserName == UserName);
        }

        public void Save()
        {
            _Context.SaveChanges(); 
        }
    }
}
