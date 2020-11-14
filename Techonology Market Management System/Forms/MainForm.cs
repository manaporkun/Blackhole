using Blackhole.Classes;
using Technology_Market_Management_System.Classes;
using Techonology_Market_Management_System;

namespace Blackhole.Forms
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private static string _mail = string.Empty;
        private DataGridViewButtonColumn _col = new DataGridViewButtonColumn();
        private string _imgLoc = "";
        private int _productNumber;
        private static string _phone = string.Empty;

        private readonly CartClass _cc = new CartClass();
        private readonly User _u = new User();
        private readonly Order _order = new Order();
        private Computers _computers;
        private SmartPhones _phones;
        private MusicBook _book;

        public MainForm()
        {
            InitializeComponent();
            xtraTabPage4.Show();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        public static void TakeEmail(string email)
        {
            _mail = email;
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid5.Columns.Clear();
                if (_cc.Get(_u.GetCustomerByEmail(_mail).Rows[0][6].ToString()).Rows.Count > 0)
                {
                    bunifuCustomDataGrid5.DataSource = _cc.Get(_u.GetCustomerByEmail(_mail).Rows[0][6].ToString());
                    AddButton(bunifuCustomDataGrid5);
                }

                xtraTabPage1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButton(BunifuCustomDataGrid dataGrid)
        {
            _col = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "DELETE",
                UseColumnTextForButtonValue = true,
                Width = 90,
                DefaultCellStyle = { ForeColor = Color.WhiteSmoke, BackColor = Color.DarkCyan },
                FlatStyle = FlatStyle.Flat,
                DisplayIndex = dataGrid.Columns.Count + 1
            };
            dataGrid.Columns.Add(_col);
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid1.Columns.Clear();
                if (_order.GetByEmail(_mail).Rows.Count > 0)
                {
                    bunifuCustomDataGrid1.DataSource = _order.GetByEmail(_mail);
                    AddButton(bunifuCustomDataGrid1);
                }

                xtraTabPage2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            if (_u.GetCustomerByEmail(_mail).Rows.Count < 1)
            {
                MessageBox.Show("There is no user with this email: " + _mail);
            }
            else
            {
                if (_u.GetCustomerByEmail(_mail).Rows[0][11].ToString() != "NULL")
                {
                    var img = (byte[])(_u.GetCustomerByEmail(_mail).Rows[0][11]);
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

                tName.Text = _u.GetCustomerByEmail(_mail).Rows[0][1].ToString();
                tSurname.Text = _u.GetCustomerByEmail(_mail).Rows[0][2].ToString();
                tEmail.Text = _u.GetCustomerByEmail(_mail).Rows[0][3].ToString();
                tPassword.Text = _u.GetCustomerByEmail(_mail).Rows[0][4].ToString();
                tAdress.Text = _u.GetCustomerByEmail(_mail).Rows[0][5].ToString();
                maskedTextBox1.Text = _u.GetCustomerByEmail(_mail).Rows[0][6].ToString();
                bunifuDatepicker1.Value = Convert.ToDateTime(_u.GetCustomerByEmail(_mail).Rows[0][10].ToString());
                var gender = _u.GetCustomerByEmail(_mail).Rows[0][9].ToString();
                if (gender == "Male")
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
                xtraTabPage3.Show();
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
                _imgLoc = dlg.FileName;
                userPicture.ImageLocation = _imgLoc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            try
            {
                maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                var phoneNumber = maskedTextBox1.Text;
                var gender = string.Empty;
                var password = tPassword.Text.Trim();
                var name = tName.Text.Trim();
                var surname = tSurname.Text.Trim();
                var email = tEmail.Text.Trim();
                var dt_email = _u.GetCustomerByEmail(email);
                var dt_phonenumber = _u.GetCustomerByPhoneNumber(phoneNumber);
                var id = int.Parse(_u.GetCustomerByEmail(_mail).Rows[0][0].ToString());
                var dob = bunifuDatepicker1.Value.Date.ToShortDateString();
                var address = tAdress.Text.ToString();
                if (rbMale.Checked)
                    gender = "Male";
                else if (rbFemale.Checked)
                    gender = "Female";

                lbError.Text = "";
                lbError.ForeColor = Color.Red;

                if (name.Length == 0 || surname.Length == 0 || email.Length == 0 || password.Length == 0 ||
                    phoneNumber.Length == 0)
                {
                    lbError.Text = "Parameters can not be empty.";
                }
                else if (name == "Name" || surname == "Surname" || email == "Email")
                {
                    lbError.Text = "Please enter valid informations";
                }
                else if (name == "admin" || surname == "admin" || email == "admin")
                {
                    lbError.Text = "Please enter valid informations";
                }
                else if (_mail != email && dt_email.Rows.Count > 0)
                {
                    lbError.Text = "This email is already exists.";
                }
                else if (_mail != phoneNumber && dt_phonenumber.Rows.Count > 0)
                {
                    lbError.Text = "This number is already exists.";
                }
                else
                {
                    if (email.IndexOf(".com", StringComparison.Ordinal) < email.IndexOf("@", StringComparison.Ordinal) + 1 || email.IndexOf(".com", StringComparison.Ordinal) == -1 ||
                        email.IndexOf(" ", StringComparison.Ordinal) != -1 || email.IndexOf("@", StringComparison.Ordinal) == -1)
                    {
                        lbError.Text = CommonFunctions.ReturnString("email");

                        return;
                    }

                    if (name.Length > 20 || name.Length < 3)
                    {
                        lbError.Text = CommonFunctions.ReturnString("name");
                        return;
                    }

                    if (surname.Length > 20 || surname.Length < 3)
                    {
                        lbError.Text = CommonFunctions.ReturnString("surname");
                        return;
                    }

                    if (password.Length > 20 || password.Length < 5)
                        lbError.Text = CommonFunctions.ReturnString("password");
                    else
                        try
                        {
                            var u = new User();
                            id = int.Parse(u.GetCustomerByEmail(_mail).Rows[0][0].ToString());
                            lbError.Text = phoneNumber;

                            var result = u.Update(id, name, surname, email, password, phoneNumber);
                            if (result > 0)
                            {
                                lbError.Text = "Succesful";
                                _mail = email;
                                _phone = phoneNumber;
                                lbError.ForeColor = Color.Green;
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


                _u.UpdateAdmin(id, name, surname, email, password, address, gender, phoneNumber, dob);
                var imgCon = new ImageConverter();

                _u.AddImage(id, (byte[])imgCon.ConvertTo(userPicture.Image, typeof(byte[])), "Customer");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            xtraTabPage4.Show();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            accordionControlElement8_Click(sender, e);
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            xtraTabPage6.Show();
        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid2.Columns.Clear();
                bunifuCustomDataGrid2.ReadOnly = true;

                _computers = new Computers();
                if (_computers.GetShort().Rows.Count > 0)
                {
                    bunifuCustomDataGrid2.DataSource = _computers.GetShort();
                    AddButton(bunifuCustomDataGrid2);
                    var name = bunifuCustomDataGrid2.Rows[0].Cells[0].Value.ToString();
                    var price = int.Parse(bunifuCustomDataGrid2.Rows[0].Cells[1].Value.ToString());
                    var brand = bunifuCustomDataGrid2.Rows[0].Cells[3].Value.ToString();
                    var gpu = bunifuCustomDataGrid2.Rows[0].Cells[4].Value.ToString();
                    var os = bunifuCustomDataGrid2.Rows[0].Cells[7].Value.ToString();
                    var ram = bunifuCustomDataGrid2.Rows[0].Cells[6].Value.ToString();
                    var date = bunifuCustomDataGrid2.Rows[0].Cells[2].Value.ToString();
                    var cpu = bunifuCustomDataGrid2.Rows[0].Cells[5].Value.ToString();

                    label51.Text = gpu;
                    label50.Text = os;
                    label49.Text = ram;
                    label36.Text = price.ToString();
                    label37.Text = brand;
                    label47.Text = name;
                    label48.Text = date;
                    label35.Text = cpu;

                    byte[] img;
                    if (_computers.GetByName(label47.Text, "Computers").Rows[0][12].ToString() != "NULL")
                    {

                        img = (byte[])(_computers.GetByName(label47.Text, "Computers").Rows[0][12]);
                        if (img == null)
                        {
                            pictureBox3.Image = null;
                        }
                        else
                        {
                            var ms = new MemoryStream(img);
                            pictureBox3.Image = Image.FromStream(ms);

                        }
                    }
                }

                xtraTabPage7.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.RowIndex < 4)
            {
                var name = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[0].Value.ToString();
                var price = int.Parse(bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[1].Value.ToString());
                var brand = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[3].Value.ToString();
                var gpu = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[4].Value.ToString();
                var os = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[7].Value.ToString();
                var ram = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[6].Value.ToString();
                var date = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[2].Value.ToString();
                var cpu = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[5].Value.ToString();

                label51.Text = gpu;
                label50.Text = os;
                label49.Text = ram;
                label36.Text = price.ToString();
                label37.Text = brand;
                label47.Text = name;
                label48.Text = date;
                label35.Text = cpu;

                byte[] img;
                if (_computers.GetByName(label47.Text, "Computers").Rows[0][12].ToString() == "NULL") return;
                img = (byte[])(_computers.GetByName(label47.Text, "Computers").Rows[0][12]);
                if (img == null)
                {
                    pictureBox3.Image = null;
                }
                else
                {
                    var ms = new MemoryStream(img);
                    pictureBox3.Image = Image.FromStream(ms);

                }
            }


        }

        private void GetNumberProduct(string phonenumber)
        {
            for (var i = 0; i < _cc.Get(phonenumber).Rows.Count; i++)
                _productNumber += int.Parse(_cc.Get(phonenumber).Rows[i][2].ToString());

            PaymentDelivery.TakeNumberProduct(_productNumber);

            // added.Text = _productNumber.ToString();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid3.Columns.Clear();
                _phones = new SmartPhones();
                if (_phones.GetShort().Rows.Count > 0)
                {
                    bunifuCustomDataGrid2.DataSource = _phones.GetShort();
                    AddButton(bunifuCustomDataGrid2);
                    label21.Text = bunifuCustomDataGrid3.Rows[0].Cells[3].Value.ToString();
                    label22.Text = bunifuCustomDataGrid3.Rows[0].Cells[0].Value.ToString();
                    label41.Text = bunifuCustomDataGrid3.Rows[0].Cells[7].Value.ToString();
                    label40.Text = bunifuCustomDataGrid3.Rows[0].Cells[6].Value.ToString();
                    label39.Text = bunifuCustomDataGrid3.Rows[0].Cells[5].Value.ToString();
                    label23.Text = bunifuCustomDataGrid3.Rows[0].Cells[2].Value.ToString();
                    label19.Text = bunifuCustomDataGrid3.Rows[0].Cells[4].Value.ToString();
                    label20.Text = bunifuCustomDataGrid3.Rows[0].Cells[1].Value.ToString();

                    byte[] img;
                    if (_phones.GetByName(label22.Text, "SmartPhones").Rows[0][10].ToString() != "NULL")
                    {

                        img = (byte[])(_phones.GetByName(label22.Text, "SmartPhones").Rows[0][10]);
                        if (img == null)
                        {
                            pictureBox17.Image = null;
                        }
                        else
                        {
                            var ms = new MemoryStream(img);
                            pictureBox17.Image = Image.FromStream(ms);

                        }
                    }
                }

                xtraTabPage5.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid4.Columns.Clear();
                _book = new MusicBook();
                if (_book.GetShort().Rows.Count > 0)
                {
                    bunifuCustomDataGrid4.DataSource = _phones.GetShort();
                    AddButton(bunifuCustomDataGrid4);
                    label16.Text = bunifuCustomDataGrid4.Rows[0].Cells[4].Value.ToString();
                    label24.Text = bunifuCustomDataGrid4.Rows[0].Cells[0].Value.ToString();
                    label28.Text = bunifuCustomDataGrid4.Rows[0].Cells[3].Value.ToString();
                    label14.Text = bunifuCustomDataGrid4.Rows[0].Cells[1].Value.ToString();
                    label25.Text = bunifuCustomDataGrid4.Rows[0].Cells[2].Value.ToString();

                    byte[] img;
                    if (_phones.GetByName(label24.Text, "MusicBook").Rows[0][8].ToString() != "NULL")
                    {

                        img = (byte[])(_book.GetByName(label24.Text, "MusicBook").Rows[0][8]);
                        if (img == null)
                        {
                            pictureBox18.Image = null;
                        }
                        else
                        {
                            var ms = new MemoryStream(img);
                            pictureBox18.Image = Image.FromStream(ms);

                        }
                    }
                }

                xtraTabPage8.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {

                var name = label14.Text;
                var phonenumber = _u.GetCustomerByEmail(_mail).Rows[0][6].ToString();
                var price = int.Parse(label16.Text);
                _productNumber = 0;
                var userName = _u.GetCustomerByEmail(_mail).Rows[0][1] + " " + _u.GetCustomerByEmail(_mail).Rows[0][2].ToString();
                var userId = int.Parse(_u.GetCustomerByEmail(_mail).Rows[0][0].ToString());
                var date = DateTime.Today.ToString();

                if (_cc.GetByName(phonenumber, name).Rows.Count > 0)
                {
                    var piece = int.Parse(_cc.GetByName(phonenumber, name).Rows[0][2].ToString());
                    _cc.UpdatePiece(piece + 1, name, phonenumber);
                    _order.UpdatePiece(piece + 1, name, userId);
                }
                else
                {
                    _cc.Add(name, 1, phonenumber, price, "Computers");
                    _order.Add(name, 1, price, phonenumber, "Not entered", "On Cart", "Computers", userName, userId, date);
                }

                GetNumberProduct(phonenumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bHDatabaseDataSet10.Computers' table. You can move, or remove it, as needed.
            this.computersTableAdapter1.Fill(this.bHDatabaseDataSet10.Computers);
            // TODO: This line of code loads data into the 'bHDatabaseDataSet.Computers' table. You can move, or remove it, as needed.
            this.computersTableAdapter.Fill(this.bHDatabaseDataSet.Computers);

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
