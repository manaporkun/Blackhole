using Technology_Market_Management_System.Classes;

namespace Blackhole.Classes
{
    internal class Order
    {
        public int Add(string productName, int piece, float price,
            string phonenumber, string address, string status, string category,
            string userName, int userId, string date)
        {
            var query = "insert into [Order] (ProductName,Piece,Price," +
                        "PhoneNumber,Address,Status,Category,UserName,UserID,Date)" +
                        $"values('{productName}',{piece},{price},'{phonenumber}','{address}','{status}','{category}','{userName}',{userId},'{date}')";
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetByEmail(string email)
        {
            var query = $"select * from [Order] where Email = '{email}'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetById(int id)
        {
            var query = $"select * from [Order] where UserID = {id}";
            return DataAccess.ExecuteQuery(query);
        }

        public int UpdatePiece(int piece, string name, int id)
        {
            var query = $"update [Order] set Piece = {piece} where ProductName = '{name}' and UserID = {id}";
            return DataAccess.ExecuteNonQuery(query);
        }

        public int UpdateStatus(string productName, int id)
        {
            var query = $"update [Order] set Status = 'Order Confirmed' where ProductName = '{productName}' and UserID = {id}";
            return DataAccess.ExecuteNonQuery(query);
        }

        public int UpdateAddress(string address, int id)
        {
            var query = $"update [Order] set Address = '{address}' where UserID = {id}";
            return DataAccess.ExecuteNonQuery(query);
        }

        public int Delete(int id, string name)
        {
            var query = $"delete from [Order] where ProductName = '{name}' and UserID = {id} and Status = 'On Cart'";
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable Get()
        {
            var query = $"select * from [Order]";
            return DataAccess.ExecuteQuery(query);
        }
    }
}