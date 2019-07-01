namespace BusinessLogicLayer
{

    using System;
    using System.Collections.Generic;
    using DataAccessLayer;
    // Also Disposable
    // Calls the Data Access Layer
    public class BLLContext : IDisposable
    {
        private DALContext ctx = new DALContext();
        public BLLContext()
        {
            ctx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StormTech;Integrated Security=True";
            
        }
        // Disposing the Data Access Layer
        public void Dispose()
        {
            ctx.Dispose();
        }
        public List<GameBLL> GetAllGames()
        {
            List<GameBLL> rv = new List<GameBLL>();
            List<GamesDAL> list = ctx.ReadAllGames();
            foreach(GamesDAL item in list)
            {
                rv.Add(new GameBLL(item));
            }
            return rv;
        }
        public List<OrderBLL> GetAllOrders()
        {
            List<OrderBLL> rv = new List<OrderBLL>();
            List<OrdersDAL> list = ctx.ReadAllOrders();
            foreach(OrdersDAL item in list)
            {
                rv.Add(new OrderBLL(item));
            }
            return rv;
        }
        public List<PaymentBLL> GetAllPayments()
        {
            List<PaymentBLL> rv = new List<PaymentBLL>();
            List<PaymentsDAL> list = ctx.ReadAllPayments();
            foreach(PaymentsDAL item in list)
            {
                rv.Add(new PaymentBLL(item));
            }
            return rv;
        }
        public List<RoleBLL> GetAllRoles()
        {
            List<RoleBLL> rv = new List<RoleBLL>();
            List<RolesDAL> list = ctx.ReadAllRoles();
            foreach(RolesDAL item in list)
            {
                rv.Add(new RoleBLL(item));
            }
            return rv;
        }
        public List<UpdateBLL> GetAllUpdates()
        {
            List<UpdateBLL> rv = new List<UpdateBLL>();
            List<UpdatesDAL> list = ctx.ReadAllUpdates();
            foreach(UpdatesDAL item in list)
            {
                rv.Add(new UpdateBLL(item));
            }
            return rv;
        }
        public List<UserBLL> GetAllUsers()
        {
            List<UserBLL> rv = new List<UserBLL>();
            List<UsersDAL> list = ctx.ReadAllUsers();
            foreach(UsersDAL item in list)
            {
                rv.Add(new UserBLL(item));
            }
            return rv;
        }
        public GameBLL GetGame(int gameID)
        {            
            GamesDAL gdal = ctx.ReadSpecificGame(gameID);
            if (gdal == null) return null;
            return new GameBLL(gdal);
        }
        public OrderBLL GetOrder(int orderID)
        {            
            OrdersDAL odal = ctx.ReadSpecificOrder(orderID);
            if (odal == null) return null;
            return new OrderBLL(odal);
        }
        public PaymentBLL GetPayment(int paymentID)
        {
            PaymentsDAL pdal = ctx.ReadSpecificPayment(paymentID);
            if (pdal == null) return null;
            return new PaymentBLL(pdal);
        }
        public RoleBLL GetRole(int roleID)
        {            
            RolesDAL rdal = ctx.ReadSpecificRole(roleID);
            if (rdal == null) return null;
            return new RoleBLL(rdal);
        }
        public UpdateBLL GetUpdate(int updateID)
        {            
            UpdatesDAL udal = ctx.ReadSpecificUpdate(updateID);
            if (udal == null) return null;
            return new UpdateBLL(udal);
        }
        public UserBLL GetUser(int userID)
        {            
            UsersDAL udal = ctx.ReadSpecificUser(userID);
            if (udal == null) return null;
            return new UserBLL(udal);
        }
        public UserBLL ReadSpecificUserByUsername(string userName)
        {            
            UsersDAL udal = ctx.ReadSpecificUserByUsername(userName);
            if (udal == null) return null;
            return new UserBLL(udal);
        }
        public void DeleteGame(GameBLL game)
        {
            DeleteGame(game.GameID);
        }
        public void DeleteGame(int gameID)
        {
            ctx.DeleteExistingGame(gameID);
        }
        public void DeleteOrder(OrderBLL order)
        {
            DeleteOrder(order.Order_Num);
        }
        public void DeleteOrder(int Order_Num)
        {
            ctx.DeleteExistingOrder(Order_Num);
        }
        public void DeletePayment(PaymentBLL payment)
        {
            DeletePayment(payment.PaymentID);
        }
        public void DeletePayment(int PaymentID)
        {
            ctx.DeleteExistingPayment(PaymentID);
        }
        public void DeleteRole(RoleBLL role)
        {
            DeleteRole(role.RoleID);
        }
        public void DeleteRole(int RoleID)
        {
            ctx.DeleteExistingRole(RoleID);
        }
        public void DeleteUpdate(UpdateBLL update)
        {
            DeleteUpdate(update.UpdateID);
        }
        public void DeleteUpdate(int UpdateID)
        {
            ctx.DeleteExistingUpdate(UpdateID);
        }
        public void DeleteUser(UserBLL user)
        {
            DeleteUser(user.UserID);
        }
        public void DeleteUser(int UserID)
        {
            ctx.DeleteExistingUser(UserID);
        }
        public void JustUpdateGame(GameBLL g)
        {
            g.Purchase_Price = AddTax(g.Purchase_Price);
            ctx.JustUpdateExistingGame(g.GameID, g.Game_Title, g.Release_Date, g.Purchase_Price);
        }
        public void JustUpdateGame(int exGameID, string newGame_Title, DateTime newRelease_Date, decimal newPurchase_Price)
        {
            ctx.JustUpdateExistingGame(exGameID, newGame_Title, newRelease_Date, newPurchase_Price);
        }
        public void SafeUpdateGame(int exgameID, string newgame_Title, DateTime newrelease_Date, decimal newpurchase_Price,
                                  string oldgame_Title, DateTime oldrelease_Date, decimal oldpurchase_Price)
        {
            ctx.SafeUpdateExistingGame(exgameID, newgame_Title, newrelease_Date, newpurchase_Price, oldgame_Title,
                                      oldrelease_Date, oldpurchase_Price);
        }
        public void JustUpdateOrder(OrderBLL o)
        {
            ctx.JustUpdateExistingOrder(o.Order_Num, o.Order_Name, o.Purchase_Date, o.UserID, o.GameID);
        }
        public void JustUpdateOrder(int exorder_Num, string neworder_Name, DateTime newpurchase_Date, int newuserID,
                                    int newgameID)
        {
            ctx.JustUpdateExistingOrder(exorder_Num, neworder_Name, newpurchase_Date, newuserID, newgameID);
        }
        public void SafeUpdateOrder(int exorder_Num, string neworder_Name, DateTime newpurchase_Date, int newuserID, 
                        int newgameID, string oldorder_Name, DateTime oldpurchase_Date, int olduserID, int oldgameID)
        {
            ctx.SafeUpdateExistingOrder(exorder_Num, neworder_Name, newpurchase_Date, newuserID, newgameID, oldorder_Name, oldpurchase_Date, olduserID, oldgameID);
        }

        public void JustUpdatePayment(PaymentBLL p)
        {
            JustUpdatePayment(p.PaymentID, p.UserID, p.Name, p.Address, p.Ph_num, p.Card_num, p.Security_code);
        }
        public void JustUpdatePayment(int expaymentID, int newuserID, string newName, string newAddress, string newph_Num,
                                      string newcard_Num, int newsecurity_Code)
        {
            ctx.JustUpdateExistingPayment(expaymentID, newuserID, newName, newAddress, newph_Num, newcard_Num, newsecurity_Code);
        }
        public void SafeUpdatePayment(int expaymentID, int newuserID, string newName, string newAddress, string newph_Num,
                                     string newcard_Num, int newsecurity_Code, int oldUserID, string oldName, string
                                     oldAddress, string oldph_Num, string oldcard_Num, int oldsecurity_Code)
        {
            ctx.SafeUpdateExistingPayment(expaymentID, newuserID, newName, newAddress, newph_Num, newcard_Num,
                newsecurity_Code, oldUserID, oldName, oldAddress, oldph_Num, oldcard_Num, oldsecurity_Code);
        }
        public void JustUpdateRole(RoleBLL r)
        {
            ctx.JustUpdateExistingRole(r.RoleID, r.Role, r.Privileges);
        }
        public void JustUpdateRole(int exroleID, string newrole, string newPrivileges)
        {
            ctx.JustUpdateExistingRole(exroleID, newrole, newPrivileges);
        }
        public void SafeUpdateRole(int exroleID, string newrole, string newprivileges, string oldrole, 
                                 string oldprivileges)
        {
            ctx.SafeUpdateExistingRole(exroleID, newrole, newprivileges, oldrole,
                                             oldprivileges);
        }
        public void JustUpdateUpdate(UpdateBLL u)
        {
            ctx.JustUpdateExistingUpdate(u.UpdateID, u.Patch, u.Expansion, u.Add_Ons, u.GameID);
        }
        public void JustUpdateUpdate(int exupdateID, decimal newPatch, string newExpansion, string newadd_Ons,
                                    int newgameID)
        {
            ctx.JustUpdateExistingUpdate(exupdateID, newPatch, newExpansion, newadd_Ons, newgameID);
        }
        public void SafeUpdateUpdate(int exupdateID, decimal newpatch, string newexpansion, string newadd_Ons,
                                   int newgameID, decimal oldpatch, string oldexpansion, string oldadd_Ons, int oldgameID)
        {
            ctx.SafeUpdateExistingUpdate(exupdateID, newpatch, newexpansion, newadd_Ons, newgameID,
                                                oldpatch, oldexpansion, oldadd_Ons, oldgameID);
        }
        public void JustUpdateUser(UserBLL us)
        {
            ctx.JustUpdateExistingUser(us.UserID, us.Name, us.Email, us.Username, us.Password, us.News_sub, us.RoleID,
                                       us.Salt, us.Hash);
        }
        public void JustUpdateUser(int exuserID, string newName, string newEmail, string newuserName, string newpassWord,
                                   string newnews_Sub, int newroleID, string newSalt, string newHash)
        {
            ctx.JustUpdateExistingUser(exuserID, newName, newEmail, newuserName, newpassWord, newnews_Sub, newroleID,
                                       newSalt, newHash);
        }
        public void SafeUpdateUser(int exuserID, string newName, string newEmail, string newuserName, string newpassWord,
                                   string newnews_Sub, int newroleID, string newSalt, string newHash, string oldName,
                                   string oldEmail, string olduserName, string oldpassWord, string oldnews_Sub,
                                   int oldroleID, string oldSalt, string oldHash)
        {
            ctx.SafeUpdateExistingUser(exuserID, newName, newEmail, newuserName, newpassWord, newnews_Sub,
                                              newroleID, newSalt, newHash, oldName, oldEmail, olduserName, 
                                              oldpassWord, oldnews_Sub, oldroleID, oldSalt, oldHash);
        }
        
        public int InsertGame(GameBLL game)
        {
          return  InsertGame(game.Game_Title, game.Release_Date, game.Purchase_Price);
        }        
        public int InsertGame(string game_Title, DateTime release_Date, decimal purchase_Price)
        {
            purchase_Price = AddTax(purchase_Price);
           return ctx.InsertNewGame(game_Title, release_Date, purchase_Price);
        }
        public int InsertOrder(OrderBLL order)
        {
           return InsertOrder(order.Order_Name, order.Purchase_Date, order.UserID, order.GameID);
        }
        public int InsertOrder(string order_Name, DateTime purchase_Date, int userID, int gameID)
        {
            return ctx.InsertNewOrder(order_Name, purchase_Date, userID, gameID);
        }
        public int InsertPayment(PaymentBLL payment)
        {
            return InsertPayment(payment.UserID, payment.Name, payment.Address, payment.Ph_num, payment.Card_num,                         payment.Security_code);
        }
        public int InsertPayment(int userID, string name, string address, string ph_Num, 
                                  string card_Num, int security_Code)
        {
            return ctx.InsertNewPayment(userID, name, address, ph_Num, card_Num, security_Code);
        }
        public int InsertRole(RoleBLL role)
        {
            return InsertRole(role.Role, role.Privileges);
        }        
        public int InsertRole(string role, string privileges)
        {
            return ctx.InsertNewRole(role, privileges);
        }
        public int InsertUpdate(UpdateBLL update)
        {
            return InsertUpdate(update.Patch, update.Expansion, update.Add_Ons, update.GameID);
        }
        public int InsertUpdate(int patch, string expansion, string add_Ons, int gameID)
        {
            return ctx.InsertNewUpdate(patch, expansion, add_Ons, gameID);
        }
        public int InsertUser(UserBLL user)
        {
            return ctx.InsertNewUser(user.Name, user.Email, user.Username, user.Password, user.News_sub, user.RoleID, user.Salt, user.Hash);
        }
        public int InsertUser(string name, string email, string username, string password, string news_sub, 
                              int roleID, string salt, string hash)
        {            
           return ctx.InsertNewUser(name, email, username, password, news_sub, roleID, salt, hash);
        }
        public decimal AddTax(decimal Purchase_Price)
        {
            return Purchase_Price * 1.10m;
        }
    }
}
