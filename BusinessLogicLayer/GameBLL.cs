using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
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
        public string Release_Date { get; set; }
        public decimal Purchase_Price { get; set; }

        private GameBLL _game;
        public GameBLL Game
        {
            get
            {
                if (_game == null)
                {
                    throw new Exception("You must do something different");
                }
                return _game;
            }
        }
    }
}
