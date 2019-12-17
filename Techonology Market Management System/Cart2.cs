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

namespace Techonology_Market_Management_System.Forms
{
    public partial class Payment: Form
    {
        string mail;
        CartClass cc = new CartClass();
        PaymentDelivery pd = null;
        Home home = null;
        Login l = null;

        public Payment()
        {
            InitializeComponent();
            dataGridView1.DataSource = cc.Get("Cart");


        }

        public void TakeEmail(string userMail)
        {
            mail = userMail;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (home != null)
            {
                home = null;

            }
            else
            {
                home = new Home();
                home.Show();
                Close();
            }
           
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new Login();
                l.Show();
                Close();
            }
            else
                l = null;
        }

        private void cart_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pd != null)
            {
                pd = null;

            }
            else
            {
                pd = new PaymentDelivery();
                pd.Show();
            }
        }
    }
}
