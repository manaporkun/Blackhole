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
    public partial class ForgotPassword : Form
    {
        Login login = new Login();
        private bool newAccount = false;
        string mail;
        User u = new User();
      
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login = new Login();
            login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int question_index = comboBox1.SelectedIndex;
            string answer = textBox1.Text;

            if (newAccount)
            {
             
                var result = u.UpdateQuestion(question_index, answer, mail);

                if(result > 0)
                {
                    label4.Text = "Succesful";
                    label4.ForeColor = Color.Green;
                }
                else
                {
                    label4.Text = "Error";
                    label4.ForeColor = Color.Red;
                }

            }

            else
            {              
                var result = u.GetCustomerByEmail(mail);

                if (result.Rows.Count < 1)
                {
                    label4.Text = "Please enter mail correctly on the main screen.";
                    return;
                }
                else
                {
                    int index = int.Parse(u.GetCustomerByEmail(mail).Rows[0][9].ToString());
                    string answ = u.GetCustomerByEmail(mail).Rows[0][10].ToString();

                    if (question_index == index && answer == answ)
                    {
                        label4.Text = u.GetCustomerByEmail(mail).Rows[0][4].ToString();
                    }
                    else
                    {
                        label4.Text = "Please try again.";
                    }
                }

                   


            }
        }

        public void isNew(string email)
        {
            newAccount = true;
            mail = email;
        }

        public void notNew(string email)
        {
            newAccount = false;
            mail = email;
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }
    }
}
