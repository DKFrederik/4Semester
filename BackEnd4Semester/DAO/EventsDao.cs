﻿using System;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAO
{
    public class EventsDao
    {
        private DBAccess dba;
        private ContentInfoDAO ctDao;

        public EventsDao()
        {
            this.dba = new DBAccess();
            ctDao = new ContentInfoDAO();
        }

        public int CreateEvent(Events events)
        {
            int rc = -1;    //Rowcount indicating whether or not a table was affected (nr. of rows affected)
            int ctId = -1;  //The ID returned from grandparrent ContentInfo.

            ContentInfoDAO ctDao = new ContentInfoDAO();

            string sql = "event_insert";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", events.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@creatorId", events.Author.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@date", events.Date).SqlDbType = SqlDbType.Date;
                    cmd.Parameters.AddWithValue("@content", events.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", events.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@contentType", events.ContentType).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@starttime", events.StartTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@endtime", events.EndTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@eventType", events.EventType).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            if (rc > 0)
            {
                return ctId;
            }
            else {
                return -1;
            }
        }

        public string buildEventQuery()
        {
            return (ctDao.buildContentQuery() + ", e.startTime, e.endTime");
        }

        public Events buildPartialObject(SqlDataReader sdr, Events obj)
        {
            obj = (Events)ctDao.buildPartialObject(sdr, obj);
            obj.StartTime= sdr.GetDateTime("startTime");
            obj.EndTime = sdr.GetDateTime("endTime");
            return obj;
        }
        public Events FindEvents(string title)
        {
            Events foundEvent = null;

            string sql = "SELECT * From EventView WHERE title=@title";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@title", title).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString("eventType").Equals("match"))
                            {
                                foundEvent = new Match(){
                                    Opponent = reader.GetString("opponent"),
                                    HomeGoal = reader.GetInt32("homegoals"),
                                    AwayGoal = reader.GetInt32("awaygoals")
                                };
                            }
                            else if(reader.GetString("eventType").Equals("trainingSession"))
                            {
                                foundEvent = new TrainingSession(){
                                    Trainer = reader.GetString("trainer")
                                };
                            }
 
                            foundEvent.Title = reader.GetString("title");
                            foundEvent.Author = null; //TODO reference
                            foundEvent.Date = reader.GetDateTime("date");
                            foundEvent.Content = reader.GetString("content");
                            foundEvent.IsPublic = reader.GetBoolean("isPublic");
                            foundEvent.StartTime = reader.GetDateTime("startTime");
                            foundEvent.EndTime = reader.GetDateTime("endTime");
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return foundEvent;
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

