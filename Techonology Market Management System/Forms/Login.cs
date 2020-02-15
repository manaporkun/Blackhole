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
using Techonology_Market_Management_System.Classes;


namespace Techonology_Market_Management_System
{
    public partial class Login : Form
    {   
        Admin_Panel admin = null;
        Register r = null;
        Home h = null;
        Employee employee = null;
        ForgotPassword forgot;
        TMMS tmms;
        

        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            var email = this.email.Text.Trim();
            var passw = tPassword.Text.Trim();
            Error.ForeColor = Color.Red;

            if (email.Length == 0)
            {
                Error.Text = "ID can not be empty.";
                return;
            }
            if (passw.Length == 0)
            {
                Error.Text = "Password can not be empty.";
                return;
            }
            else
            {
                User u = new User();
                employee = new Employee();

                if (employee.LogIn(email, passw,"Employees"))
                {
                    Error.Text = ("Successful");
                    Error.ForeColor = Color.Green;
                    admin = new Admin_Panel();
                    admin.Show();
                    this.Hide();
                    //return;
                }
                else
                {
                    if (u.LogIn(email, passw,"Customer"))
                    {
                        if (h == null)
                        {
                            h = new Home();
                            h.Show();

                            //UserInformations.TakeEmail(email);
                        }
                        else
                            h = null;

                        Payment.TakeEmail(email);
                        Home.TakeEmail(email);
                        PaymentDelivery.TakeEmail(email);
                        this.Hide();
                    }
                    else
                        Error.Text = "Email or password is not correct.";

                }
                
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                r = new Register();
                r.Show();
            }
            else
                r = null;

           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

            if(email.Text == null || email.Text == "Type your email")
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Please enter your email first.";
            }
            else
            {
      
                if (forgot == null)
                {
                    forgot = new ForgotPassword();
                    forgot.notNew(email.Text);
                    forgot.Show();
                    this.Close();
                }
                else
                    forgot = null;
            }
            
        }
    }
}
