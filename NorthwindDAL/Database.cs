using System.Configuration;
using System.Data.SqlClient;

namespace NorthwindDAL
{
    public static class Database
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void OpenConnection()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
            }
        }
    }
}
