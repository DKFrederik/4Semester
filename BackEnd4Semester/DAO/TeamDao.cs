using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAO
{
    public class TeamDao
    {
        private DBAccess dba;

        public TeamDao()
        {
            this.dba = new DBAccess();
        }

        public int CreateTeam(Team newTeam)
        {
            int rc = -1;

            string sql = "INSERT INTO team(name, type)" +
                "values(@name, @type)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", newTeam.Name).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@type", newTeam.Type).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public Team FindTeam(string name, bool retrieveAssoc)
        {
            Team foundTeam = null;

            string sql = "SELECT * FROM team WHERE name=@name";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@name", name).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundTeam = BuildTeam(reader);
                        }
                        if (foundTeam != null && retrieveAssoc)
                        {

                            foundTeam.Players = GetPlayers(foundTeam.Id);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return foundTeam;
        }

        public Team FindTeam(int id, bool retrieveAssoc)
        {
            Team foundTeam = null;

            string sql = "SELECT * FROM team WHERE id=@id";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", id).SqlDbType = SqlDbType.Int;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundTeam = BuildTeam(reader);
                        }
                        if (foundTeam != null && retrieveAssoc)
                        {

                            foundTeam.Players = GetPlayers(foundTeam.Id);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return foundTeam;
        }

        public int UpdateTeam(Team team, string oldName)
        {
            int rc = -1;
            string sql = "UPDATE team SET name=@name, type=@type" +
                "WHERE name=@oldName";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@name", team.Name).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@type", team.Type).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@oldName", oldName).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return rc;
        }

        public int DeleteTeam(string name)
        {
            int rc = -1;
            string sql = "DELETE FROM team WHERE name=@name";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@name", name).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public int AddPlayer(int playerId, int teamId)
        {
            int rc = -1;
            string sql = "INSERT INTO PlayerTeam(playerId, teamId) "
                    + "VALUES(@playerId, @teamId)";
            using(SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@playerId", playerId).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@teamId", teamId).SqlDbType = SqlDbType.Int;

                rc = cmd.ExecuteNonQuery();
            }

            return rc; 
        }

        private List<Player> GetPlayers(int teamId)
        {
            List<Player> p = new List<Player>();
            PlayerDao pDao = new PlayerDao();

            string sql = "SELECT u.id, u.adminPrivilege, u.email, u.firstname, u.lastname, u.type, u.username, "
                        + "p.number, p.gamesPlayed, p.goals, p.penalties "
                        + "FROM PlayerTeam pt "
                        + "JOIN Users u ON pt.playerId = u.id "
                        + "JOIN Player p ON pt.playerId = p.id "
                        + "WHERE pt.teamId = @teamId ";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@teamId", teamId).SqlDbType = SqlDbType.Int;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p.Add(BuildPlayer(reader));
                        }
                    }
                }
                catch(SqlException e)
                {
                    throw e;
                }
            }
                return p;
        }

        private Team BuildTeam(SqlDataReader r)
        {
            Team t = null;
            try
            {
                t = new Team()
                {
                    Id = r.GetInt32("id"),
                    Name = r.GetString("name"),
                    Type = r.GetString("type")
                };
            }
            catch(SqlException e)
            {
                throw e;
            }

            return t;
        }

        private Player BuildPlayer(SqlDataReader r)
        {
            Player p = null;
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
            catch(SqlException e)
            {
                throw e;
            }

            return p;
        }
    }
}

