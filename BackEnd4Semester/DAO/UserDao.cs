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
    public class UserDAO
    {
        private DBAccess dba;

        public UserDAO()
        {
            this.dba = new DBAccess();
        }

        public int CreateUser(User newUser)
        {
            int rc = -1;

            string sql = "INSERT INTO users(username, password, firstname, lastname, email, type, adminPrivilege)" +
                " values(@username, @password, @firstname, @lastname, @email, @type, @adminPrivilege)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", newUser.UserName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@password", newUser.Password).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@firstname", newUser.FirstName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@lastname", newUser.LastName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@email", newUser.Email).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@type", newUser.Type).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@adminPrivilege", newUser.AdminPrivilege).SqlDbType = SqlDbType.Int;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public User FindUser(string firstname, string lastname)
        {
            User foundUser = null;

            string sql = "SELECT * FROM Users WHERE firstname=@firstname AND lastname=@lastname";
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
                            foundUser = new User()
                            {
                                Id = reader.GetInt32("id"),
                                UserName = reader.GetString("username"),
                                Password = reader.GetString("password"),
                                FirstName = reader.GetString("firstname"),
                                LastName = reader.GetString("lastname"),
                                Email = reader.GetString("email"),
                                AdminPrivilege = reader.GetInt32("adminPrivilege"),
                                Type = reader.GetString("type")
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

            return foundUser;
        }

        public int UpdateUser(User user, string oldFirstname, string oldLastname)
        {
            int rc = -1;
            string sql = "UPDATE user SET username=@username, password=@password, firstname=@firstname, lastname=@lastname, email=@email, adminPrivilege=@admindPrivilege " +
                "WHERE firstname=@oldFirstname AND lastname=@oldLastname";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@username", user.UserName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@password", user.Password).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@firstname", user.FirstName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@lastname", user.LastName).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@email", user.Email).SqlDbType = SqlDbType.VarChar;
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
    }
}
