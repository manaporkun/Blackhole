using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Blackhole.Classes;
using Technology_Market_Management_System.Classes;
using Techonology_Market_Management_System.Forms;

namespace Techonology_Market_Management_System
{
    public partial class Register : Form
    {
        private readonly CartClass cc = new CartClass();
        private readonly ForgotPassword forgotPassword = new ForgotPassword();

        private Login l;
        private readonly User u = new User();
        private string imgLoc = "";
        private byte[] img;

        public Register()
        {
            InitializeComponent();
            lbError.Text = "";
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            var gender = "";
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            var phoneNumber = maskedTextBox1.Text;
            var dob = dateTimePicker1.Value.Date.ToShortDateString();
            var passw = tPassword.Text.Trim();
            var name = tName.Text.Trim();
            var surname = tSurname.Text.Trim();
            var address = tAdress.Text.Trim();
            var email = tEmail.Text.Trim();
            lbError.Text = "";
            var dtEmail = u.GetCustomerByEmail(email);
            var dtPhonenumber = u.GetCustomerByPhoneNumber(phoneNumber);

            if (imgLoc.Length != 0)
            {
                var fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                if (rbMale.Checked)
                    gender = "Male";
                else if (rbFemale.Checked)
                    gender = "Female";

                if (name.Length == 0 || surname.Length == 0 || email.Length == 0 || passw.Length == 0 ||
                    address.Length == 0 || phoneNumber.Length == 0)
                {
                    lbError.Text = "Parameters can not be empty.";
                }
                else if (name == "Name" || surname == "Surname" || email == "Email" || address == "Address")
                {
                    lbError.Text = "Please enter valid informations";
                }
                else if (name == "admin" || surname == "admin" || email == "admin")
                {
                    lbError.Text = "Please enter valid informations";
                }
                else if (dtEmail.Rows.Count > 0)
                {
                    lbError.Text = "This email is already exists.";
                }
                else if (dtPhonenumber.Rows.Count > 0)
                {
                    lbError.Text = "This number is already exists.";
                }
                else if (!rbMale.Checked && !rbFemale.Checked)
                {
                    lbError.Text = "Please select a gender";
                }
                else
                {
                    if (email.IndexOf(".com") < email.IndexOf("@") + 1 || email.IndexOf(".com") == -1 ||
                        email.IndexOf(" ") != -1 || email.IndexOf("@") == -1)
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

                    if (DateTime.Now.Year - dateTimePicker1.Value.Year < 18)
                        lbError.Text = "You must be 18 at least to sign in.";
                    else
                        try
                        {
                            var u = new User();
                            var result = u.Add(name, surname, email, passw, address, gender, phoneNumber, dob);
                            if (result > 0)
                            {
                                lbError.Text = "Succesful";
                                cc.CreateTable(phoneNumber);
                                u.AddImage(int.Parse(u.GetByName(name, "Customer").Rows[0][0].ToString()), img, "Customer");
                                lbError.Text = CommonFunctions.ReturnString("success");
                                forgotPassword.isNew(email);
                                lbError.ForeColor = Color.Green;
                                Hide();
                                forgotPassword.Show();
                            }
                            else
                            {
                                lbError.Text = "Error";
                                lbError.ForeColor = Color.Red;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                }
            }
            else
            {
                lbError.ForeColor = Color.Red;
                lbError.Text = "Please add a picture.";
            }
            

            

            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new Login();
                l.Show();
                Hide();
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

        private void browse_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                dlg.Filter = "JPEG Files (*.jpg)|*.jpg|All Files(*.*)|*.*";
                dlg.Title = "Select Computer Picture";
                if (dlg.ShowDialog() != DialogResult.OK) return;
                imgLoc = dlg.FileName;
                productPicture.ImageLocation = imgLoc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}