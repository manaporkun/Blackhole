using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Techonology_Market_Management_System.Forms;

namespace Techonology_Market_Management_System
{
    public partial class Admin_Panel : Form
    {
        private Edit_Product editProduct = null;
        private Edit_MusicBook edit_MusicBook = null;
        private Edit_SmartPhones Edit_SmartPhones = null;
        private Edit_Users edit_Users = null;
        private Edit_Employees edit_Employees = null;
        private TMMS tMMS;

        public Admin_Panel()
        {
            InitializeComponent();
        }

        private void Admin_Panel_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb.SelectedIndex == 0)
            {
                if (editProduct == null)
                {
                    editProduct = new Edit_Product();
                    editProduct.Show();
                }
                else
                    editProduct = null;
            }
            else if (cb.SelectedIndex == 1)
            {
                if (Edit_SmartPhones == null)
                {
                    Edit_SmartPhones = new Edit_SmartPhones();
                    Edit_SmartPhones.Show();
                }
                else
                    Edit_SmartPhones = null;

            }
            else if (cb.SelectedIndex == 2)
            {
                if (edit_MusicBook == null)
                {
                    edit_MusicBook = new Edit_MusicBook();
                    edit_MusicBook.Show();
                }
                else
                    edit_MusicBook = null;

            }

            else if (cb.SelectedIndex == 3)
            {
                if (edit_Users == null)
                {
                    edit_Users = new Edit_Users();
                    edit_Users.Show();
                }
                else
                    edit_Users = null;

            }
            else if (cb.SelectedIndex == 4)
            {
                if (edit_Employees == null)
                {
                    edit_Employees = new Edit_Employees();
                    edit_Employees.Show();
                }
                else
                    edit_Employees = null;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tMMS == null)
            {
                tMMS = new TMMS();
                tMMS.Show();
                this.Close();
            }
            else tMMS = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }
    }
}
