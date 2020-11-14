using Blackhole.Classes;
using Technology_Market_Management_System.Classes;

//using Technology_Market_Management_System;

namespace Techonology_Market_Management_System.Forms
{
    public partial class EditUsers : Form
    {
        private AdminPanel _adminPanel;
        private readonly User _u = new User();
        private Order order = new Order();
        private byte[] img = null;
        private string imgLoc = "";

        public EditUsers()
        {
            InitializeComponent();
        }

        private void Edit_Users_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _u.Get("Customer");
            dataGridView2.DataSource = order.Get();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox1.Text.Trim());
            _u.Delete(id, "Customer");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox1.Text.Trim());

                if (_u.GetById(id, "Customer").Rows.Count < 1)
                {
                    MessageBox.Show("There is no user with ID: " + id);
                }
                else
                {
                    byte[] img;
                    if (_u.GetById(id, "Customer").Rows[0][11].ToString() != "NULL")
                    {

                        img = (byte[])(_u.GetById(id, "Customer").Rows[0][11]);
                        if (img == null)
                        {
                            userPicture.Image = null;
                        }
                        else
                        {
                            var ms = new MemoryStream(img);
                            userPicture.Image = Image.FromStream(ms);

                        }
                    }

                    tID.Text = _u.GetById(id, "Customer").Rows[0][0].ToString();
                    tName.Text = _u.GetById(id, "Customer").Rows[0][1].ToString();
                    tSurname.Text = _u.GetById(id, "Customer").Rows[0][2].ToString();
                    tEmail.Text = _u.GetById(id, "Customer").Rows[0][3].ToString();
                    tPassword.Text = _u.GetById(id, "Customer").Rows[0][4].ToString();
                    tAdress.Text = _u.GetById(id, "Customer").Rows[0][5].ToString();
                    maskedTextBox1.Text = _u.GetById(id, "Customer").Rows[0][6].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(_u.GetById(id, "Customer").Rows[0][10].ToString());
                    var gender = _u.GetById(id, "Customer").Rows[0][9].ToString();
                    if (gender == "Male")
                        rbMale.Checked = true;
                    else
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
                var gender = "";
                maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                var phoneNumber = maskedTextBox1.Text;
                var dob = dateTimePicker1.Value.Date.ToShortDateString();
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


                _u.UpdateAdmin(id, name, surname, email, passw, address, gender, phoneNumber, dob);
                var imgCon = new ImageConverter();

                _u.AddImage(id, (byte[])imgCon.ConvertTo(userPicture.Image, typeof(byte[])), "Customer");
                dataGridView1.DataSource = _u.Get("Customer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            pictureBox1_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_Users_Load(sender, e);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(textBox1.Text.Trim());
                dataGridView2.DataSource = order.GetById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                userPicture.ImageLocation = imgLoc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}