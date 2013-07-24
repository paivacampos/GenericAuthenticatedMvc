using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericAuthenticatedMvc.Models
{
    public class LoginModel
    {
        public string Username;
        public string Password;
        public bool RememberMe;
    }
}