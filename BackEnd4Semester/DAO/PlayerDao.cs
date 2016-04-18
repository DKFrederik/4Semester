using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int CreatePlayer(Player newPlayer)
        {
            int rc = -1;

            string sql = "INSERT INTO player(username, password, firstname, lastname, email, adminPrivilege, type, number, gamesPlayed, goals, penalties)" +
                "values(@username, @password, @firstname, @lastname, @email, @adminPrivilege, @type, @number, @gamesPlayed, @goals, @penalties)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", newPlayer.UserName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@password", newPlayer.Password).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@firstname", newPlayer.FirstName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@lastname", newPlayer.LastName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@email", newPlayer.Email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@adminPrivilege", newPlayer.AdminPrivilege).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@type", newPlayer.Type).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@number", newPlayer.Number).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@gamesPlayed", newPlayer.GamesPlayed).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@goals", newPlayer.Goals).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@penalties", newPlayer.Penalties).SqlDbType = SqlDbType.Int;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public User FindPlayer(string firstname, string lastname)
        {
            User foundPlayer = null;

            string sql = "SELECT * FROM player WHERE firstname=@firstname AND lastname=@lastname";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@firstname", firstname).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@lastname", lastname).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundPlayer = new Player()
                            {
                                Id = reader.GetInt32("id"),
                                UserName = reader.GetString("username"),
                                Password = reader.GetString("password"),
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

            return foundPlayer;
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
            string sql = "DELETE FROM player WHERE email=@email";

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
