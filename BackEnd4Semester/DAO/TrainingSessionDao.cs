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

            int eId = eDao.CreateEvent(ts.Title, ts.Author, ts.Date, ts.Content,
                                ts.IsPublic, ts.StartTime, ts.EndTime, "trainingSession");


            string sql = "INSERT INTO trainingSession(id, trainer)" +
                "values(@eid, @trainer)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@eid", eId).SqlDbType = SqlDbType.Int;
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

            string sql = "SELECT " + eDao.buildEventQuery() + ", t.trainer FROM trainingSession t join Event e on t.id = e.id join ContentInfo c on c.id = e.id "
                + "where c.date = @date";
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

