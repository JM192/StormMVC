using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UpdatesDAL
    {
        //Defining Update Table Columns
        public int UpdateID { get; set; }
        public int Patch { get; set; }
        public string Expansion { get; set; }
        public string Add_Ons { get; set; }
        public int GameID { get; set; }

        //Converting Update Table Columns to Strings for later Implementation
        public override string ToString()
        {
            return $"Update:{UpdateID} Patch:{Patch} Expansion:{Expansion} Add_Ons:{Add_Ons} GameID:{GameID}";
        }
    }
}
