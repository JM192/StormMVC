namespace BusinessLogicLayer
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using DataAccessLayer;

    public class UserBLL
    {
        //Telling the Compiler or "Program" that DataAccessLayer and BusinessLogicLayer Versions of the User Table
        //are the Same
        public UserBLL(UsersDAL usersDAL)
        {
            UserID = usersDAL.UserID;
            Name = usersDAL.Name;
            Email = usersDAL.Email;
            Username = usersDAL.Username;
            Password = usersDAL.Password;         
            News_sub = usersDAL.News_sub;
            RoleID = usersDAL.RoleID;
            Salt = usersDAL.Salt;
            Hash = usersDAL.Hash;
            Privileges = usersDAL.Privileges;
        }
        // Mapping by constructor
        // UserBLL Constructor for Returning the Columns as Values Inside of Itself
        public UserBLL()
        {

        }
        //Defining Columns of the User Table for use in the BusinessLogicLayer side of CRUD
        public int UserID { get; set; }
        public string Name { get; set; }        
        public string Email { get; set; }
        public string Username { get; set; }

        [DataType (DataType.Password)]
        public string Password { get; set; }        
        public string News_sub { get; set; }
        public int RoleID { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        #region Indirect Mapping
        public string Privileges { get; set; }
        #endregion Indirect Mapping

        //Checking for Invalid User Input 
 
    }
}
