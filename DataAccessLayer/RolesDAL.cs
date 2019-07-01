namespace DataAccessLayer
{
    public class RolesDAL
    {
        //Defining Role Table Columns
        public int RoleID { get; set; }
        public string Role { get; set; }
        public string Privileges { get; set; }

        //Allowing the use of Console.WriteLine() in the testing phase
        //public override string ToString()
        //{
        //    return $"RoleID:{RoleID} Role:{Role} Privileges:{Privileges}";
        //}
    }
}
