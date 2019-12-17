using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Techonology_Market_Management_System.Classes
{
    class CartClass
    {

        public int Add(string name, int piece,string phonenumber,int price,string category)
        {
            string query = string.Format("insert into cart_{2} (Name,Piece,Price,Category)" + "values('{0}',{1},{3},'{4}')", name, piece,phonenumber,price,category);
            return DataAccess.ExecuteNonQuery(query);

        }

        public int CreateTable(string phonenumber)
        {
            string query = string.Format("create table cart_{0} (ID int, Name text, Price int, Piece int,Category text)", phonenumber);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable Get(string phonenumber)
        {
            string query = string.Format("select Name,Price,Piece,Category from cart_{0}", phonenumber);
            return DataAccess.ExecuteQuery(query);

        }

        public int UpdatePiece(int piece, string name, string phonenumber)
        {
            string query = string.Format("update cart_{2} set Piece = {0} where Name = '{1}'", piece, name, phonenumber);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetByName(string phonenumber,string name)
        {
            string query = string.Format("select Name,Price,Piece from cart_{0} where Name = '{1}'", phonenumber,name);
            return DataAccess.ExecuteQuery(query);

        }

        public int Delete(string phonenumber,string name)
        {
            string query = string.Format("delete from cart_{0} where Name = '{1}'", phonenumber,name);
            return DataAccess.ExecuteNonQuery(query);
        }
    }
}
