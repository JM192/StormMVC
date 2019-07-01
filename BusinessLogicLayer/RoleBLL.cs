namespace BusinessLogicLayer
{

    using System;
    using DataAccessLayer;

    public class RoleBLL
    {
        public RoleBLL(RolesDAL rolesDAL)
        {
            RoleID = rolesDAL.RoleID;            
            Role = rolesDAL.Role;
            Privileges = rolesDAL.Privileges;
        }
        public RoleBLL ()
        {

        }
        public int RoleID { get; set; }        
        public string Role { get; set; }
        public string Privileges { get; set; }

  
    }
}
