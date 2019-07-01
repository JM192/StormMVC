namespace BusinessLogicLayer
{

    using System;
    using DataAccessLayer;

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
            Game_Title = updatesDAL.Game_Title;
        }
        //UpdateBLL Constructor for Assigning Values into Itself
        public UpdateBLL()
        {

        }
        #region Direct mapping
        //Defining the Columns
        public int UpdateID { get; set; }
        public int Patch { get; set; }
        public string Expansion { get; set; }
        public string Add_Ons { get; set; }        
        public int GameID { get; set; }
        #endregion Direct mapping
        #region Indirect mapping

        public string Game_Title { get; set; }

        #endregion Indirect mapping

        //Checking for Invalid User Input
 
    }
}
