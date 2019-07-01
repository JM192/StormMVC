namespace DataAccessLayer
{
    public class UsersDAL
    {
        #region Direct
        //Defining User Table Columns
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }        
        public string News_sub { get; set; }
        public int RoleID { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }                
        #endregion Direct
        // TODO: Add to Indirect
        #region Indirect        
        public string Privileges { get; set; }
        #endregion Indirect

        //Allowing the use of Console.WriteLine() in the testing phase
        //public override string ToString()
        //{
        //    return $"UserID:{UserID} Name:{Name} Email:{Email} Username:{Username}" +
        //           $"Password:{Password} News_sub:{News_sub} RoleID:{RoleID} Privileges:{Privileges}" +
        //           $" Salt:{Salt} Hash:{Hash}";
        //}
    }
}
