using System.Data;

namespace Technology_Market_Management_System.Classes
{
    internal class Computers : Product
    {
        public int Update(int id, string name, string gpu, int price, int piece, string date, string brand, string cpu,
            int ram, float ss, string os)
        {
            var query = "update Computers set " + $"Name = '{name}'," + $"GPU = '{gpu}', " +
                        $"Price = {price}," + $"Piece = {piece}," + $"Date = '{date}'," + $" Brand = '{brand}'," +
                        $" CPU = '{cpu}'," + $" RAM = '{ram}'," + $" ScreenSize = '{ss}'," + $" OS = '{os}'" +
                        $"where ID = {id}";
            return DataAccess.ExecuteNonQuery(query);
        }

        public int Add(string name, string gpu, int price, int piece, string date, string brand, string cpu, int ram,
            float ss, string os)
        {
            var query = "insert into Computers (Name,GPU,Price,Piece,Date,Brand,CPU,RAM,ScreenSize,OS,Category)" +
                        $"values('{name}','{gpu}',{price},{piece},'{date}','{brand}','{cpu}','{ram}','{ss}','{os}','Computers')";
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetShort()
        {
            var query = "select Name,Price,Date,Brand,GPU,CPU,RAM,ScreenSize,OS from Computers";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetShortImage()
        {
            var query = "select Name,Image from Computers";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetShortByName(string name)
        {
            var query = "select Name,Price,Date,Brand,GPU,CPU,RAM,ScreenSize,OS from Computers where Name like '" +
                        name + "%'";
            return DataAccess.ExecuteQuery(query);
        }

        
    }
}