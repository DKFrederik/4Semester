using System;
using System.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class DBAccess
    {
        public static string connectionString = @"server=NICHLAS-PC\SQLEXPRESS;" +
                                      "Trusted_Connection=True;" +
                                      "MultipleActiveResultSets=True;" +
                                      "database=bsi; " +
                                      "connection timeout=10";

        //public static string connectionString = @"server=nukesite.dk;" +
        //                              "Trusted_Connection=false;" +
        //                              "MultipleActiveResultSets=True;" +
        //                              "database=MarinaBooking;" +
        //                              "User id=projekt;" +
        //                              "Password=35120oe102fK;" +
        //                              "connection timeout=10";

        //public static string connectionString = @"server=FREDERIK-LAPTOP\SQLEXPRESS;" +
        //                               "Trusted_Connection=True;" +
        //                               "MultipleActiveResultSets=True;" +
        //                               "database=MarinaBooking; " +
        //                               "connection timeout=10";

        //public static string connectionString = @"server=CLAUS-PC\SQLEXPRESS;" +
        //                               "Trusted_Connection=True;" +
        //                               "MultipleActiveResultSets=True;" +
        //                               "database=MarinaBooking; " +
        //                               "connection timeout=10";

        //public static string connectionString = @"server=ASUS\SQLEXPRESS;" +
        //                               "Trusted_Connection=True;" +
        //                               "MultipleActiveResultSets=True;" +
        //                               "database=bsi; " +
        //                               "connection timeout=10";

        private SqlConnection dbconn;

        public DBAccess()
        {
            dbconn = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <returns>Returns success if connection was open, else it throws an exception.</returns>
        public Boolean Open()
        {
            Boolean success;
            try
            {
                dbconn.Open();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                Console.WriteLine("There was a connection error: " + ex);
            }
            return success;
        }

        /// <summary>
        /// Closes a database connection.
        /// </summary>
        /// <returns>Returns success if connection was closed, else it throws an exception.</returns>
        public Boolean Close()
        {
            Boolean success;
            try
            {
                dbconn.Close();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                Console.WriteLine("The connection did not close proberly: " + ex);
            }
            return success;
        }

        /// <summary>
        /// Creates a new SqlCommand object. If the the connection is not open, the method opens a new connection.
        /// </summary>
        /// <param name="sql">A sql string</param>
        /// <returns>Returns a SqlCommand</returns>
        public SqlCommand GetDbCommand(string sql)
        {
            SqlCommand dbCmd = null;
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                Open();
            if (dbCmd == null)
            {
                dbCmd = new SqlCommand(sql, dbconn);
            }
            dbCmd.CommandText = sql;
            return dbCmd;
        }

        /// <summary>
        /// Begins a new transaction
        /// </summary>
        /// <param name="iso">IsolationLevel</param>
        /// <returns>Returns a transaction</returns>
        public SqlTransaction BeginTransaction(IsolationLevel iso)
        {
            try
            {
                return dbconn.BeginTransaction(iso);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex);
                return null;
            }
        }
    }
}