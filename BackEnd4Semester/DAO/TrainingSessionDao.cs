using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAO
{
    public class TrainingSessionDao
    {
        private DBAccess dba;
        private EventsDao eDao;

        public TrainingSessionDao()
        {
            this.dba = new DBAccess();
            eDao = new EventsDao();
        }

        public Boolean CreateTrainingSession(TrainingSession ts)
        {
            bool success = false;
            EventsDao eDao = new EventsDao();

            string sql = "trainingsession_insert";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", ts.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@creatorId", ts.Author.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@date", ts.Date).SqlDbType = SqlDbType.Date;
                    cmd.Parameters.AddWithValue("@content", ts.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", ts.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@contentType", ts.ContentType).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@starttime", ts.StartTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@endtime", ts.EndTime).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@eventType", ts.EventType).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@trainer", ts.Trainer).SqlDbType = SqlDbType.VarChar;

                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return success;
        }

        public List<TrainingSession> FindTrainingSessions(DateTime date)
        {
            List<TrainingSession> tList = new List<TrainingSession>();

            string sql = "SELECT * from TrainingSessionView where date = @date";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@date", date).SqlDbType = SqlDbType.DateTime;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            TrainingSession t = new TrainingSession();
                            t = (TrainingSession) eDao.buildPartialObject(reader, t);
                            t.Trainer = reader.GetString("trainer");

                            tList.Add(t);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return tList;
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

