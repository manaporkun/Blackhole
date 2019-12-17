using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Technology_Market_Management_System;
using Techonology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Forms
{
    public partial class Edit_Employees : Form
    {
        Employee employee = new Employee();
        bool condition = true;
        Admin_Panel Admin_Panel;
        public Edit_Employees()
        {
            InitializeComponent();
        }

        private void Edit_Employees_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employee.Get("Employees");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text.Trim());
                string name = tName.Text.Trim();
                string surname = tSurname.Text.Trim();
                string email = tEmail.Text.Trim();
                string passw = tPassword.Text.Trim();
                string address = tAddress.Text.Trim();

                employee.Update(id, name, surname, email, passw, address);
                dataGridView1.DataSource = employee.Get("Employees");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //int id = int.Parse(textBox1.Text.Trim());
                string name = tName.Text.Trim();
                string surname = tSurname.Text.Trim();
                string email = tEmail.Text.Trim();
                string passw = tPassword.Text.Trim();
                string address = tAddress.Text.Trim();
                employee.Add(name, surname, email, passw, address);
                dataGridView1.DataSource = employee.Get("Employees");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text.Trim());
                tID.Text = employee.GetByID(id, "Employees").Rows[0][0].ToString();
                tName.Text = employee.GetByID(id, "Employees").Rows[0][1].ToString();
                tSurname.Text = employee.GetByID(id, "Employees").Rows[0][2].ToString();
                tEmail.Text = employee.GetByID(id, "Employees").Rows[0][3].ToString();
                tPassword.Text = employee.GetByID(id, "Employees").Rows[0][4].ToString();
                tAddress.Text = employee.GetByID(id, "Employees").Rows[0][5].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text.Trim());
                employee.Delete(id, "Employees");
                dataGridView1.DataSource = employee.Get("Employees");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (condition)
            {
                tPassword.UseSystemPasswordChar = true;
                condition = false;
            }
            else
            {
                tPassword.UseSystemPasswordChar = false;
                condition = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Admin_Panel == null)
            {
                Admin_Panel = new Admin_Panel();
                Admin_Panel.Show();
                this.Close();
            }
            else Admin_Panel = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_Employees_Load(sender, e);
        }
    }
}
