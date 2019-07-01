namespace StormMVC.Models
{
    public class TwoLevelsViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }                
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string News_sub { get; set; }
        public int RoleID { get; set; } 
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Privileges { get; set; }
        public int PaymentID { get; set; }
        public string Address { get; set; }
        public string Ph_num { get; set; }
        public string Card_num { get; set; }
        public int Security_code { get; set; }
    }
}