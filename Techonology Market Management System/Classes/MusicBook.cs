using System.Data;

namespace Technology_Market_Management_System.Classes
{
    internal class MusicBook : Product
    {
        public int Update(int id, string name, string category, int price, int piece, string date, string producer,
            string author)
        {
            var query = string.Format(
                "update MusicBook set Name = '{1}'," + "Category = '{2}', " + "Price = {3}," + "Piece = {4}," +
                "Date = '{5}'," + " Producer = '{6}'," + " Author = '{7}'" + "where ID = {0}", id, name, category,
                price, piece, date, producer, author);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int Add(string name, string category, int price, int piece, string date, string producer, string author)
        {
            var query = string.Format(
                "insert into MusicBook (Name,Category,Price,Piece,Date,Producer,Author)" +
                "values('{0}','{1}',{2},{3},'{4}','{5}','{6}')", name, category, price, piece, date,
                producer, author);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetShortByName(string name)
        {
            var query = "select Name,Price,Date,Producer,Author from MusicBook where Name like '" + name + "%'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetShort()
        {
            var query = "select Name,Price,Date,Producer,Author from MusicBook";
            return DataAccess.ExecuteQuery(query);
        }
    }
}