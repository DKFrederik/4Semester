using System;
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
        public int CreateContentInfo(string title, int creatorId, DateTime date, string content, Boolean isPublic, string contentType) 
        {
            string sql = "contentInfo_insert";

            int maxId = -1;
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted; //TODO Overvej isolationsniveau
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (SqlCommand cmd = dba.GetDbCommand(sql))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@title", title).SqlDbType = SqlDbType.VarChar;
                        cmd.Parameters.AddWithValue("@creatorId", creatorId).SqlDbType = SqlDbType.Int;
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
            UserDao uDao = new UserDao();
            obj.Title = sdr.GetString("title");
            obj.Author = uDao.FindUser(sdr.GetInt32("creatorId"));
            obj.Date = sdr.GetDateTime("date");
            obj.Content = sdr.GetString("content");
            obj.IsPublic = sdr.GetBoolean("IsPublic");
            return obj;
        }
    }
}
