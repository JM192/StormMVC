using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UsersDAL
    {
        //Defining User Table Columns
        public int UserID { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string Address { get; set; }
        public string Ph_num { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }        
        public string News_sub { get; set; }
        public int RoleID { get; set; }

        //Converting all User Table Columns to Strings for later Implementation
        public override string ToString()
        {
            return $"UserID:{UserID} F_name:{F_name} L_name:{L_name} Address:{Address} Ph_num:{Ph_num} Email:{Email} Username:{Username}" +
                $"Password:{Password} News_sub:{News_sub} RoleID:{RoleID}";
        }
    }
}
