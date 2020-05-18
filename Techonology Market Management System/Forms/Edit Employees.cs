using System;
using System.Windows.Forms;
using Blackhole.Classes;
using Technology_Market_Management_System.Classes;
using Techonology_Market_Management_System;

//using Technology_Market_Management_System;

namespace Blackhole.Forms
{
    public partial class EditEmployees : Form
    {
        private bool _condition = true;
        private readonly Employee _employee = new Employee();
        private  AdminPanel _adminPanel;

        public EditEmployees()
        {
            InitializeComponent();
        }

        private void Edit_Employees_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _employee.Get("Employee");
            label15.Text = string.Empty;
            Error.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeInfo("update");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeInfo("add");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox1.Text.Trim());
                tID.Text = _employee.GetById(id, "Employee").Rows[0][0].ToString();
                tName.Text = _employee.GetById(id, "Employee").Rows[0][1].ToString();
                tSurname.Text = _employee.GetById(id, "Employee").Rows[0][2].ToString();
                tEmail.Text = _employee.GetById(id, "Employee").Rows[0][3].ToString();
                tPassword.Text = _employee.GetById(id, "Employee").Rows[0][4].ToString();
                tAddress.Text = _employee.GetById(id, "Employee").Rows[0][5].ToString();
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
                if (dataGridView1.RowCount > 2)
                {
                    var id = int.Parse(textBox1.Text.Trim());
                    _employee.Delete(id, "Employee");
                    dataGridView1.DataSource = _employee.Get("Employee");
                }
                else
                {
                    label15.Text = CommonFunctions.ReturnString("employee not deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _condition = CommonFunctions.ChangePasswordChar(_condition, tPassword);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (_adminPanel == null)
            {
                _adminPanel = new AdminPanel();
                _adminPanel.Show();
                Close();
            }
            else
            {
                _adminPanel = null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_Employees_Load(sender, e);
        }

        private void EmployeeInfo(string s)
        {
            try
            {
                Error.Text = string.Empty;

                var id = int.Parse(textBox1.Text.Trim());
                var name = tName.Text.Trim();
                var surname = tSurname.Text.Trim();
                var email = tEmail.Text.Trim();
                var password = tPassword.Text.Trim();
                var address = tAddress.Text.Trim();

                switch (s)
                {
                    case "update":
                        _employee.Update(id, name, surname, email, password, address);
                        break;
                    case "add":
                        _employee.Add(name, surname, email, password, address);
                        break;
                }

                
                dataGridView1.DataSource = _employee.Get("Employee");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}