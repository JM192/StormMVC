using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrdersDAL
    {
        //Defining Order Table Columns
        public int Order_Num { get; set; }
        public string Order_Name { get; set; }
        public string Purchase_Date { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }

        //Converting Order Table Columns to Strings for later Implementation
        public override string ToString()
        {
            return $"Order_Num:{Order_Num} Order_Name:{Order_Name} Purchase_Date:{Purchase_Date} UserID: {UserID} GameID: {GameID}";
        }
    }
}
