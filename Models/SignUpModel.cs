using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Please Enter Your Name To Continue")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email To Continue")]
        public string Email { get; set; }
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleID { get; set; }
    }
}
