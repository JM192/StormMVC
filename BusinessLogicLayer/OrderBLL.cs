using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class OrderBLL
    {
        public OrderBLL(OrdersDAL ordersDAL)
        {
            Order_Num = ordersDAL.Order_Num;
            Order_Name = ordersDAL.Order_Name;
            Purchase_Date = ordersDAL.Purchase_Date;
            UserID = ordersDAL.UserID;
            GameID = ordersDAL.GameID;
        }
        public OrderBLL()
        {

        }
        public int Order_Num { get; set; }
        public string Order_Name { get; set; }
        public string Purchase_Date { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }

        private OrderBLL _order;
        public OrderBLL Order
        {
            get
            {
                if (_order == null)
                {
                    throw new Exception("You must do something different");
                }
                return _order;
            }
        }
    }
}
