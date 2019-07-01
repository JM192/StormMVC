using System;

namespace DataAccessLayer
{
    public class GamesDAL
    {
        //Defining Game Table Columns
        public int GameID { get; set; }
        public string Game_Title { get; set; }
        public DateTime Release_Date  { get; set; }
        
        public decimal Purchase_Price { get; set; }

        
}
    }
