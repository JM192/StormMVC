namespace DataAccessLayer
{

    using System;

    public class OrdersDAL
    {
        #region Direct mapping
        //Defining Order Table Columns
        public int Order_Num { get; set; }
        public string Order_Name { get; set; }
        public DateTime Purchase_Date { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
        #endregion Direct mapping

        #region Indirect mapping

        public string Email { get; set; }
        public string Name { get; set; }
        public string Game_Title { get; set; }

        #endregion Indirect mapping

        ////Allowing the use of Console.WriteLine() in the testing phase
        //public override string ToString()
        //{
        //    return $"Order_Num:{Order_Num} Order_Name:{Order_Name} Purchase_Date:{Purchase_Date} UserID: {UserID} GameID: {GameID} Email:{Email} Name:{Name} Game_Title:{Game_Title}";
        //}
    }
}
