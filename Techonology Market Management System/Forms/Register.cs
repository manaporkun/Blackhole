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
using Techonology_Market_Management_System.Forms;

namespace Techonology_Market_Management_System
{
    public partial class Register : Form
    {

        Login l = null;
        User u = new User();
        CartClass cc = new CartClass();
        ForgotPassword forgotPassword = new ForgotPassword();

        public Register()
        {
            InitializeComponent();
            lbError.Text = "";
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            string gender = "";
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string phoneNumber = maskedTextBox1.Text.ToString();
            string dob = dateTimePicker1.Value.Date.ToShortDateString().ToString();
            var passw = tPassword.Text.Trim();
            var name = tName.Text.Trim();
            var surname = tSurname.Text.Trim();
            var address = tAdress.Text.Trim();
            var email = tEmail.Text.Trim();

            lbError.Text = "";
            var dt_email = u.GetCustomerByEmail(email);
            var dt_phonenumber = u.GetCustomerByPhoneNumber(phoneNumber);

            if (rbMale.Checked)
                gender = "Male";
            else if (rbFemale.Checked)
                gender = "Female";

            if (name.Length == 0 || surname.Length == 0 || email.Length == 0 || passw.Length == 0 || address.Length == 0 || phoneNumber.Length == 0)
            {
                lbError.Text = "Parameters can not be empty.";
                return;
            }
            else if (name == "Name" || surname == "Surname" || email == "Email" || address == "Address")
            {
                lbError.Text = "Please enter valid informations";
                return;
            }
            else if (name == "admin" || surname == "admin" || email == "admin")
            {
                lbError.Text = "Please enter valid informations";
                return;
            }
            
            else if (dt_email.Rows.Count > 0)
            {
                lbError.Text = "This email is already exists.";
                return;
            }
            else if (dt_phonenumber.Rows.Count > 0)
            {
                lbError.Text = "This number is already exists.";
                return;
            }

            else if(!rbMale.Checked && !rbFemale.Checked)
            {
                lbError.Text = "Please select a gender";
                return;
            }

            else
            {
               
                if (email.IndexOf(".com") < email.IndexOf("@") + 1 || email.IndexOf(".com") == -1 || email.IndexOf(" ") != -1 || email.IndexOf("@") == -1)
                {
                    lbError.Text = "Please enter valid email adress";
                    //lbError.Text = dob;
                    //lbError.Text = (DateTime.Now.Year - dateTimePicker1.Value.Year).ToString();
                    return;
                }
                if (name.Length > 20 || name.Length < 3)
                {
                    lbError.Text = "Name must be between 20 and 3 characters";
                    return;
                }
                if (surname.Length > 20 || surname.Length < 3)
                {
                    lbError.Text = "Surname must be between 20 and 3 characters";
                    return;
                }
                if (passw.Length > 20 || passw.Length < 5)
                {
                    lbError.Text = "Password must be between 20 and 5 characters";
                    return;
                }
                
                if((DateTime.Now.Year - dateTimePicker1.Value.Year) < 18)
                {
                    lbError.Text = "You must be 18 at least to sign in.";
                    return;
                }
                
                else
                {
                    try
                    {
                        User u = new User();
                        var result = u.Add(name, surname, email, passw, address, gender, phoneNumber, dob);
                        if (result > 0)
                        {
                            lbError.Text = "Succesful";
                            cc.CreateTable(phoneNumber);

                            forgotPassword.isNew(email);
                            lbError.ForeColor = Color.Green;
                            this.Hide();
                            forgotPassword.Show();
                        }
                        else
                        {
                            lbError.Text = ("Error");
                            lbError.ForeColor = Color.Red;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }

            }
        }

     
        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void bLogin_Click(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new Login();
                l.Show();
                this.Hide();
            }
            else
            {
                l = null;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void securitybt_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
