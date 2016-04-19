using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
