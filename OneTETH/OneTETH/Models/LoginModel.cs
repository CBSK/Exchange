using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneTETH.Models
{
    public class LoginModel
    {
        public int UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool IsLogged { get; set; }

        public string RequestPath { get; set; }
        public bool SessionNotExpired { get; set; }

    }
}