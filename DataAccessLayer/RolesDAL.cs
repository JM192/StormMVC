using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RolesDAL
    {
        //Defining Role Table Columns
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Role_Type { get; set; }
        public string Privilege { get; set; }

        //Converting Role Table Columns to Strings for later Implementation
        public override string ToString()
        {
            return $"RoleID:{RoleID} Name:{Name} Role_Type:{Role_Type} Privilege:{Privilege}";
        }
    }
}
