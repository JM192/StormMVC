namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using MyLogger;
    

    /// <summary>
    /// AUTHOR: John McGillis
    /// COMPANY: Onshore Outsourcing
    /// DESCRIPTION: Data Access Layer DAL Context Class
    /// </summary>

    // implementing IDisposable indicates that this class has heavy duty resources that need to be
    // released 'on-demand'
    // this class has a database connection which is such a resource
    // implementing this interface also allows the c# 'using' pattern to be used on instances of this class
    public class Mapper
    {
        //The Following Helper Methods Take the Individual Data Readers and Return the Following DataAccessLayer
        //Tables and Their Respective Columns as Inputs
        public static GamesDAL GamesDALFromReader(SqlDataReader r)
        {
            int GameIdOrdinal;
            int Game_TitleOrdinal;
            int Release_DateOrdinal;
            int Purchase_PriceOrdinal;

            GamesDAL rv = new GamesDAL();
            GameIdOrdinal = r.GetOrdinal("GameID");
            Game_TitleOrdinal = r.GetOrdinal("Game_Title");
            Release_DateOrdinal = r.GetOrdinal("Release_Date");
            Purchase_PriceOrdinal = r.GetOrdinal("Purchase_Price");

            rv.GameID = r.GetInt32(GameIdOrdinal);
            rv.Game_Title = r.GetString(Game_TitleOrdinal);
            rv.Release_Date = r.GetDateTime(Release_DateOrdinal);
            rv.Purchase_Price = r.GetDecimal(Purchase_PriceOrdinal);
            return rv;
        }
        public static OrdersDAL OrdersDALFromReader(SqlDataReader r)
        {
            int Order_NumOrdinal;
            int Order_NameOrdinal;
            int Purchase_DateOrdinal;
            int UserIdOrdinal;
            int GameIdOrdinal;
            int EmailOrdinal;
            int NameOrdinal;
            int Game_TitleOrdinal;

            OrdersDAL rv = new OrdersDAL();
            Order_NumOrdinal = r.GetOrdinal("Order_Num");
            Order_NameOrdinal = r.GetOrdinal("Order_Name");
            Purchase_DateOrdinal = r.GetOrdinal("Purchase_Date");
            UserIdOrdinal = r.GetOrdinal("UserID");
            GameIdOrdinal = r.GetOrdinal("GameID");
            EmailOrdinal = r.GetOrdinal("Email");
            NameOrdinal = r.GetOrdinal("Name");
            Game_TitleOrdinal = r.GetOrdinal("Game_Title");

            rv.Order_Num = r.GetInt32(Order_NumOrdinal);
            rv.Order_Name = r.GetString(Order_NameOrdinal);
            rv.Purchase_Date = r.GetDateTime(Purchase_DateOrdinal);
            rv.UserID = r.GetInt32(UserIdOrdinal);
            rv.GameID = r.GetInt32(GameIdOrdinal);
            rv.Email = r.GetString(EmailOrdinal);
            rv.Name = r.GetString(NameOrdinal);
            rv.Game_Title = r.GetString(Game_TitleOrdinal);
            return rv;
        }
        public static PaymentsDAL PaymentsDALFromReader(SqlDataReader r)
        {
            int PaymentIdOrdinal;
            int UserIdOrdinal;
            int NameOrdinal;
            int AddressOrdinal;
            int Ph_numOrdinal;
            int Card_numOrdinal;
            int Security_codeOrdinal;
            int EmailOrdinal;
            

            PaymentsDAL pd = new PaymentsDAL();
            PaymentIdOrdinal = r.GetOrdinal("PaymentID");
            UserIdOrdinal = r.GetOrdinal("UserID");
            NameOrdinal = r.GetOrdinal("Name");
            AddressOrdinal = r.GetOrdinal("Address");
            Ph_numOrdinal = r.GetOrdinal("Ph_num");
            Card_numOrdinal = r.GetOrdinal("Card_num");
            Security_codeOrdinal = r.GetOrdinal("Security_code");
            EmailOrdinal = r.GetOrdinal("Email");            

            pd.PaymentID = r.GetInt32(PaymentIdOrdinal);
            pd.UserID = r.GetInt32(UserIdOrdinal);
            pd.Name = r.GetString(NameOrdinal);
            pd.Address = r.GetString(AddressOrdinal);
            pd.Ph_num = r.GetString(Ph_numOrdinal);
            pd.Card_num = r.GetString(Card_numOrdinal);
            pd.Security_code = r.GetInt32(Security_codeOrdinal);
            pd.Email = r.GetString(EmailOrdinal);
            return pd;
        }
        public static RolesDAL RolesDALFromReader(SqlDataReader r)
        {
            int RoleIdOrdinal;            
            int RoleOrdinal;
            int PrivilegesOrdinal;

            RolesDAL rv = new RolesDAL();
            RoleIdOrdinal = r.GetOrdinal("RoleID");            
            RoleOrdinal = r.GetOrdinal("Role");
            PrivilegesOrdinal = r.GetOrdinal("Privileges");

            rv.RoleID = r.GetInt32(RoleIdOrdinal);            
            rv.Role = r.GetString(RoleOrdinal);
            rv.Privileges = r.GetString(PrivilegesOrdinal);
            return rv;
        }
        public static UpdatesDAL UpdatesDALFromReader(SqlDataReader r)
        {
            int UpdateIdOrdinal;
            int PatchOrdinal;
            int ExpansionOrdinal;
            int Add_OnsOrdinal;
            int GameIdOrdinal;
            int Game_TitleOrdinal;

            UpdatesDAL rv = new UpdatesDAL();
            UpdateIdOrdinal = r.GetOrdinal("UpdateID");
            PatchOrdinal = r.GetOrdinal("Patch");
            ExpansionOrdinal = r.GetOrdinal("Expansion");
            Add_OnsOrdinal = r.GetOrdinal("Add_Ons");
            GameIdOrdinal = r.GetOrdinal("GameID");
            Game_TitleOrdinal = r.GetOrdinal("Game_Title");

            rv.UpdateID = r.GetInt32(UpdateIdOrdinal);
            rv.Patch = r.GetInt32(PatchOrdinal);
            rv.Expansion = r.GetString(ExpansionOrdinal);
            rv.Add_Ons = r.GetString(Add_OnsOrdinal);
            rv.GameID = r.GetInt32(GameIdOrdinal);
            rv.Game_Title = r.GetString(Game_TitleOrdinal);
            return rv;
        }
        public static UsersDAL UsersDALFromReader(SqlDataReader r)
        {
            int UserIdOrdinal;
            int NameOrdinal;            
            int EmailOrdinal;
            int UsernameOrdinal;
            int PasswordOrdinal;
            int News_subOrdinal;
            int RoleIdOrdinal;
            int SaltOrdinal;
            int HashOrdinal;            
            UsersDAL rv = new UsersDAL();

            UserIdOrdinal = r.GetOrdinal("UserID");
            NameOrdinal = r.GetOrdinal("Name");            
            EmailOrdinal = r.GetOrdinal("Email");
            UsernameOrdinal = r.GetOrdinal("Username");
            PasswordOrdinal = r.GetOrdinal("Password");            
            News_subOrdinal = r.GetOrdinal("News_sub");
            RoleIdOrdinal = r.GetOrdinal("RoleID");
            SaltOrdinal = r.GetOrdinal("Salt");
            HashOrdinal = r.GetOrdinal("Hash");            

            rv.UserID = r.GetInt32(UserIdOrdinal);
            rv.Name = r.GetString(NameOrdinal);            
            rv.Email = r.GetString(EmailOrdinal);
            rv.Username = r.GetString(UsernameOrdinal);
            rv.Password = r.GetString(PasswordOrdinal);
            rv.News_sub = r.GetString(News_subOrdinal);
            rv.RoleID = r.GetInt32(RoleIdOrdinal);
            rv.Salt = r.GetString(SaltOrdinal);
            rv.Hash = r.GetString(HashOrdinal);
            return rv;
        }
    }
    //Implementation of IDisposable
    public class DALContext : IDisposable
    {
        private System.Data.SqlClient.SqlConnection _connection = new SqlConnection();
        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }
        // closing the connection
        public void Dispose()
        {
            _connection.Dispose();
        }
        // Ensure connected checking
        private void EnsureConnected()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                
            }
        }
        // DataAccessLayer CRUD Methods

        #region Create
        public int InsertNewGame( string Game_Title, DateTime Release_Date, decimal Purchase_Price)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertGames", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GameID", 0);
                command.Parameters.AddWithValue("@Game_Title", Game_Title);
                command.Parameters.AddWithValue("@Release_Date", Release_Date);
                command.Parameters.AddWithValue("@Purchase_Price", Purchase_Price);
                command.Parameters["@GameID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
                return Convert.ToInt32(command.Parameters["@GameID"].Value);
            }
        }
        public int InsertNewOrder(string Order_Name, DateTime Purchase_Date, int UserID, int GameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertOrders", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Order_Num", 0);
                command.Parameters.AddWithValue("@Order_Name", Order_Name);
                command.Parameters.AddWithValue("@Purchase_Date", Purchase_Date);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@GameID", GameID);
                command.Parameters["@Order_Num"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
                return Convert.ToInt32(command.Parameters["@Order_Num"].Value);
            }                
        }
        public int InsertNewPayment(int UserID, string Name, string Address, string Ph_num,
                                    string Card_num, int Security_code)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertPayment_info", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PaymentID", 0);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Ph_num", Ph_num);
                command.Parameters.AddWithValue("@Card_num", Card_num);
                command.Parameters.AddWithValue("@Security_code", Security_code);
                command.Parameters["@PaymentID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                   
                }
                return Convert.ToInt32(command.Parameters["@PaymentID"].Value);
            }
        }
        public int InsertNewRole(string Role, string Privilege)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertRoles", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", 0);                
                command.Parameters.AddWithValue("@Role", Role);
                command.Parameters.AddWithValue("@Privileges", Privilege);
                command.Parameters["@RoleID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
                return Convert.ToInt32(command.Parameters["@RoleID"].Value);
            }
        }
        public int InsertNewUpdate(decimal Patch, string Expansion, string Add_Ons, int GameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertUpdates", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UpdateID", 0);
                command.Parameters.AddWithValue("@Patch", Patch);
                command.Parameters.AddWithValue("@Expansion", Expansion);
                command.Parameters.AddWithValue("@Add_Ons", Add_Ons);
                command.Parameters.AddWithValue("@GameID", GameID);
                command.Parameters["@UpdateID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
                return Convert.ToInt32(command.Parameters["@UpdateID"].Value);
            }
        }
        public int InsertNewUser(string Name, string Email, string Username,
                                string Password, string News_sub, int RoleID, string Salt, string Hash)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", 0);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);                
                command.Parameters.AddWithValue("@News_sub", News_sub);
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@Salt", Salt);
                command.Parameters.AddWithValue("@Hash", Hash);
                command.Parameters["@UserID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
                return Convert.ToInt32(command.Parameters["@UserID"].Value);
            }
        }
        #endregion Create
        #region Just and Safe Update
        public void JustUpdateExistingGame(int ExistingGameID, string NewGame_Title, DateTime NewRelease_Date, decimal                                        NewPurchase_Price)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_JustUpdateGames", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingGameID", ExistingGameID);
                command.Parameters.AddWithValue("@NewGame_Title", NewGame_Title);
                command.Parameters.AddWithValue("@NewRelease_Date", NewRelease_Date);
                command.Parameters.AddWithValue("@NewPurchase_Price", NewPurchase_Price);
                command.Parameters["@ExistingGameID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void SafeUpdateExistingGame(int ExistingGameID, string NewGame_Title, DateTime NewRelease_Date, decimal NewPurchase_Price, string OldGame_Title, DateTime OldRelease_Date, decimal OldPurchase_Price)
        {
            
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_SafeUpdateGames", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingGameID", ExistingGameID);
                command.Parameters.AddWithValue("@NewGame_Title", NewGame_Title);
                command.Parameters.AddWithValue("@NewRelease_Date", NewRelease_Date);
                command.Parameters.AddWithValue("@NewPurchase_Price", NewPurchase_Price);
                command.Parameters.AddWithValue("@OldGame_Title", OldGame_Title);
                command.Parameters.AddWithValue("@OldRelease_Date", OldRelease_Date);
                command.Parameters.AddWithValue("@OldPurchase_Price", OldPurchase_Price);
                command.Parameters["@ExistingGameID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
                
            }
        }
        public void JustUpdateExistingOrder(int ExistingOrder_Num, string NewOrder_Name, DateTime NewPurchase_Date, 
                                           int NewUserID, int NewGameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_JustUpdateOrders", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingOrder_Num", ExistingOrder_Num);
                command.Parameters.AddWithValue("@NewOrder_Name", NewOrder_Name);
                command.Parameters.AddWithValue("@NewPurchase_Date", NewPurchase_Date);
                command.Parameters.AddWithValue("@NewUserID", NewUserID);
                command.Parameters.AddWithValue("@NewGameID", NewGameID);
                command.Parameters["@ExistingOrder_Num"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }

        }
        public void SafeUpdateExistingOrder(int ExistingOrder_Num, string NewOrder_Name, DateTime NewPurchase_Date,
                                           int NewUserID, int NewGameID, string OldOrder_Name, 
                                           DateTime OldPurchase_Date, int OldUserID, int OldGameID)
        {
            
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_SafeUpdateOrders", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingOrder_Num", ExistingOrder_Num);
                command.Parameters.AddWithValue("@NewOrder_Name", NewOrder_Name);
                command.Parameters.AddWithValue("@NewPurchase_Date", NewPurchase_Date);
                command.Parameters.AddWithValue("@NewUserID", NewUserID);
                command.Parameters.AddWithValue("@NewGameID", NewGameID);
                command.Parameters.AddWithValue("@OldOrder_Name", OldOrder_Name);
                command.Parameters.AddWithValue("@OldPurchase_Date", OldPurchase_Date);
                command.Parameters.AddWithValue("@OldUserID", OldUserID);
                command.Parameters.AddWithValue("@OldGameID", OldGameID);
                command.Parameters["@ExistingOrder_Num"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }                
            }
        }
        public void JustUpdateExistingPayment(int ExistingPaymentID, int NewUserID, string NewName, string NewAddress,
                                           string NewPh_num, string NewCard_num, int NewSecurity_code)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_JustUpdatePayment_info", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingPaymentID", ExistingPaymentID);
                command.Parameters.AddWithValue("@NewUserID", NewUserID);
                command.Parameters.AddWithValue("@NewName", NewName);
                command.Parameters.AddWithValue("@NewAddress", NewAddress);
                command.Parameters.AddWithValue("@NewPh_num", NewPh_num);
                command.Parameters.AddWithValue("@NewCard_num", NewCard_num);
                command.Parameters.AddWithValue("@NewSecurity_code", NewSecurity_code);
                command.Parameters["@ExistingPaymentID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void SafeUpdateExistingPayment(int ExistingPaymentID, int NewUserID, string NewName, string NewAddress,
                                           string NewPh_num, string NewCard_num, int NewSecurity_code, int OldUserID,
                                           string OldName, string OldAddress, string OldPh_num, string OldCard_num,
                                           int OldSecurity_code)
        {
            
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_SafeUpdatePayment_info", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingPaymentID", ExistingPaymentID);
                command.Parameters.AddWithValue("@NewUserID", NewUserID);
                command.Parameters.AddWithValue("@NewName", NewName);
                command.Parameters.AddWithValue("@NewAddress", NewAddress);
                command.Parameters.AddWithValue("@NewPh_num", NewPh_num);
                command.Parameters.AddWithValue("@NewCard_num", NewCard_num);
                command.Parameters.AddWithValue("@NewSecurity_code", NewSecurity_code);
                command.Parameters.AddWithValue("@OldUserID", OldUserID);
                command.Parameters.AddWithValue("@OldName", OldName);
                command.Parameters.AddWithValue("@OldAddress", OldAddress);
                command.Parameters.AddWithValue("@OldPh_num", OldPh_num);
                command.Parameters.AddWithValue("@OldCard_num", OldCard_num);
                command.Parameters.AddWithValue("@OldSecurity_code", OldSecurity_code);
                command.Parameters["@ExistingPaymentID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }            
        }
        public void JustUpdateExistingRole(int ExistingRoleID, string NewRole, string NewPrivileges)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_JustUpdateRoles", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingRoleID", ExistingRoleID);                
                command.Parameters.AddWithValue("@NewRole", NewRole);
                command.Parameters.AddWithValue("@NewPrivileges", NewPrivileges);
                command.Parameters["@ExistingRoleID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void SafeUpdateExistingRole(int ExistingRoleID, string NewRole, string NewPrivilege,
                                          string OldRole, string OldPrivilege)
        {
            
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_SafeUpdateRoles", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingRoleID", ExistingRoleID);
                command.Parameters.AddWithValue("@NewRole", NewRole);
                command.Parameters.AddWithValue("@NewPrivilege", NewPrivilege);
                command.Parameters.AddWithValue("@OldRole", OldRole);
                command.Parameters.AddWithValue("@OldPrivilege", OldPrivilege);
                command.Parameters["@ExistingRoleID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }                
            }
        }
        public void JustUpdateExistingUpdate(int ExistingUpdateID, decimal NewPatch, string NewExpansion, string NewAdd_Ons, int NewGameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_JustUpdateUpdates", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingUpdateID", ExistingUpdateID);
                command.Parameters.AddWithValue("@NewPatch", NewPatch);
                command.Parameters.AddWithValue("@NewExpansion", NewExpansion);
                command.Parameters.AddWithValue("@NewAdd_Ons", NewAdd_Ons);
                command.Parameters.AddWithValue("@NewGameID", NewGameID);
                command.Parameters["@ExistingUpdateID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void SafeUpdateExistingUpdate(int ExistingUpdateID, decimal NewPatch, string NewExpansion, 
            string NewAdd_Ons, int NewGameID, decimal OldPatch, string OldExpansion, string OldAdd_Ons, int OldGameID)
        {
            
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_SafeUpdateUpdates", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingUpdateID", ExistingUpdateID);
                command.Parameters.AddWithValue("@NewPatch", NewPatch);
                command.Parameters.AddWithValue("@NewExpansion", NewExpansion);
                command.Parameters.AddWithValue("@NewAdd_Ons", NewAdd_Ons);
                command.Parameters.AddWithValue("@NewGameID", NewGameID);                
                command.Parameters.AddWithValue("@OldPatch", OldPatch);
                command.Parameters.AddWithValue("@OldExpansion", OldExpansion);
                command.Parameters.AddWithValue("@OldAdd_Ons", OldAdd_Ons);
                command.Parameters.AddWithValue("@OldGameID", OldGameID);
                command.Parameters["@ExistingUpdateID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }                
            }
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }            
        }
        public void JustUpdateExistingUser(int ExistingUserID, string NewName, string NewEmail, string NewUsername,
                                      string NewPassword, string NewNews_sub, int NewRoleID, string NewSalt,
                                      string NewHash)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_JustUpdateUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingUserID", ExistingUserID);
                command.Parameters.AddWithValue("@NewName", NewName);
                command.Parameters.AddWithValue("@NewEmail", NewEmail);
                command.Parameters.AddWithValue("@NewUsername", NewUsername);
                command.Parameters.AddWithValue("@NewPassword", NewPassword);                
                command.Parameters.AddWithValue("@NewNews_sub", NewNews_sub);
                command.Parameters.AddWithValue("@NewRoleID", NewRoleID);
                command.Parameters.AddWithValue("@NewSalt", NewSalt);
                command.Parameters.AddWithValue("@NewHash", NewHash);
                command.Parameters["@ExistingUserID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }                
            }
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void SafeUpdateExistingUser(int ExistingUserID, string NewName, string NewEmail, string NewUsername,
                                      string NewPassword, string NewNews_sub, int NewRoleID, string NewSalt,
                                      string NewHash, string OldName, string OldEmail, string OldUsername,
                                      string OldPassword, string OldNews_sub, int OldRoleID, string OldSalt,
                                      string OldHash)
        {
            
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_SafeUpdateUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExistingUserID", ExistingUserID);
                command.Parameters.AddWithValue("@NewName", NewName);
                command.Parameters.AddWithValue("@NewEmail", NewEmail);
                command.Parameters.AddWithValue("@NewUsername", NewUsername);
                command.Parameters.AddWithValue("@NewPassword", NewPassword);
                command.Parameters.AddWithValue("@NewNews_sub", NewNews_sub);
                command.Parameters.AddWithValue("@NewRoleID", NewRoleID);
                command.Parameters.AddWithValue("@NewSalt", NewSalt);
                command.Parameters.AddWithValue("@NewHash", NewHash);
                command.Parameters.AddWithValue("@OldName", OldName);
                command.Parameters.AddWithValue("@OldEmail", OldEmail);
                command.Parameters.AddWithValue("@OldUsername", OldUsername);
                command.Parameters.AddWithValue("@OldPassword", OldPassword);
                command.Parameters.AddWithValue("@OldNews_sub", OldNews_sub);
                command.Parameters.AddWithValue("@OldRoleID", OldRoleID);
                command.Parameters.AddWithValue("@OldSalt", OldSalt);
                command.Parameters.AddWithValue("@OldHash", OldHash);
                command.Parameters["@ExistingUserID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            
        }
        #endregion Update
        #region Read All
        public List<UsersDAL> ReadAllUsers(int skip=0, int take=100)
        {
            EnsureConnected();
            List<UsersDAL> rv = new List<UsersDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllUsers", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skip", skip);
                cmd.Parameters.AddWithValue("@take", take);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        UsersDAL users = Mapper.UsersDALFromReader(r);
                        rv.Add(users);
                    }
                }
            }
            return rv;
        }
        public List<UpdatesDAL> ReadAllUpdates(int skip=0, int take=100)
        {
            EnsureConnected();
            List<UpdatesDAL> rv = new List<UpdatesDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllUpdates", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skip", skip);
                cmd.Parameters.AddWithValue("@take", take);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        UpdatesDAL updates = Mapper.UpdatesDALFromReader(r);
                        rv.Add(updates);
                    }
                }
            }
            return rv;
        }
        public List<RolesDAL> ReadAllRoles(int skip=0, int take=100)
        {
            EnsureConnected();
            List<RolesDAL> rv = new List<RolesDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllRoles", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skip", skip);
                cmd.Parameters.AddWithValue("@take", take);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        RolesDAL roles = Mapper.RolesDALFromReader(r);
                        rv.Add(roles);
                    }
                }
            }
            return rv;
        }
        public List<PaymentsDAL> ReadAllPayments(int skip=0, int take=100)
        {
            EnsureConnected();
            List<PaymentsDAL> rv = new List<PaymentsDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllPayment_info", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skip", skip);
                cmd.Parameters.AddWithValue("@take", take);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        PaymentsDAL payments = Mapper.PaymentsDALFromReader(r);
                        rv.Add(payments);
                    }
                }
            }
            return rv;
        }
        public List<OrdersDAL> ReadAllOrders(int skip=0, int take=100)
        {
            EnsureConnected();
            List<OrdersDAL> rv = new List<OrdersDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllOrders", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skip", skip);
                cmd.Parameters.AddWithValue("@take", take);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        OrdersDAL orders = Mapper.OrdersDALFromReader(r);
                        rv.Add(orders);
                    }
                }
            }
            return rv;
        }
        public List<GamesDAL> ReadAllGames(int skip=0, int take=100)
        {
            EnsureConnected();
            List<GamesDAL> rv = new List<GamesDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllGames", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@skip", skip);
                cmd.Parameters.AddWithValue("@take", take);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        GamesDAL games = Mapper.GamesDALFromReader(r);
                        rv.Add(games);
                    }
                }
            }
            return rv;
        }
        #endregion Read All
        #region Read Specific
        public UsersDAL ReadSpecificUser(int userID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_ReadSpecificUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Mapper.UsersDALFromReader(reader);
                    }
                    else return null;
                }
            }
        }

        public UsersDAL ReadSpecificUserByUsername(string userName)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_ReadSpecificUserByUsername", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", userName);
                using (SqlDataReader reader = command.ExecuteReader())
                {                    
                    if (reader.Read())
                    {
                        return Mapper.UsersDALFromReader(reader);
                    }
                    else return null;
                }                    
            }
        }

        public UpdatesDAL ReadSpecificUpdate(int updateID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_ReadSpecificUpdate", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UpdateID", updateID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Mapper.UpdatesDALFromReader(reader);
                    }
                    else return null;
                }
            }
        }
        public RolesDAL ReadSpecificRole(int roleID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_ReadSpecificRole", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", roleID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Mapper.RolesDALFromReader(reader);
                    }
                    else return null;
                }
            } 
        }
        public PaymentsDAL ReadSpecificPayment(int PaymentID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_ReadSpecificPayment_info", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Mapper.PaymentsDALFromReader(reader);
                    }
                    else return null;
                }
            }
        }
        public OrdersDAL ReadSpecificOrder(int order_num)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_ReadSpecificOrder", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Order_Num", order_num);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Mapper.OrdersDALFromReader(reader);
                    }
                    else return null;
                }
            }
        }
        public GamesDAL ReadSpecificGame(int gameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_ReadSpecificGame", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GameID", gameID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Mapper.GamesDALFromReader(reader);
                    }
                    else return null;
                }
            }
        }
        #endregion Read Specific
        #region Delete
        public void DeleteExistingGame(int ExistingGameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_DeleteGames", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GameID", ExistingGameID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void DeleteExistingOrder(int ExistingOrderID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_DeleteOrders", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Order_Num", ExistingOrderID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void DeleteExistingPayment(int ExistingPaymentID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_DeletePayment_info", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PaymentID", ExistingPaymentID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void DeleteExistingRole(int ExistingRoleID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_DeleteRoles", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", ExistingRoleID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void DeleteExistingUpdate(int ExistingUpdateID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_DeleteUpdates", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UpdateID", ExistingUpdateID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        public void DeleteExistingUser(int ExistingUserID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_DeleteUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", ExistingUserID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) when (Logger.Log(ex))
                {
                    
                }
            }
        }
        #endregion Delete
    }
}
