﻿using System;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.Transactions;

namespace DAO
{
    public class ContentInfoDAO
    {
        private DBAccess dba;

        public ContentInfoDAO()
        {
            this.dba = new DBAccess();
        }
        public int CreateContentInfo(string title, User author, DateTime date, string content, Boolean isPublic, string contentType) 
        {
            string sql = "INSERT INTO ContentInfo(title, creatorId, date, content, isPublic, contentType)" +
                "values(@title, (select id FROM Users where email = @email), @date, @content, @isPublic, @contentType) SELECT SCOPE_IDENTITY()";

            int maxId = -1;
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted; //TODO Overvej isolationsniveau
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (SqlCommand cmd = dba.GetDbCommand(sql))
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@title", title).SqlDbType = SqlDbType.VarChar;
                        cmd.Parameters.AddWithValue("@email", author.Email).SqlDbType = SqlDbType.VarChar;
                        cmd.Parameters.AddWithValue("@date", date).SqlDbType = SqlDbType.Date;
                        cmd.Parameters.AddWithValue("@content", content).SqlDbType = SqlDbType.VarChar;
                        cmd.Parameters.AddWithValue("@isPublic", isPublic).SqlDbType = SqlDbType.Bit;
                        cmd.Parameters.AddWithValue("@contentType", contentType).SqlDbType = SqlDbType.VarChar;

                        maxId = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                scope.Complete();
            }

            return maxId;
        }

        public string buildContentQuery()
        {
            return "c.title, c.creatorId, c.date, c.content, c.IsPublic";
        }

        public ContentInfo buildPartialObject(SqlDataReader sdr, ContentInfo obj)
        {
            UserDAO uDao = new UserDAO();
            obj.Title = sdr.GetString("title");
            obj.Author = uDao.FindUser(sdr.GetInt32("creatorId"));
            obj.Date = sdr.GetDateTime("date");
            obj.Content = sdr.GetString("content");
            obj.IsPublic = sdr.GetBoolean("IsPublic");
            return obj;
        }
    }
}
