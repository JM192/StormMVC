namespace BusinessLogicLayer
{

    using System;
    using DataAccessLayer;

    public class GameBLL
    {
        public GameBLL(GamesDAL gamesDAL)
        {
            GameID = gamesDAL.GameID;
            Game_Title = gamesDAL.Game_Title;
            Release_Date = gamesDAL.Release_Date;
            Purchase_Price = gamesDAL.Purchase_Price;
        }
        public GameBLL()
        {

        }
        public int GameID { get; set; }
        public string Game_Title { get; set; }
        public DateTime Release_Date { get; set; }
        public decimal Purchase_Price { get; set; }

       
    }
}
