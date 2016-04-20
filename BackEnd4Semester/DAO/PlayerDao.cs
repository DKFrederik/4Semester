using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace DAO
{
    public class PlayerDao
    {
        private DBAccess dba;

        public PlayerDao()
        {
            this.dba = new DBAccess();
        }

        public int CreatePlayer(string username, string password, string firstname, string lastname, string email, int admPri, string type, int number, int gamesplayed, int goals, int penalties)
        {
            int rc = -1;
            UserDAO uDao = new UserDAO();

            string sql = "INSERT INTO player(id, number, gamesPlayed, goals, penalties)" +
                "values(@id, @number, @gamesPlayed, @goals, @penalties);";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                int id = uDao.CreateUser(true, username, password, firstname, lastname, email, admPri, type);
                try {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@number", number).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@gamesPlayed", gamesplayed).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@goals", goals).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@penalties", penalties).SqlDbType = SqlDbType.TinyInt;

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
            string sql = "select p.id, p.number, p.gamesPlayed, p.goals, p.penalties, "
                + "u.adminPrivilege, u.email, u.firstname, u.lastname, u.type, u.username "
                + "FROM Player p join Users u on p.id = u.id where u.email = @email";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@email", email).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            p = new Player()
                            {
                                Id = reader.GetInt32("id"),
                                UserName = reader.GetString("username"),
                                FirstName = reader.GetString("firstname"),
                                LastName = reader.GetString("lastname"),
                                Email = reader.GetString("email"),
                                AdminPrivilege = reader.GetInt32("adminPrivilege"),
                                Number = reader.GetInt32("number"),
                                GamesPlayed = reader.GetInt32("gamesPlayed"),
                                Goals = reader.GetInt32("goals"),
                                Penalties = reader.GetInt32("penalties")
                            };
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

        public int UpdatePlayer(Player player, string oldFirstname, string oldLastname)
        {
            int rc = -1;
            string sql = "UPDATE player SET username=@username, password=@password, firstname=@firstname, lastname=@lastname, email=@email, adminPrivilege=@admindPrivilege, number=@number, gamesPlayed=@gamesPlayed, goals=@goals, penalties=@penalties " +
                "WHERE firstname=@oldFirstname AND lastname=@oldLastname";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@username", player.UserName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@password", player.Password).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@firstname", player.FirstName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@lastname", player.LastName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@email", player.Email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@adminPrivilege", player.AdminPrivilege).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@number", player.Number).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@gamesPlayed", player.GamesPlayed).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@goals", player.Goals).SqlDbType = SqlDbType.TinyInt;
                    cmd.Parameters.AddWithValue("@penalties", player.Penalties).SqlDbType = SqlDbType.TinyInt;

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
    }
}
