using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
namespace Techonology_Market_Management_System.Classes
{
    public static class DataAccess
    {
        //private static string dbPath = @"Data Source = D:\Dev\C# Projects\Technology Market Management System\Database.db;";
        private static string dbPath = System.Configuration.ConfigurationManager.AppSettings["constring"];

        //SELECT
        public static DataTable ExecuteQuery(string query)
        {
            var con = new SQLiteConnection(dbPath);
            con.Open();
            var cmd = new SQLiteCommand(query, con);
            var adapter = new SQLiteDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        //INSERT DELETE UPDATE
        public static int ExecuteNonQuery(string query)
        {
            SQLiteConnection con = new SQLiteConnection(dbPath);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteNonQuery();
        }
    }
}
