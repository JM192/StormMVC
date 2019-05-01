using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StormMVC.Models
{
    public class TwoLevelsViewModel
    {        
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string Address { get; set; }
        public string Ph_num { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string News_sub { get; set; }
        public int RoleID { get; set; }
        public int Order_Num { get; set; }
        public string Order_Name { get; set; }
        public string Purchase_Date { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }

        
    }
}