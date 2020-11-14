using Techonology_Market_Management_System.Classes;

namespace Technology_Market_Management_System.Classes
{
    internal class User : Person
    {
        public int Update(int id, string name, string surname, string email, string password, string phonenumber)
        {
            var query = string.Format(
                "update Customer set Name = '{0}'," + "Surname = '{1}'," + "Email = '{3}', " + "Password = '{2}'," +
                "PhoneNumber = '{5}' " + "where ID = {4}", name, surname, password, email, id, phonenumber);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int UpdateAdmin(int id, string name, string surname, string email, string password, string address,
            string gender, string phonenumber, string dob)
        {
            var query = string.Format(
                "update Customer set Name = '{0}'," + "Surname = '{1}'," + "Email = '{3}', " + "Password = '{2}'," +
                "PhoneNumber = '{5}'," + "Address = '{6}'," + "Gender = '{7}'," + "DateofBirth = '{8}' " +
                "where ID = {4}", name, surname, password, email, id, phonenumber, address, gender, dob);
            return DataAccess.ExecuteNonQuery(query);
        }

        public int Add(string name, string surname, string email, string password, string address, string gender,
            string phonenumber, string dob)
        {
            var query = "insert into  Customer(Name,Surname,Email,Password,Address,Gender,PhoneNumber,DateofBirth)" +
                        $"values('{name}','{surname}','{email}','{password}','{address}','{gender}','{phonenumber}','{dob}')";
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetCustomerByEmail(string email)
        {
            var query = "select * from Customer where Email = '" + email + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCustomerByPhoneNumber(string phonenumber)
        {
            var query = "select * from Customer where PhoneNumber = '" + phonenumber + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCustomerAddress(string email)
        {
            var query = "select Address from Customer where Email = '" + email + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public int UpdateQuestion(int index, string answer, string email)
        {
            var query = $"update Customer set QuestionIndex = {index}," + $"QuestionAnswer = '{answer}'" +
                        $"where Email = '{email}'";
            return DataAccess.ExecuteNonQuery(query);
        }

        public static int UpdateSavedInformations(string email, string password)
        {
            var query = string.Format(
                "update SavedInformations set Email = '{0}'," + "Password = '{1}' " + "where ID = 'False'", email, password);
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable GetSavedInformation()
        {
            var query = "select * from SavedInformations";
            return DataAccess.ExecuteQuery(query);
        }
    }
}