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
    public class MatchDao
    {
        private DBAccess dba;

        public MatchDao()
        {
            this.dba = new DBAccess();
        }

        public int CreateMatch(Match m)
        {
            int rc = -1;

            EventsDao eDao = new EventsDao();

            int eId = eDao.CreateEvent(m.Title, m.Author, m.Date, m.Content,
                                m.IsPublic, m.StartTime, m.EndTime, "match");

            string sql = "INSERT INTO match(id, teamid, opponent, homegoals, awaygoals)" +
                "values(@id, (select id FROM Team where name = @teamname), @opponent, @homegoals, @awaygoals)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", eId).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@teamname", m.Team.Name).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@opponent", m.Opponent).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@homegoals", m.HomeGoal).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@awaygoals", m.AwayGoal).SqlDbType = SqlDbType.Int;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public List<Match> FindMatches(DateTime date)
        {
            UserDAO uDao = new UserDAO();
            TeamDao tDao = new TeamDao();
            List<Match> matches = new List<Match>();

            string sql = "SELECT c.title, c.creatorId, c.date, c.content, c.IsPublic, e.startTime, e.endTime, m.opponent, m.homegoals, m.awaygoals, m.teamId FROM match m join Event e on m.id = e.id join ContentInfo c on c.id = e.id "
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
                            Match m = new Match(){
                                Title = reader.GetString("title"),
                                Author = uDao.FindUser(reader.GetInt32("creatorId")),
                                Date = reader.GetDateTime("date"),
                                Content = reader.GetString("content"),
                                IsPublic = reader.GetBoolean("isPublic"),
                                StartTime = reader.GetDateTime("startTime"),
                                EndTime = reader.GetDateTime("endTime"),
                                Opponent = reader.GetString("opponent"),
                                HomeGoal = reader.GetInt32("homegoals"),
                                AwayGoal = reader.GetInt32("awaygoals"),
                                Team = tDao.FindTeam(reader.GetInt32("teamId"), false)
                            };
                            
                            matches.Add(m);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return matches;
        }

        public Match FindMatch(int id)
        {
            UserDAO uDao = new UserDAO();
            TeamDao tDao = new TeamDao();

            Match m = null;

            string sql = "SELECT c.title, c.creatorId, c.date, c.content, c.IsPublic, e.startTime, e.endTime, m.opponent, m.homegoals, m.awaygoals, m.teamId FROM match m join Event e on m.id = e.id join ContentInfo c on c.id = e.id "
                + "where c.id = @id";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", id).SqlDbType = SqlDbType.DateTime;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            m = new Match()
                            {
                                Title = reader.GetString("title"),
                                Author = uDao.FindUser(reader.GetInt32("creatorId")),
                                Date = reader.GetDateTime("date"),
                                Content = reader.GetString("content"),
                                IsPublic = reader.GetBoolean("isPublic"),
                                StartTime = reader.GetDateTime("startTime"),
                                EndTime = reader.GetDateTime("endTime"),
                                Opponent = reader.GetString("opponent"),
                                HomeGoal = reader.GetInt32("homegoals"),
                                AwayGoal = reader.GetInt32("awaygoals"),
                                Team = tDao.FindTeam(reader.GetInt32("teamId"), false)
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

            return m;
        }

        public int UpdateMatch(Match match, string oldTitle)
        {
            int rc = -1;
            string sql = "UPDATE match SET title=@title, author=@author, date=@date, content=@content, @isPublic=isPublic, startTime=@starTime, endTime=@endTime, opponent=@opponent, matchScore=@matchScore" +
                "WHERE title=@oldTitle";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@title", match.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@author", match.Author).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@date", match.Date).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@content", match.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", match.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@startTime", match.StartTime).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@endTime", match.EndTime).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@opponent", match.Opponent).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@matchScore", match.HomeGoal).SqlDbType = SqlDbType.VarChar;
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

        public int DeleteMatch(string title)
        {
            int rc = -1;
            string sql = "DELETE FROM match WHERE title=@title";

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

