namespace Technology_Market_Management_System.Classes
{
    internal class ProductType : Product
    {
        public int Add(string type)
        {
            var query = string.Format("insert into ProductType (Type)" + "values({0})", type);
            return DataAccess.ExecuteNonQuery(query);
        }

        public string ShowType(int id)
        {
            var dt = Get("ProductType");
            return dt.Rows[id][1].ToString();
        }
    }
}