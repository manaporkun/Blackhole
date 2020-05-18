using System.Data;

namespace Technology_Market_Management_System.Classes
{
    internal class SmartPhones : Product
    {
        public int Update(int id, string name, int price, int piece, string date, string brand, string cpu, int ram,
            int screensize, string screentype)
        {
            var query = string.Format(
                "update SmartPhones set Name = '{1}'," + "Price = {2}," + "Piece = {3}," + "Date = '{4}'," +
                "Brand = '{5}'," + " CPU = '{6}'," + " RAM = {7}," + " ScreenSize = {8}," + " ScreenType = '{9}' " +
                "where ID = {0}", id, name, price, piece, date, brand, cpu, ram, screensize, screentype);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int Add(string name, int price, int piece, string date, string brand, string cpu, int ram,
            int screensize, string screentype)
        {
            var query = string.Format(
                "insert into SmartPhones (Name,Price,Piece,Date,Brand,CPU,RAM,ScreenSize,ScreenType,Category)" +
                "values('{0}',{1},{2},'{3}','{4}','{5}',{6},{7},'{8}','SmartPhones')", name, price, piece, date, brand,
                cpu,
                ram, screensize, screentype);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetShort()
        {
            var query = "select Name,Price,Date,Brand,CPU,RAM,ScreenSize,ScreenType from SmartPhones";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetShortByName(string name)
        {
            var query =
                "select Name,Price,Date,Brand,CPU,RAM,ScreenSize,ScreenType from SmartPhones where Name like '" + name +
                "%'";
            return DataAccess.ExecuteQuery(query);
        }
    }
}