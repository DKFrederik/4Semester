using System;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAO
{
    public class UserDAO
    {
        private DBAccess dba;

        public UserDAO()
        {
            this.dba = new DBAccess();
        }

        public int CreateUser(string username, string password, string firstname, string lastname, string email, int admPri, string type)
        {
            int res = -1;

            string sql = "user_insert";
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

                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return res;
        }

        public User FindUser(string email)
        {
            User foundUser = null;

            string sql = "SELECT * FROM Users WHERE email=@email";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@email", email).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundUser = BuildUser(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return foundUser;
        }

        public User FindUser(int id)
        {
            User foundUser = null;

            string sql = "SELECT * FROM Users WHERE id=@id";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", id).SqlDbType = SqlDbType.Int;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundUser = BuildUser(reader);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }
            return foundUser;
        }

        public int UpdateUser(User user, string oldFirstname, string oldLastname)
        {
            int rc = -1;
            string sql = "user_update";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", user.UserName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@password", user.Password).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@firstname", user.FirstName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@lastname", user.LastName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@email", user.Email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@type", user.Type).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@adminPrivilege", user.AdminPrivilege).SqlDbType = SqlDbType.VarChar;
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

        public int DeleteUser(string email)
        {
            int rc = -1;
            string sql = "DELETE FROM Users WHERE email=@email";

            using(SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try {
                    cmd.Parameters.AddWithValue("@email", email).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        private User BuildUser(SqlDataReader r)
        {
            User u;
            try
            {
                u = new User()
                {
                    Id = r.GetInt32("id"),
                    UserName = r.GetString("username"),
                    FirstName = r.GetString("firstname"),
                    LastName = r.GetString("lastname"),
                    Email = r.GetString("email"),
                    AdminPrivilege = r.GetInt32("adminPrivilege"),
                    Type = r.GetString("type")
                };
            }
            catch(Exception e)
            {
                throw e;
            }

            return u;
        }
    }
}
