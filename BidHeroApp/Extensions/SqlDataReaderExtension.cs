using Microsoft.Data.SqlClient;

namespace BidHeroApp.Extensions
{
    public static class SqlDataReaderExtension
    {
        public static T GetValueOrDefault<T>(this SqlDataReader reader, string columnName, T defaultValue)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? defaultValue : (T)reader[columnName];
        }
    }
}
