using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
    public class AccountViewModel
    {

        public class RegisterViewModel
        {
            [Key]
            public int UserId { get; set; }

            [Required]
            [MaxLength(100)]
            public string UserName { get; set; }
            [Required]
            [MaxLength(200)]
            public string UserEmail { get; set; }
            [Required]
            [MaxLength(200)]
            public string PassWord { get; set; }
           [Compare("PassWord")]
            public string RePassWord { get; set; }
        }


        public class LoginViewModel
        {
            [Required]
            [MaxLength(200)]
            public string UserEmail { get; set; }
            [Required]
            [MaxLength(200)]
            public string PassWord { get; set; }

            public bool RememberMe { get; set; }
        }
    }
}
