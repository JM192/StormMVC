using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UpdateBLL
    {
        //Telling the Compiler or "Program" that DataAccessLayer and BusinessLogicLayer Versions of the Update Table
        //are the Same
        public UpdateBLL(UpdatesDAL updatesDAL)
        {
            UpdateID = updatesDAL.UpdateID;
            Patch = updatesDAL.Patch;
            Expansion = updatesDAL.Expansion;
            Add_Ons = updatesDAL.Add_Ons;            
            GameID = updatesDAL.GameID;
        }
        //UpdateBLL Constructor for Assigning Values into Itself
        public UpdateBLL()
        {

        }
        //Defining the Columns
        public int UpdateID { get; set; }
        public int Patch { get; set; }
        public string Expansion { get; set; }
        public string Add_Ons { get; set; }        
        public int GameID { get; set; }

        //Checking for Invalid User Input
        private UpdateBLL _update;
        public UpdateBLL Update
        {
            get
            {
                if (_update == null)
                {
                    throw new Exception("You must do something different");
                }
                return _update;
            }
        }
    }
}
