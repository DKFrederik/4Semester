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

        public int CreateMatch(Match newMatch)
        {
            int rc = -1;

            string sql = "INSERT INTO match(title, author, date, content, isPublic, startTime, endTime, opponent, matchScore)" +
                "values(@title, @author, @date, @content, @isPublic, @startTime, @endTime, @opponent, @matchScore)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@title", newMatch.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@author", newMatch.Author).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@date", newMatch.Date).SqlDbType = SqlDbType.Date;
                    cmd.Parameters.AddWithValue("@content", newMatch.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", newMatch.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@starTime", newMatch.StartTime).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@endTime", newMatch.EndTime).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@opponent", newMatch.Opponent).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@matchScore", newMatch.MatchScore).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public Match FindMatch(string title)
        {
            Match foundMatch = null;

            string sql = "SELECT * FROM match WHERE title=@title";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@title", title).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundMatch = new Match()
                            {
                                Title = reader.GetString("title"),
                                Author = reader.GetString("author"),
                                Date = reader.GetDateTime("date"),
                                Content = reader.GetString("content"),
                                IsPublic = reader.GetBoolean("isPublic"),
                                StartTime = reader.GetDateTime("startTime"),
                                EndTime = reader.GetDateTime("endTime"),
                                Opponent = reader.GetString("opponent"),
                                MatchScore = reader.GetString("matchScore")
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

            return foundMatch;
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
                    cmd.Parameters.AddWithValue("@matchScore", match.MatchScore).SqlDbType = SqlDbType.VarChar;
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

