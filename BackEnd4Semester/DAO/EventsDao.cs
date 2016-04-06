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
    public class EventsDao
    {
        private DBAccess dba;

        public EventsDao()
        {
            this.dba = new DBAccess();
        }

        public int CreateEvent(Events newEvent)
        {
            int rc = -1;

            string sql = "INSERT INTO events(title, author, date, content, isPublic, startTime, endTime)" +
                "values(@title, @author, @date, @content, @isPublic, @startTime, @endTime)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@title", newEvent.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@author", newEvent.Author).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@date", newEvent.Date).SqlDbType = SqlDbType.Date;
                    cmd.Parameters.AddWithValue("@content", newEvent.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", newEvent.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@starTime", newEvent.StartTime).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@endTime", newEvent.EndTime).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public Events FindEvent(string title)
        {
            Events foundEvents = null;

            string sql = "SELECT * FROM events WHERE title=@title";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@title", title).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundEvents = new Events()
                            {
                                Title = reader.GetString("title"),
                                Author = reader.GetString("author"),
                                Date = reader.GetDateTime("date"),
                                Content = reader.GetString("content"),
                                IsPublic = reader.GetBoolean("isPublic"),
                                StartTime = reader.GetDateTime("startTime"),
                                EndTime = reader.GetDateTime("endTime")
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

            return foundEvents;
        }

        public int UpdateEvent(Events events, string oldTitle)
        {
            int rc = -1;
            string sql = "UPDATE events SET title=@title, author=@author, date=@date, content=@content, @isPublic=isPublic, startTime=@startTime, endTime=@endTime" +
                "WHERE title=@oldTitle";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@title", events.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@author", events.Author).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@date", events.Date).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@content", events.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", events.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@startTime", events.StartTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@endTime", events.EndTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@oldTitle", oldTitle).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return rc;
        }

        public int DeleteEvent(string title)
        {
            int rc = -1;
            string sql = "DELETE FROM events WHERE title=@title";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@title", title).SqlDbType = SqlDbType.VarChar;

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

