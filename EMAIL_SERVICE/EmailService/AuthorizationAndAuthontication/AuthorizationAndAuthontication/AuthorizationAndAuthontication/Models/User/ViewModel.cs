using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthorizationAndAuthontication.Models.User
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Name requred")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email requred")]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool ValidateEmail { get; set; }
        public bool RememberMe { get; set; }
    }
}