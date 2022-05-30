using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class SignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}
