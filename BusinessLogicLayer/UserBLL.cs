using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        //Telling the Compiler or "Program" that DataAccessLayer and BusinessLogicLayer Versions of the User Table
        //are the Same
        public UserBLL(UsersDAL usersDAL)
        {
            UserID = usersDAL.UserID;
            F_name = usersDAL.F_name;
            L_name = usersDAL.L_name;
            Address = usersDAL.Address;
            Ph_num = usersDAL.Ph_num;
            Email = usersDAL.Email;
            Username = usersDAL.Username;
            Password = usersDAL.Password;         
            News_sub = usersDAL.News_sub;
            RoleID = usersDAL.RoleID;
        }
        //UserBLL Constructor for Returning the Columns as Values Inside of Itself
        public UserBLL()
        {

        }
        //Defining Columns of the User Table for use in the BusinessLogicLayer side of CRUD
        public int UserID { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        public string Address { get; set; }
        public string Ph_num { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [DataType (DataType.Password)]
        public string Password { get; set; }        
        public string News_sub { get; set; }
        public int RoleID { get; set; }

        //Checking for Invalid User Input 
        private UserBLL _user;
        public UserBLL User
        {
            get
            {
                if (_user == null)
                {
                    throw new Exception("You must do something different");
                }
                return _user;
            }
        }
    }
}
