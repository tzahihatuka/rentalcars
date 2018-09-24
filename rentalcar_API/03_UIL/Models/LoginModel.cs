using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03_UIL.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }
    }
}