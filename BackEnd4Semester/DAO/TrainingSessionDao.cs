﻿using System;
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
    public class TrainingSessionDao
    {
        private DBAccess dba;

        public TrainingSessionDao()
        {
            this.dba = new DBAccess();
        }

        public int CreateTrainingSession(TrainingSession newTrainingSession)
        {
            int rc = -1;

            string sql = "INSERT INTO trainingSession(title, author, date, content, isPublic, startTime, endTime, trainer)" +
                "values(@title, @author, @date, @content, @isPublic, @startTime, @endTime, @trainer)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@title", newTrainingSession.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@author", newTrainingSession.Author).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@date", newTrainingSession.Date).SqlDbType = SqlDbType.Date;
                    cmd.Parameters.AddWithValue("@content", newTrainingSession.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", newTrainingSession.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@starTime", newTrainingSession.StartTime).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@endTime", newTrainingSession.EndTime).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@trainer", newTrainingSession.Trainer).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public TrainingSession FindTrainingSession(string title)
        {
            TrainingSession foundTrainingSession = null;

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
                            foundTrainingSession = new TrainingSession()
                            {
                                Title = reader.GetString("title"),
                                Author = reader.GetString("author"),
                                Date = reader.GetDateTime("date"),
                                Content = reader.GetString("content"),
                                IsPublic = reader.GetBoolean("isPublic"),
                                StartTime = reader.GetDateTime("startTime"),
                                EndTime = reader.GetDateTime("endTime"),
                                Trainer = reader.GetString("trainer")            
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

            return foundTrainingSession;
        }

        public int UpdateTrainingSession(TrainingSession trainingSession, string oldTitle)
        {
            int rc = -1;
            string sql = "UPDATE trainingSession SET title=@title, author=@author, date=@date, content=@content, @isPublic=isPublic, startTime=@startTime, endTime=@endTime, trainer=@trainer" +
                "WHERE title=@oldTitle";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@title", trainingSession.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@author", trainingSession.Author).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@date", trainingSession.Date).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@content", trainingSession.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", trainingSession.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@startTime", trainingSession.StartTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@endTime", trainingSession.EndTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@trainer", trainingSession.Trainer).SqlDbType = SqlDbType.VarChar;
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

        public int DeleteTrainingSession(string title)
        {
            int rc = -1;
            string sql = "DELETE FROM trainingSession WHERE title=@title";

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

