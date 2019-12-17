using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Techonology_Market_Management_System.Classes;
using System.Data.SQLite;
//using System.Data;

namespace Techonology_Market_Management_System.Forms
{
    public partial class UserInformations : Form
    {
        User u = new User();
        static string email;
        bool condition = true;
        public UserInformations()
        {
            InitializeComponent();
            
            tbName.Text = u.GetCustomerByEmail(email).Rows[0][1].ToString();
            Surname.Text = u.GetCustomerByEmail(email).Rows[0][2].ToString();
            Email.Text = u.GetCustomerByEmail(email).Rows[0][3].ToString();
            Password.Text = u.GetCustomerByEmail(email).Rows[0][4].ToString();
            Address.Text = u.GetCustomerByEmail(email).Rows[0][5].ToString();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static void TakeEmail(string mail)
        {
            email = mail;
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            if (condition)
            {
                Password.UseSystemPasswordChar = true;
                condition = false;
            }
            else
            {
                Password.UseSystemPasswordChar = false;
                condition = true;
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
