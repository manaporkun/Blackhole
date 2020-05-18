using Techonology_Market_Management_System.Classes;

namespace Technology_Market_Management_System.Classes
{
    internal class Employee : Person
    {
        public int Update(int id, string name, string surname, string email, string password, string address)
        {
            var query = $"update Employee set Name = '{name}'," + $"Surname = '{surname}'," + $"Email = '{email}', " +
                        $"Password = '{password}'," + $"Address = '{address}'" + $"where ID = {id}";
            return DataAccess.ExecuteNonQuery(query);
        }

        public int Add(string name, string surname, string email, string password, string address)
        {
            var query = "insert into  Employee(Name,Surname,Email,Password,Address)" +
                        $"values('{name}','{surname}','{email}','{password}','{address}')";
            return DataAccess.ExecuteNonQuery(query);
        }
    }
}