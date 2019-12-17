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

namespace Techonology_Market_Management_System
{
    public partial class Cart : Form
    {
        string mail;
        CartClass cc = new CartClass();
        PaymentDelivery pd = null;

        public Cart()
        {
            InitializeComponent();
            //dataGridView1.DataSource = cc.Get("Cart");
            

        }

        public void TakeEmail(string userMail)
        {
            mail = userMail;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pd != null)
            {
                pd = null;
         
            }
            else
            {
                pd = new PaymentDelivery();
                pd.Show();
            }
               
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
