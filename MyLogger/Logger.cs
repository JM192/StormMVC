namespace MyLogger
{

    using System;    
    using System.Data.SqlClient;
    using System.Web;

    static public class Logger
    {
        // the connection string is only loaded one time, at the start of the application
        static string connectionstring;
        // this is a static constructor. It is used to initialize the static connectionstring
        static Logger()
        {
            connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        }
        // this method is static so that it will have semantics like Console.WriteLine
        public static bool Log(Exception ex)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (var com = con.CreateCommand())
                    {
                        com.CommandText = "Sp_InsertLogItem";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Message", ex.Message);
                        com.Parameters.AddWithValue("@Trace", ex.StackTrace.ToString());
                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
              var p = HttpContext.Current.Server.MapPath("~");
              p += @"ErrorLog.Log";
              System.IO.File.AppendAllText(p, "While attempting to record the original exception to the database, this exception occured\r\n");
              System.IO.File.AppendAllText(p, exc.ToString());
              System.IO.File.AppendAllText(p, "This is the original exception that was attempting to be written to the database\r\n");
              System.IO.File.AppendAllText(p, ex.ToString());                
            }
            return false;
        }
    }
}
