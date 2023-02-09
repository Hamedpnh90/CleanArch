using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(200)]
        public string? UserEmail { get; set; }
        [Required]
        [MaxLength(200)]
        public string? PassWord { get; set; }

        public bool RememberMe { get; set; }

    }
}
