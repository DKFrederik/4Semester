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

        public Team FindTeam(string name)
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
                            foundTeam = new Team()
                            {
                                Name = reader.GetString("name"),
                                Type = reader.GetString("type"),
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
    }
}

