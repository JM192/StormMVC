using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StormMVC.Models
{
    public class LoginModel
    {
        public string message { get; set; }
        public string ReturnURL { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }
    }
}