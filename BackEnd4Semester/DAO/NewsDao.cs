using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Model;


namespace DAO
{
    public class NewsDao
    {
        ContentInfoDAO ctDao;
        private DBAccess dba;

        public NewsDao()
        {
            this.dba = new DBAccess();
            ctDao = new ContentInfoDAO();
        }

        /// <summary>
        /// Creates a new tubble in the database 
        /// </summary>
        /// <param name="newNews"></param>
        /// <returns></returns>
        public int CreateNews(News news)
        {
            int rc = -1;
            
            string sql = "news_insert";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", news.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@creatorId", news.Author.Id).SqlDbType = SqlDbType.Int;
                    cmd.Parameters.AddWithValue("@date", news.Date).SqlDbType = SqlDbType.Date;
                    cmd.Parameters.AddWithValue("@content", news.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", news.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@picture", news.Picture).SqlDbType = SqlDbType.VarChar;

                    rc = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rc;
        }

        public List<News> FindNews(DateTime date)
        {
            News n = null;
            List<News> newsList = new List<News>();

            string sql = "SELECT " + ctDao.buildContentQuery() + ", n.pictureURL FROM News n join ContentInfo c ON c.id = n.id WHERE c.date=@date";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@date", date).SqlDbType = SqlDbType.DateTime;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            n = new News();
                            n = (News) ctDao.buildPartialObject(reader, n);
                            n.Picture = reader.GetString("pictureURL");

                            newsList.Add(n);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                cmd.Parameters.Clear();
            }

            return newsList;
        }

        public int UpdateNews(News news, string oldTitle)
        {
            int rc = -1;
            string sql = "UPDATE news SET title=@title, author=@author, date=@date, content=@content, isPublic=@isPublic, picture=@picture" +
                "WHERE title=@oldTitle";

            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@title", news.Title).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@author", news.Author).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@date", news.Date).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@content", news.Content).SqlDbType = SqlDbType.VarChar;
                    cmd.Parameters.AddWithValue("@isPublic", news.IsPublic).SqlDbType = SqlDbType.Bit;
                    cmd.Parameters.AddWithValue("@picture", news.Picture).SqlDbType = SqlDbType.VarChar;
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

        public int DeleteNews(string title)
        {
            int rc = -1;
            string sql = "DELETE FROM news WHERE title=@title";

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
