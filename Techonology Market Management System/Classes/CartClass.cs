using System.Data;

namespace Technology_Market_Management_System.Classes
{
    internal class CartClass
    {
        public int Add(string name, int piece, string phonenumber, int price, string category)
        {
            var query = string.Format(
                "insert into cart_{2} (Name,Piece,Price,Category)" + "values('{0}',{1},{3},'{4}')", name, piece,
                phonenumber, price, category);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int CreateTable(string phonenumber)
        {
            var query =
                $"create table cart_{phonenumber} (ID int primary key identity (1,1), Name varchar(50) not null, Price int not null, Piece int not null,Category varchar(50))";
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable Get(string phonenumber)
        {
            var query = $"select Name,Price,Piece,Category from cart_{phonenumber}";
            return DataAccess.ExecuteQuery(query);
        }

        public int UpdatePiece(int piece, string name, string phonenumber)
        {
            var query = string.Format("update cart_{2} set Piece = {0} where Name = '{1}'", piece, name, phonenumber);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetByName(string phonenumber, string name)
        {
            var query = $"select Name,Price,Piece from cart_{phonenumber} where Name = '{name}'";
            return DataAccess.ExecuteQuery(query);
        }

        public int Delete(string phonenumber, string name)
        {
            var query = $"delete from cart_{phonenumber} where Name = '{name}'";
            return DataAccess.ExecuteNonQuery(query);
        }
    }
}