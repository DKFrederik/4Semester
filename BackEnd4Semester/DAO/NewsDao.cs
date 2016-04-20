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
    public class NewsDao
    {
        private DBAccess dba;

        public NewsDao()
        {
            this.dba = new DBAccess();
        }

        /// <summary>
        /// Creates a new tubble in the database 
        /// </summary>
        /// <param name="newNews"></param>
        /// <returns></returns>
        public int CreateNews(News news)
        {
            int rc = -1;

            ContentInfoDAO ctDao = new ContentInfoDAO();

            int ctId = ctDao.CreateContentInfo(news.Title, news.Author, news.Date, news.Content, news.IsPublic, "news");

            string sql = "INSERT INTO news(id, pictureURL)" +
                "values(@ctId, @picture)";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ctId", ctId).SqlDbType = SqlDbType.Int;
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

        public News FindNews(string title)
        {
            News foundNews = null;

            string sql = "SELECT * FROM news WHERE title=@title";
            using (SqlCommand cmd = dba.GetDbCommand(sql))
            {
                cmd.Parameters.AddWithValue("@title", title).SqlDbType = SqlDbType.VarChar;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            foundNews = new News()
                            {
                                Title = reader.GetString("title"),
                                Author = null,  //TODO reference
                                Date = reader.GetDateTime("date"),
                                Content = reader.GetString("content"),
                                IsPublic = reader.GetBoolean("isPublic"),
                                Picture = reader.GetString("picture")
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

            return foundNews;
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
