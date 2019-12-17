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
    public partial class Edit_Users : Form
    {
        User u = new User();
        Admin_Panel Admin_Panel;
        public Edit_Users()
        {
            InitializeComponent();
            
        }

        private void Edit_Users_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = u.Get("Customer");
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text.Trim());
            u.Delete(id, "Customer");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text.Trim());
                tID.Text = u.GetByID(id, "Customer").Rows[0][0].ToString();
                tName.Text = u.GetByID(id, "Customer").Rows[0][1].ToString();
                tSurname.Text = u.GetByID(id, "Customer").Rows[0][2].ToString();
                tEmail.Text = u.GetByID(id, "Customer").Rows[0][3].ToString();
                tPassword.Text = u.GetByID(id, "Customer").Rows[0][4].ToString();
                tAdress.Text = u.GetByID(id, "Customer").Rows[0][5].ToString();
                maskedTextBox1.Text = u.GetByID(id, "Customer").Rows[0][7].ToString();
               // dateTimePicker1.Value = u.GetByID(id, "Customer").Rows[0][8].ToString();
                string gender = u.GetByID(id, "Customer").Rows[0][6].ToString();
                if(gender == "Male")
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "";
                var phoneNumber = maskedTextBox1.Text.Trim();
                var dob = dateTimePicker1.Value.ToString();
                var passw = tPassword.Text.Trim();
                var name = tName.Text.Trim();
                var surname = tSurname.Text.Trim();
                var address = tAdress.Text;
                var email = tEmail.Text.Trim();
                var id = int.Parse(tID.Text.Trim());
                if (rbMale.Checked)
                    gender = "Male";
                else if (rbFemale.Checked)
                    gender = "Female";

        

                u.UpdateAdmin(id,name,surname,email,passw,address,gender,phoneNumber,dob);
                dataGridView1.DataSource = u.Get("Customer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3_Click(sender,e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            pictureBox1_Click(sender, e);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_Users_Load(sender, e);
        }
    }
}
