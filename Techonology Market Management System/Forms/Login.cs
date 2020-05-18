using System;
using System.Drawing;
using System.Windows.Forms;
using Blackhole.Forms;
using Technology_Market_Management_System.Classes;
using Techonology_Market_Management_System.Forms;

namespace Techonology_Market_Management_System
{
    public partial class Login : Form
    {
        private AdminPanel admin;
        private Employee employee;
        private ForgotPassword forgot;
        private Home h;
        private Register r;
        private TMMS tmms;
        private MainForm mainForm;

        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                r = new Register();
                r.Show();
            }
            else
            {
                r = null;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (email.Text == null || email.Text == "Type your email")
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
                    Close();
                }
                else
                {
                    forgot = null;
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                r = new Register();
                r.Show();
            }
            else
            {
                r = null;
            }
        }

        private void bLogin_Click_1(object sender, EventArgs e)
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
            }
            else
            {
                var u = new User();
                employee = new Employee();

                if (employee.LogIn(email, passw, "Employee"))
                {
                    Error.Text = "Successful";
                    Error.ForeColor = Color.Green;
                    admin = new AdminPanel();
                    admin.Show();
                    Hide();
                    //return;
                }
                else
                {
                    if (u.LogIn(email, passw, "Customer"))
                    {
                        if (bunifuCheckbox1.Checked)
                            User.UpdateSavedInformations(email, passw);
                        if (h == null)
                        {
                            h = new Home(email);
                            h.Show();

                            //UserInformations.TakeEmail(email);
                        }
                        else
                        {
                            h = null;
                        }

                        Payment.TakeEmail(email);
                        //Home.TakeEmail(email);
                        PaymentDelivery.TakeEmail(email);
                        Hide();

                        //if (mainForm != null)
                        //{
                        //    mainForm.Close();
                        //}
                        //else
                        //{
                        //    mainForm = new MainForm();
                        //    mainForm.Show();
                        //    if (bunifuCheckbox1.Checked)
                        //    {
                        //        u.UpdateSavedInformations(email, passw);
                        //    }
                        //    else
                        //    {
                        //        u.UpdateSavedInformations("Empty", "Empty");
                        //    }

                        //    Payment.TakeEmail(email);
                        //    MainForm.TakeEmail(email);
                        //    PaymentDelivery.TakeEmail(email);
                        //    this.Close();
                        //}
                    }
                    else
                    {
                        Error.Text = "Email or password is not correct.";
                    }
                }
            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            var user = new User();
            if (user.GetSavedInformation().Rows[0][0].ToString() == "Empty") return;
            email.Text = user.GetSavedInformation().Rows[0][0].ToString();
            tPassword.Text = user.GetSavedInformation().Rows[0][1].ToString();
        }
    }
}