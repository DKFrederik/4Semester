using System;
using System.Data.SqlClient;

namespace DAO
{
    /// <summary>
    /// Extension class of the SqlDataReader-class used in DataAccessLayer.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Calls GetOrdinal on reader, and assigns value to the correct variable.
        /// </summary>
        /// <param name="reader">This specific SqlDataReader</param>
        /// <param name="name">Name of the column</param>
        /// <returns></returns>
        public static string GetString(this SqlDataReader reader, string name)
        {
            return reader.GetString(reader.GetOrdinal(name));
        }

        /// <summary>
        /// Calls GetOrdinal on reader, and assigns value to the correct variable.
        /// </summary>
        /// <param name="reader">This specific SqlDataReader</param>
        /// <param name="name">Name of the column</param>
        /// <returns></returns>
        public static DateTime GetDateTime(this SqlDataReader reader, string name)
        {
            return reader.GetDateTime(reader.GetOrdinal(name));
        }

        /// <summary>
        /// Calls GetOrdinal on reader, and assigns value to the correct variable.
        /// </summary>
        /// <param name="reader">This specific SqlDataReader</param>
        /// <param name="name">Name of the column</param>
        /// <returns></returns>
        public static int GetInt32(this SqlDataReader reader, string name)
        {
            return reader.GetInt32(reader.GetOrdinal(name));
        }

        /// <summary>
        /// Calls GetOrdinal on reader, and assigns value to the correct variable.
        /// </summary>
        /// <param name="reader">This specific SqlDataReader</param>
        /// <param name="name">Name of the column</param>
        /// <returns></returns>
        public static double GetDouble(this SqlDataReader reader, string name)
        {
            return reader.GetDouble(reader.GetOrdinal(name));
        }

        /// <summary>
        /// Calls GetOrdinal on reader, and assigns value to the correct variable.
        /// </summary>
        /// <param name="reader">This specific SqlDataReader</param>
        /// <param name="name">Name of the column</param>
        /// <returns></returns>
        public static Boolean GetBoolean(this SqlDataReader reader, string name)
        {
            return reader.GetBoolean(reader.GetOrdinal(name));
        }
    }
}