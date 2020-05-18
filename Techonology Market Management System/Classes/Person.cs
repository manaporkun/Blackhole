using System.Data;
using Technology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Classes
{
    internal class Person
    {
        public DataTable Get(string type)
        {
            var query = "select * from " + type;
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetById(int id, string type)
        {
            var query = "select * from " + type + " where ID = " + id;
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetByName(string name, string type)
        {
            var query = "select * from " + type + " where Name = '" + name + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public bool LogIn(string email, string password, string type)
        {
            var query = string.Format("select * from " + type + " where Email = '{0}' and Password = '{1}'", email,
                password);
            var dt = DataAccess.ExecuteQuery(query);
            return dt.Rows.Count > 0;
        }

        public int Delete(int id, string type)
        {
            var query = "delete from " + type + " where ID = " + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public int AddImage(int id, byte[] img, string type)
        {
            var query = "update " + type + " set Image = @img where ID =" + id;
            return DataAccess.AddImg(query, img);
        }
    }
}