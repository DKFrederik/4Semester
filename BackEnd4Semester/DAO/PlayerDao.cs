using System;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class PlayerDao
    {
        private DBAccess dba;

        public PlayerDao()
        {
            this.dba = new DBAccess();
        }

        public int CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri,
           string type, int number, int gamesplayed, int goals, int penalties)
        {
            int rc = -1;
            string sql = "player_insert";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@number", number).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@gamesPlayed", gamesplayed).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@goals", goals).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@penalties", penalties).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@username", username).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@firstname", firstname).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@lastname", lastname).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@email", email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@type", type).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@adminPrivilege", admPri).SqlDbType = SqlDbType.Int;
                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public Player FindPlayer(string email)
        {
            Player p = null;
            string sql = "SELECT * FROM PlayerView WHERE email=@email";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@email", email).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            p = BuildPlayer(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return p;
        }
        /*
         * !!!TODO: Type isnt being updated. I do not know if it ought to be updated.
         */
        public int UpdatePlayer(string username, string password, string firstname, string lastname, string email, string type, int admPri,
            int number, int gamesplayed, int goals, int penalties, string oldFirstname, string oldLastname)
        {
            int rc = -1;
            string sql = "player_update";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@firstname", firstname).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@lastname", lastname).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@email", email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@type", type).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@adminPrivilege", admPri).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@number", number).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@gamesPlayed", gamesplayed).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@goals", goals).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@penalties", penalties).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@oldFirstname", oldFirstname).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@oldLastname", oldLastname).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return rc;
        }

        public int DeletePlayer(string email)
        {
            int rc = -1;
            string sql = "DELETE FROM Users WHERE email = @email";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@email", email).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        private Player BuildPlayer(SqlDataReader r)
        {
            Player p;

            try
            {
                p = new Player()
                {
                    Id = r.GetInt32("id"),
                    UserName = r.GetString("username"),
                    FirstName = r.GetString("firstname"),
                    LastName = r.GetString("lastname"),
                    Email = r.GetString("email"),
                    AdminPrivilege = r.GetInt32("adminPrivilege"),
                    Number = r.GetInt32("number"),
                    GamesPlayed = r.GetInt32("gamesPlayed"),
                    Goals = r.GetInt32("goals"),
                    Penalties = r.GetInt32("penalties")
                };
            }
            catch (SqlException e)
            {
                throw e;
            }

            return p;
        }
    }
}
