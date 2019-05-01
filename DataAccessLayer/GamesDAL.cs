using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GamesDAL
    {
        //Defining Game Table Columns
        public int GameID { get; set; }
        public string Game_Title { get; set; }
        public string Release_Date { get; set; }
        public decimal Purchase_Price { get; set; }

        //Converting Game Table Columns for later Implementation
        public override string ToString()
        {
            return $"GameID:{GameID} Game_Title:{Game_Title} Release_Date:{Release_Date} Purchase_Price:{Purchase_Price}";
        }
    }
}
