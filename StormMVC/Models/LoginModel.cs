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