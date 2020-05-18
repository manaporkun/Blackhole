using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Technology_Market_Management_System.Classes
{
    public static class DataAccess
    {
        //private static string dbPath = @"Data Source = C:\Users\Orkun Manap\Desktop\Blackhole-master\Database.db;";
        private static readonly string DbPath = ConfigurationManager.AppSettings["con_string"];

        //SELECT
        public static DataTable ExecuteQuery(string query)
        {
            var connection = new SqlConnection(DbPath);
            var command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;

            var adapter = new SqlDataAdapter(command);
            var dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        //INSERT DELETE UPDATE
        public static int ExecuteNonQuery(string query)
        {
            var connection = new SqlConnection(DbPath);
            var command = new SqlCommand(query, connection);
            connection.Open();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            return command.ExecuteNonQuery();
        }

        public static int AddImg(string query, byte[] img)
        {
            var connection = new SqlConnection(DbPath);
            var command = new SqlCommand(query, connection);
            connection.Open();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@img", img);
            return command.ExecuteNonQuery();
        }
    }
}