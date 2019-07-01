namespace DataAccessLayer
{
    public class UpdatesDAL
    {
        #region Direct mapping
        //Defining Update Table Columns
        public int UpdateID { get; set; }
        public int Patch { get; set; }
        public string Expansion { get; set; }
        public string Add_Ons { get; set; }
        public int GameID { get; set; }
        #endregion Direct mapping
        #region Indirect mapping

        public string Game_Title { get; set; }

        #endregion Indirect mapping

        //Allowing the use of Console.WriteLine() in the testing phase
        //public override string ToString()
        //{
        //    return $"Update:{UpdateID} Patch:{Patch} Expansion:{Expansion} Add_Ons:{Add_Ons} GameID:{GameID} " +
        //        $"Game_Title:{Game_Title}";
        //}
    }
}
