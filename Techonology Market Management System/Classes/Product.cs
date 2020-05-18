using System.Data;

namespace Technology_Market_Management_System.Classes
{
    internal class Product
    {
        public int Delete(int id, string category)
        {
            var query = "delete * from " + category + " where ID = " + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable Get(string category)
        {
            var query = "select * from " + category;
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetById(int id, string category)
        {
            var query = "select * from " + category + " where ID = " + id;
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetByName(string name, string category)
        {
            var query = "select * from " + category + " where Name like '" + name + "%'";
            return DataAccess.ExecuteQuery(query);
        }

        public int UpdatePiece(string name, int piece, string category)
        {
            var query = string.Format("update " + category + " set Piece = {0} where Name = '{1}'", piece, name);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int AddImage(int id, byte[] img, string category)
        {
            var query = "update " + category + " set Image = @img where ID =" + id;
            return DataAccess.AddImg(query, img);
        }
    }
}