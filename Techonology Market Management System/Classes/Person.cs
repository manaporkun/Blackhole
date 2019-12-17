using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Techonology_Market_Management_System.Classes
{
    class Person
    {
        public DataTable Get(string type)
        {
            string query = "select * from "+ type;
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetByID(int id, string type)
        {
            string query = "select * from "+ type+" where ID = " + id;
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetByName(string name, string type)
        {
            string query = "select * from "+ type+" where Name = '" + name + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public bool LogIn(string email, string password,string type)
        {
            string query = string.Format("select * from " + type + " where Email = '{0}' and Password = '{1}'", email, password);
            var dt = DataAccess.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;

        }

        public int Delete(int id, string type)
        {
            string query = "delete from " + type + " where ID = " + id;
            return DataAccess.ExecuteNonQuery(query);
        }

    }

    class User : Person
    {
        public int Update(int id, string name, string surname, string email, string password, string phonenumber)
        {
            string query = string.Format("update Customer set Name = '{0}'," + "Surname = '{1}'," + "Email = '{3}', " + "Password = '{2}'," + "PhoneNumber = '{5}' " + "where ID = {4}", name, surname, password, email, id, phonenumber);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int UpdateAdmin(int id, string name, string surname, string email, string password, string address, string gender, string phonenumber, string dob)
        {
            string query = string.Format("update Customer set Name = '{0}'," + "Surname = '{1}'," + "Email = '{3}', " + "Password = '{2}'," + "PhoneNumber = '{5}'," + "Address = '{6}'," + "Gender = '{7}'," + "DateofBirth = '{8}' " + "where ID = {4}", name, surname, password, email, id, phonenumber,address,gender,dob);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int Add(string name, string surname, string email, string password, string address, string gender, string phonenumber, string dob)
        {
            string query = string.Format("insert into  Customer(Name,Surname,Email,Password,Address,Gender,PhoneNumber,DateofBirth)" + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", name, surname, email, password, address, gender, phonenumber, dob);
            return DataAccess.ExecuteNonQuery(query);

        }
       
        public DataTable GetCustomerByEmail(string email)
        {
            string query = "select * from Customer where Email = '" + email + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCustomerByPhoneNumber(string phonenumber)
        {
            string query = "select * from Customer where PhoneNumber = '" + phonenumber + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetCustomerAddress(string email)
        {
            string query = "select Address from Customer where Email = '" + email + "'";
            return DataAccess.ExecuteQuery(query);
        }

        public int UpdateQuestion(int index, string answer,string email)
        {
            string query = string.Format("update Customer set QuestionIndex = {0}," + "QuestionAnswer = '{1}'" + "where Email = '{2}'", index, answer, email);
            return DataAccess.ExecuteNonQuery(query);
        }
    }

    class Employee : Person
    {
        public int Update(int id, string name, string surname, string email, string password, string address)
        {
            string query = string.Format("update Employees set Name = '{0}'," + "Surname = '{1}'," + "Email = '{2}', " + "Password = '{3}'," + "Address = '{4}'" + "where ID = {5}", name, surname, email, password, address, id);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int Add(string name, string surname, string email, string password, string address)
        {
            string query = string.Format("insert into  Employees(Name,Surname,Email,Password,Address)" + "values('{0}','{1}','{2}','{3}','{4}')", name, surname, email, password, address);
            return DataAccess.ExecuteNonQuery(query);

        }
        
    }
}
