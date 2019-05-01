using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLLContext : IDisposable
    {
        private DALContext dalcontext = new DALContext();
        public BLLContext()
        {
            dalcontext.ConnectionString = @"Data Source=GDC-BC-18\SQLEXPRESS;Initial Catalog=StormTech;Integrated Security=True";
            
        }
        public void Dispose()
        {
            dalcontext.Dispose();
        }
        public List<GameBLL> GetAllGames()
        {
            List<GameBLL> rv = new List<GameBLL>();
            List<GamesDAL> list = dalcontext.ReadAllGames();
            foreach(GamesDAL item in list)
            {
                rv.Add(new GameBLL(item));
            }
            return rv;
        }
        public List<OrderBLL> GetAllOrders()
        {
            List<OrderBLL> rv = new List<OrderBLL>();
            List<OrdersDAL> list = dalcontext.ReadAllOrders();
            foreach(OrdersDAL item in list)
            {
                rv.Add(new OrderBLL(item));
            }
            return rv;
        }
        public List<RoleBLL> GetAllRoles()
        {
            List<RoleBLL> rv = new List<RoleBLL>();
            List<RolesDAL> list = dalcontext.ReadAllRoles();
            foreach(RolesDAL item in list)
            {
                rv.Add(new RoleBLL(item));
            }
            return rv;
        }
        public List<UpdateBLL> GetAllUpdates()
        {
            List<UpdateBLL> rv = new List<UpdateBLL>();
            List<UpdatesDAL> list = dalcontext.ReadAllUpdates();
            foreach(UpdatesDAL item in list)
            {
                rv.Add(new UpdateBLL(item));
            }
            return rv;
        }
        public List<UserBLL> GetAllUsers()
        {
            List<UserBLL> rv = new List<UserBLL>();
            List<UsersDAL> list = dalcontext.ReadAllUsers();
            foreach(UsersDAL item in list)
            {
                rv.Add(new UserBLL(item));
            }
            return rv;
        }
        public GameBLL GetGame(int gameID)
        {
            GameBLL rv;
            GamesDAL gdal = dalcontext.ReadSpecificGame(gameID);
            if (gdal == null) return null;
            return new GameBLL(gdal);
        }
        public OrderBLL GetOrder(int orderID)
        {
            OrderBLL rv;
            OrdersDAL odal = dalcontext.ReadSpecificOrder(orderID);
            if (odal == null) return null;
            return new OrderBLL(odal);
        }
        public RoleBLL GetRole(int roleID)
        {
            RoleBLL rv;
            RolesDAL rdal = dalcontext.ReadSpecificRole(roleID);
            if (rdal == null) return null;
            return new RoleBLL(rdal);
        }
        public UpdateBLL GetUpdate(int updateID)
        {
            UpdateBLL rv;
            UpdatesDAL udal = dalcontext.ReadSpecificUpdate(updateID);
            if (udal == null) return null;
            return new UpdateBLL(udal);
        }
        public UserBLL GetUser(int userID)
        {
            UserBLL rv;
            UsersDAL udal = dalcontext.ReadSpecificUser(userID);
            if (udal == null) return null;
            return new UserBLL(udal);
        }
        public UserBLL ReadSpecificUserByUsername(string userName)
        {
            UserBLL rv;
            UsersDAL udal = dalcontext.ReadSpecificUserByUsername(userName);
            if (udal == null) return null;
            return new UserBLL(udal);
        }
        public void DeleteGame(GameBLL game)
        {
            DeleteGame(game.GameID);
        }
        public void DeleteGame(int gameID)
        {
            dalcontext.DeleteExistingGame(gameID);
        }
        public void DeleteOrder(OrderBLL order)
        {
            DeleteOrder(order.Order_Num);
        }
        public void DeleteOrder(int Order_Num)
        {
            dalcontext.DeleteExistingOrder(Order_Num);
        }
        public void DeleteRole(RoleBLL role)
        {
            DeleteRole(role.RoleID);
        }
        public void DeleteRole(int RoleID)
        {
            dalcontext.DeleteExistingRole(RoleID);
        }
        public void DeleteUpdate(UpdateBLL update)
        {
            DeleteUpdate(update.UpdateID);
        }
        public void DeleteUpdate(int UpdateID)
        {
            dalcontext.DeleteExistingUpdate(UpdateID);
        }
        public void DeleteUser(UserBLL user)
        {
            DeleteUser(user.UserID);
        }
        public void DeleteUser(int UserID)
        {
            dalcontext.DeleteExistingUser(UserID);
        }                
        public void UpdateGame(GameBLL game)
        {
            UpdateGame(game.GameID, game.Game_Title, game.Release_Date, game.Purchase_Price);
        }
        public void UpdateGame(int gameID, string game_Title, string release_Date, decimal purchase_Price)
        {
            dalcontext.UpdateExistingGame(gameID, game_Title, release_Date, purchase_Price);
        }
        public void UpdateOrder(OrderBLL order)
        {
            UpdateOrder(order.Order_Num, order.Order_Name, order.Purchase_Date, order.UserID, order.GameID);
        }
        public void UpdateOrder(int order_Num, string order_Name, string purchase_Date, int userID, int gameID)
        {
            dalcontext.UpdateExistingOrder(order_Num, order_Name, purchase_Date, userID, gameID);
        }
        public void UpdateRole(RoleBLL role)
        {
            UpdateRole(role.RoleID, role.Name, role.Role_Type, role.Privilege);
        }
        public void UpdateRole(int roleID, string name, string role_Type, string privilege)
        {
            dalcontext.UpdateExistingRole(roleID, name, role_Type, privilege);
        }
        public void UpdateUpdate(UpdateBLL update)
        {
            UpdateUpdate(update.UpdateID, update.Patch, update.Expansion, update.Add_Ons, update.GameID);
        }
        public void UpdateUpdate(int updateID, decimal patch, string expansion, string add_Ons, int gameID)
        {
            dalcontext.UpdateExistingUpdate(updateID, patch, expansion, add_Ons, gameID);
        }
        public void UpdateUser(UserBLL user)
        {
            UpdateUser(user.UserID, user.F_name, user.L_name, user.Address, 
               user.Ph_num, user.Email, user.Username, user.Password, user.News_sub, user.RoleID);
        }
        public void UpdateUser(int userID, string f_name, string l_name, string address, 
            string ph_num, string email, string username, string password, string news_sub, int roleID)
        {
            dalcontext.UpdateExistingUser(userID, f_name, l_name, address, ph_num, email, username, password, news_sub, roleID);
        }
        
        public void InsertGame(GameBLL game)
        {
            InsertGame(game.GameID, game.Game_Title, game.Release_Date, game.Purchase_Price);
        }        
        public void InsertGame(int gameID, string game_Title, string release_Date, decimal purchase_Price)
        {
            dalcontext.InsertNewGame(gameID, game_Title, release_Date, purchase_Price);
        }
        public void InsertOrder(OrderBLL order)
        {
            InsertOrder(order.Order_Num, order.Order_Name, order.Purchase_Date, order.UserID, order.GameID);
        }
        public void InsertOrder(int order_Num, string order_Name, string purchase_Date, int userID, int gameID)
        {
            dalcontext.InsertNewOrder(order_Num, order_Name, purchase_Date, userID, gameID);
        }
        public void InsertRole(RoleBLL role)
        {
            InsertRole(role.RoleID, role.Name, role.Role_Type, role.Privilege);
        }        
        public void InsertRole(int roleID, string name, string role_Type, string privilege)
        {
            dalcontext.InsertNewRole(roleID, name, role_Type, privilege);
        }
        public void InsertUpdate(UpdateBLL update)
        {
            InsertUpdate(update.UpdateID, update.Patch, update.Expansion, update.Add_Ons, update.GameID);
        }
        public void InsertUpdate(int updateID, int patch, string expansion, string add_Ons, int gameID)
        {
            dalcontext.InsertNewUpdate(updateID, patch, expansion, add_Ons, gameID);
        }
        public int InsertUser(UserBLL user)
        {
            return InsertUser(user.UserID, user.F_name, user.L_name, user.Address,
                user.Ph_num, user.Email, user.Username, user.Password, user.News_sub, user.RoleID);
        }
        public int InsertUser(int userID, string f_name, string l_name, string address, string ph_num, string email, string username,
            string password, string news_sub, int roleID)
        {
            // salt is not being used in this example but could be added into the stored procedure if required
           return dalcontext.InsertNewUser(userID, f_name, l_name, address, ph_num, email, username, password, news_sub, roleID);
        }
       

        

    }
}
