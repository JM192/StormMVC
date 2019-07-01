namespace BusinessLogicLayer
{

    using System;
    using DataAccessLayer;

    public class OrderBLL
    {
        public OrderBLL(OrdersDAL ordersDAL)
        {
            Order_Num = ordersDAL.Order_Num;
            Order_Name = ordersDAL.Order_Name;
            Purchase_Date = ordersDAL.Purchase_Date;
            UserID = ordersDAL.UserID;
            GameID = ordersDAL.GameID;
            Email = ordersDAL.Email;
            Name = ordersDAL.Name;
            Game_Title = ordersDAL.Game_Title;
        }
        public OrderBLL()
        {

        }
        #region Direct mapping
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

       
    }
}
