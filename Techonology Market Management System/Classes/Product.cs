using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techonology_Market_Management_System.Classes
{
    class Product
    {

        public int Delete(int id, string category)
        {
            string query = "delete * from " + category+" where ID = " + id;
            return DataAccess.ExecuteNonQuery(query);
        }

        public DataTable Get(string category)
        {
            string query = "select * from "+category;
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetByID(int id, string category)
        {
            string query = "select * from "+ category+" where ID = " + id;
            return DataAccess.ExecuteQuery(query);
        }
        public DataTable GetByName(string name, string category)
        {
            string query = "select * from " + category+" where Name like '" + name + "%'";
            return DataAccess.ExecuteQuery(query);
        }

        public int UpdatePiece(string name,int piece,string category)
        {
            string query = string.Format("update " + category + " set Piece = {0} where Name = '{1}'", piece,name);
            return DataAccess.ExecuteNonQuery(query);
        }
    }

    class Computers :  Product
    {
        public int Update(int id, string name, string gpu, int price, int piece, string date, string brand, string cpu, int ram, float ss, string os)
        {
            string query = string.Format("update Computers set ID = {0}," + "Name = '{1}'," + "GPU = '{2}', " + "Price = {3}," + "Piece = {4}," + "Date = '{5}'," + " Brand = '{6}'," + " CPU = '{7}'," + " RAM = '{8}'," + " ScreenSize = '{9}'," + " OS = '{10}'" + "where ID = {11}", id, name, gpu, price, piece, date, brand, cpu, ram, ss, os, id);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int Add(string name, string gpu, int price, int piece, string date, string brand, string cpu, int ram, float ss, string os)
        {
            string query = string.Format("insert into Computers (Name,GPU,Price,Piece,Date,Brand,CPU,RAM,ScreenSize,OS)" + "values('{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}','{9}')", name, gpu, price, piece, date, brand, cpu, ram, ss, os);
            return DataAccess.ExecuteNonQuery(query);

        }
        public DataTable GetShort()
        {
            string query = "select Name,Price,Date,Brand,GPU,CPU,RAM,ScreenSize,OS from Computers";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetShortByName(string name)
        {
            string query = "select Name,Price,Date,Brand,GPU,CPU,RAM,ScreenSize,OS from Computers where Name like '" + name + "%'";
            return DataAccess.ExecuteQuery(query);
        }

    }

    class SmartPhones : Product
    {
        public int Update(int id, string name, int price, int piece, string date, string brand,string cpu,int ram,int screensize,string screentype)
        {
            string query = string.Format("update SmartPhones set Name = '{1}'," + "Price = {2}," + "Piece = {3}," + "Date = '{4}'," + "Brand = '{5}'," + " CPU = '{6}'," + " RAM = {7}," + " ScreenSize = {8}," + " ScreenType = '{9}' "+ "where ID = {0}", id, name, price, piece, date, brand, cpu, ram, screensize, screentype);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int Add(string name, int price, int piece, string date, string brand, string cpu, int ram, int screensize, string screentype,string category)
        {
            string query = string.Format("insert into SmartPhones (Name,Price,Piece,Date,Brand,CPU,RAM,ScreenSize,ScreenType,Category)" + "values('{0}',{1},{2},'{3}','{4}','{5}',{6},{7},'{8}','{9}')",  name,  price,  piece,  date,  brand,  cpu,  ram,  screensize,  screentype,  category);
            return DataAccess.ExecuteNonQuery(query);

        }
        public DataTable GetShort()
        {
            string query = "select Name,Price,Date,Brand,CPU,RAM,ScreenSize,ScreenType from SmartPhones";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetShortByName(string name)
        {
            string query = "select Name,Price,Date,Brand,CPU,RAM,ScreenSize,ScreenType from SmartPhones where Name like '" + name + "%'";
            return DataAccess.ExecuteQuery(query);
        }
    }

    class MusicBook : Product
    {
        public int Update(int id, string name, string category, int price, int piece, string date, string producer,string author)
        {
            string query = string.Format("update MusicBook set Name = '{1}'," + "Category = '{2}', " + "Price = {3}," + "Piece = {4}," + "Date = '{5}'," + " Producer = '{6}'," + " Author = '{7}'" + "where ID = {0}", id, name, category, price, piece, date, producer,author);
            return DataAccess.ExecuteNonQuery(query);
        }
        public int Add(string name, string category, int price, int piece, string date, string producer, string author)
        {
            string query = string.Format("insert into MusicBook (Name,Category,Price,Piece,Date,Producer,Author)" + "values('{0}','{1}',{2},{3},'{4}','{5}','{6}')", name, category, price, piece, date, producer,author);
            return DataAccess.ExecuteNonQuery(query);

        }

        public DataTable GetShortByName(string name)
        {
            string query = "select Name,Price,Date,Producer,Author from MusicBook where Name like '" + name + "%'";
            return DataAccess.ExecuteQuery(query);
        }

        public DataTable GetShort()
        {
            string query = "select Name,Price,Date,Producer,Author from MusicBook";
            return DataAccess.ExecuteQuery(query);
        }
    }

    class ProductType : Product
    {
        public int Add(string type)
        {
            string query = string.Format("insert into ProductType (Type)" + "values({0})",type);
            return DataAccess.ExecuteNonQuery(query);

        }

        public string ShowType(int id)
        {
            var dt = Get("ProductType");
            return dt.Rows[id][1].ToString();
        }
    }

    class Orders : Product
    {

    }
}
