using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class RoleBLL
    {
        public RoleBLL(RolesDAL rolesDAL)
        {
            RoleID = rolesDAL.RoleID;
            Name = rolesDAL.Name;
            Role_Type = rolesDAL.Role_Type;
            Privilege = rolesDAL.Privilege;
        }
        public RoleBLL ()
        {

        }
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Role_Type { get; set; }
        public string Privilege { get; set; }

        private RoleBLL _role;
        public RoleBLL Role
        {
            get
            {
                if (_role == null)
                {
                    throw new Exception("You must do something different");
                }
                return _role;
            }
        }
    }
}
