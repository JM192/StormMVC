namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// AUTHOR: John McGillis
    /// COMPANY: Onshore Outsourcing
    /// DESCRIPTION: Data Access DAL Context Class
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
            GamesDAL rv = new GamesDAL();
            rv.GameID = r.GetInt32(0);
            rv.Game_Title = r.GetString(1);
            rv.Release_Date = r.GetDateTime(2).ToString();
            rv.Purchase_Price = r.GetDecimal(3);
            return rv;
        }
        public static OrdersDAL OrdersDALFromReader(SqlDataReader r)
        {
            OrdersDAL rv = new OrdersDAL();
            rv.Order_Num = r.GetInt32(0);
            rv.Order_Name = r.GetString(1);
            rv.Purchase_Date = r.GetDateTime(2).ToString();
            rv.UserID = r.GetInt32(3);
            rv.GameID = r.GetInt32(4);
            return rv;
        }
        public static RolesDAL RolesDALFromReader(SqlDataReader r)
        {
            RolesDAL rv = new RolesDAL();
            rv.RoleID = r.GetInt32(0);
            rv.Name = r.GetString(1);
            rv.Role_Type = r.GetString(2);
            rv.Privilege = r.GetString(3);
            return rv;
        }
        public static UpdatesDAL UpdatesDALFromReader(SqlDataReader r)
        {
            UpdatesDAL rv = new UpdatesDAL();
            rv.UpdateID = r.GetInt32(0);
            rv.Patch = r.GetInt32(1);
            rv.Expansion = r.GetString(2);
            rv.Add_Ons = r.GetString(3);
            rv.GameID = r.GetInt32(4);
            return rv;
        }
        public static UsersDAL UsersDALFromReader(SqlDataReader r)
        {
            UsersDAL rv = new UsersDAL();
            rv.UserID = r.GetInt32(0);
            rv.F_name = r.GetString(1);
            rv.L_name = r.GetString(2);
            rv.Address = r.GetString(3);
            rv.Ph_num = r.GetString(4);
            rv.Email = r.GetString(5);
            rv.Username = r.GetString(6);
            rv.Password = r.GetString(7);            
            rv.News_sub = r.GetString(9);
            rv.RoleID = r.GetInt32(10);
            return rv;
        }
    }
    /*Implementation of IDisposable to Help other Potential Programmers With Garbage Collection and Prevent "Sloppy Programming"
     From Making the Mistake of not Properly Disposing the Following Connection Strings */
    public class DALContext : IDisposable
    {
        private System.Data.SqlClient.SqlConnection _connection = new SqlConnection();
        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
        private void EnsureConnected()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DataAccessLayer CRUD Methods
        public void InsertNewGame(int GameID, string Game_Title, string Release_Date, decimal Purchase_Price)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertGames", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GameID", GameID);
                command.Parameters.AddWithValue("@Game_Title", Game_Title);
                command.Parameters.AddWithValue("@Release_Date", Release_Date);
                command.Parameters.AddWithValue("@Purchase_Price", Purchase_Price);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void InsertNewOrder(int Order_Num, string Order_Name, string Purchase_Date, int UserID, int GameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertOrders", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Order_Num", Order_Num);
                command.Parameters.AddWithValue("@Order_Name", Order_Name);
                command.Parameters.AddWithValue("@Purchase_Date", Purchase_Date);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@GameID", GameID);
                command.Parameters["@Order_Num"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
                
        }
        public void InsertNewRole(int RoleID, string Name, string Role_Type, string Privilege)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertRoles", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Role_Type", Role_Type);
                command.Parameters.AddWithValue("@Privilege", Privilege);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void InsertNewUpdate(int UpdatesID, decimal Patch, string Expansion, string Add_Ons, int GameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertUpdates", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UpdatesID", UpdatesID);
                command.Parameters.AddWithValue("@Patch", Patch);
                command.Parameters.AddWithValue("@Expansion", Expansion);
                command.Parameters.AddWithValue("@Add_Ons", Add_Ons);
                command.Parameters.AddWithValue("@GameID", GameID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public int InsertNewUser(int UserID, string F_name, string L_name, string Address, string Ph_num, string Email, string Username,
            string Password, string News_sub, int RoleID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_InsertUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@F_name", F_name);
                command.Parameters.AddWithValue("@L_name", L_name);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Ph_num", Ph_num);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);                
                command.Parameters.AddWithValue("@News_sub", News_sub);
                command.Parameters.AddWithValue("@RoleID", RoleID);
                command.Parameters["@UserID"].Direction = ParameterDirection.InputOutput;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Convert.ToInt32(command.Parameters["@UserID"].Value);
            }
        }
        public void UpdateExistingGame(int GameID, string Game_Title, string Release_Date, decimal Purchase_Price)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_UpdateGames", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GameID", GameID);
                command.Parameters.AddWithValue("@Game_Title", Game_Title);
                command.Parameters.AddWithValue("@Release_Date", Release_Date);
                command.Parameters.AddWithValue("@Purchase_Price", Purchase_Price);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void UpdateExistingOrder(int Order_Num, string Order_Name, string Purchase_Date, int UserID, int GameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_UpdateOrders", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Order_Num", Order_Num);
                command.Parameters.AddWithValue("@Order_Name", Order_Name);
                command.Parameters.AddWithValue("@Purchase_Date", Purchase_Date);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@GameID", GameID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public void UpdateExistingRole(int ExistingRoleID, string NewName, string NewRole_Type, string NewPrivilege)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_UpdateRoles", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleID", ExistingRoleID);
                command.Parameters.AddWithValue("@Name", NewName);
                command.Parameters.AddWithValue("@Role_Type", NewRole_Type);
                command.Parameters.AddWithValue("@Privilege", NewPrivilege);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void UpdateExistingUpdate(int ExistingUpdateID, decimal NewPatch, string NewExpansion, string NewAdd_Ons, int NewGameID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_UpdateUpdates", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UpdateID", ExistingUpdateID);
                command.Parameters.AddWithValue("@Patch", NewPatch);
                command.Parameters.AddWithValue("@Expansion", NewExpansion);
                command.Parameters.AddWithValue("@Add_Ons", NewAdd_Ons);
                command.Parameters.AddWithValue("@GameID", NewGameID);
                
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void UpdateExistingUser(int ExistingUserID, string NewF_name, string NewL_name, string 
            NewAddress, string NewPh_num, string NewEmail, string NewUsername,
            string NewPassword, string NewNews_sub, int NewRoleID)
        {
            EnsureConnected();
            using (SqlCommand command = new SqlCommand("Sp_UpdateUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", ExistingUserID);
                command.Parameters.AddWithValue("@F_name", NewF_name);
                command.Parameters.AddWithValue("@L_name", NewL_name);
                command.Parameters.AddWithValue("@Address", NewAddress);
                command.Parameters.AddWithValue("@Ph_num", NewPh_num);
                command.Parameters.AddWithValue("@Email", NewEmail);
                command.Parameters.AddWithValue("@Username", NewUsername);
                command.Parameters.AddWithValue("@Password", NewPassword);                
                command.Parameters.AddWithValue("@News_sub", NewNews_sub);
                command.Parameters.AddWithValue("@RoleID", NewRoleID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<UsersDAL> ReadAllUsers()
        {
            EnsureConnected();
            List<UsersDAL> rv = new List<UsersDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllUsers", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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
        public List<UpdatesDAL> ReadAllUpdates()
        {
            EnsureConnected();
            List<UpdatesDAL> rv = new List<UpdatesDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllUpdates", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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
        public List<RolesDAL> ReadAllRoles()
        {
            EnsureConnected();
            List<RolesDAL> rv = new List<RolesDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllRoles", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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
        public List<OrdersDAL> ReadAllOrders()
        {
            EnsureConnected();
            List<OrdersDAL> rv = new List<OrdersDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllOrders", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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
        public List<GamesDAL> ReadAllGames()
        {
            EnsureConnected();
            List<GamesDAL> rv = new List<GamesDAL>();
            using (SqlCommand cmd = new SqlCommand("Sp_ReadAllGames", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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
                catch (Exception ex)
                {
                    throw ex;
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
                catch (Exception ex)
                {
                    throw ex;
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
                catch (Exception ex)
                {
                    throw ex;
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
                catch (Exception ex)
                {
                    throw ex;
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
