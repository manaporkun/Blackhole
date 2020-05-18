using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Blackhole.Classes;
using Blackhole.Forms;
using Blackhole.Properties;
using Bunifu.Framework.UI;
using Technology_Market_Management_System.Classes;
using Techonology_Market_Management_System;
using Techonology_Market_Management_System.Forms;

namespace Techonology_Market_Management_System.Forms
{
    public partial class Home : Form
    {

        private static string _beforeMail = string.Empty;
        private DataGridViewButtonColumn _col = new DataGridViewButtonColumn();
        private string _imgLoc = "";
        private int _productNumber;
        private static string _beforePhone = string.Empty;
        private static int _id = 0;


        private readonly CartClass _cc = new CartClass();
        private readonly User _u = new User();
        private readonly Order _order = new Order();
        private Computers _computers;
        private SmartPhones _phones;
        private MusicBook _book;
        private Payment payment;
        private Alert alert;
        private PaymentDelivery _pd;

        public Home(string email)
        {
            _beforeMail = email;
            InitializeComponent();
        }

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            TakePhone();
            _id = int.Parse(_u.GetCustomerByEmail(_beforeMail).Rows[0][0].ToString());
            xtraTabPage4.Show();
        }


        public void TakePhone()
        {
            _beforePhone = _u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString();
        }

        private void GetNumberProduct(string phonenumber)
        {
            for (var i = 0; i < _cc.Get(phonenumber).Rows.Count; i++)
                _productNumber += int.Parse(_cc.Get(phonenumber).Rows[i][2].ToString());

            PaymentDelivery.TakeNumberProduct(_productNumber);

            // added.Text = _productNumber.ToString();
        }

        private void AddButton(BunifuCustomDataGrid dataGrid, string text)
        {
            _col = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = 90,
                DefaultCellStyle = {ForeColor = Color.DarkCyan, BackColor = Color.White},
                FlatStyle = FlatStyle.Flat,
                DisplayIndex = dataGrid.Columns.Count + 1
            };
            dataGrid.Columns.Add(_col);
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            //accordionControlElement8_Click(sender, e);
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            lbError.Text = string.Empty;
            if (_u.GetCustomerByEmail(_beforeMail).Rows.Count < 1)
            {
                MessageBox.Show("There is no user with this email: " + _beforeMail);
            }
            else
            {
                if (_u.GetCustomerByEmail(_beforeMail).Rows[0][11].ToString() != "NULL")
                {
                    var img = (byte[]) (_u.GetCustomerByEmail(_beforeMail).Rows[0][11]);
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

                tName.Text = _u.GetCustomerByEmail(_beforeMail).Rows[0][1].ToString();
                tSurname.Text = _u.GetCustomerByEmail(_beforeMail).Rows[0][2].ToString();
                tEmail.Text = _u.GetCustomerByEmail(_beforeMail).Rows[0][3].ToString();
                tPassword.Text = _u.GetCustomerByEmail(_beforeMail).Rows[0][4].ToString();
                tAdress.Text = _u.GetCustomerByEmail(_beforeMail).Rows[0][5].ToString();
                maskedTextBox1.Text = _u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString();
                bunifuDatepicker1.Value = Convert.ToDateTime(_u.GetCustomerByEmail(_beforeMail).Rows[0][10].ToString());
                var gender = _u.GetCustomerByEmail(_beforeMail).Rows[0][9].ToString();
                if (gender == "Male")
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;
                xtraTabPage3.Show();
            }
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid1.Columns.Clear();
                if (_order.GetById(_id).Rows.Count > 0)
                {
                    bunifuCustomDataGrid1.DataSource = _order.GetById(_id);
                   // AddButton(bunifuCustomDataGrid1, "Show");
                }

                xtraTabPage2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid5.Columns.Clear();
                if (_cc.Get(_u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString()).Rows.Count > 0)
                {
                    bunifuCustomDataGrid5.DataSource =
                        _cc.Get(_u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString());
                    AddButton(bunifuCustomDataGrid5, "Delete");
                }

                xtraTabPage1.Show();
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

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            //xtraTabPage6.Show();
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
                    //AddButton(bunifuCustomDataGrid2);
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

                        img = (byte[]) (_computers.GetByName(label47.Text, "Computers").Rows[0][12]);
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

                xtraTabPage7.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid3.Columns.Clear();
                _phones = new SmartPhones();
                if (_phones.GetShort().Rows.Count > 0)
                {
                    bunifuCustomDataGrid3.DataSource = _phones.GetShort();
                    //AddButton(bunifuCustomDataGrid2);
                    label21.Text = _phones.GetShort().Rows[0][3].ToString();
                    label22.Text = _phones.GetShort().Rows[0][0].ToString();
                    label41.Text = _phones.GetShort().Rows[0][7].ToString();
                    label40.Text = _phones.GetShort().Rows[0][6].ToString();
                    label39.Text = _phones.GetShort().Rows[0][5].ToString();
                    label23.Text = _phones.GetShort().Rows[0][2].ToString();
                    label19.Text = _phones.GetShort().Rows[0][4].ToString();
                    label20.Text = _phones.GetShort().Rows[0][1].ToString();

                    byte[] img;
                    if (_phones.GetByName(label22.Text, "SmartPhones").Rows[0][10].ToString() != "NULL")
                    {

                        img = (byte[]) (_phones.GetByName(label22.Text, "SmartPhones").Rows[0][10]);
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
                    bunifuCustomDataGrid4.DataSource = _book.GetShort();
                    //AddButton(bunifuCustomDataGrid4);
                    label16.Text = _book.GetShort().Rows[0][4].ToString();
                    label24.Text = _book.GetShort().Rows[0][0].ToString();
                    label28.Text = _book.GetShort().Rows[0][3].ToString();
                    label14.Text = _book.GetShort().Rows[0][1].ToString();
                    label25.Text = _book.GetShort().Rows[0][2].ToString();

                    byte[] img;
                    if (_book.GetByName(label24.Text, "MusicBook").Rows[0][8].ToString() != "NULL")
                    {

                        img = (byte[]) (_book.GetByName(label24.Text, "MusicBook").Rows[0][8]);
                        if (img == null)
                        {
                            pictureBox19.Image = null;
                        }
                        else
                        {
                            var ms = new MemoryStream(img);
                            pictureBox19.Image = Image.FromStream(ms);

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
                var id = int.Parse(_u.GetCustomerByEmail(_beforeMail).Rows[0][0].ToString());
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

                if (name == "Name" || surname == "Surname" || email == "Email")
                {
                    lbError.Text = "Please enter valid informations";
                }

                if (name == "admin" || surname == "admin" || email == "admin")
                {
                    lbError.Text = "Please enter valid informations";
                }

                if (_beforeMail != email && dt_email.Rows.Count > 0)
                {
                    lbError.Text = "This email is already exists.";
                }

                if (_beforePhone != phoneNumber && dt_phonenumber.Rows.Count > 0)
                {
                    lbError.Text = "This number is already exists.";
                }
                else
                {
                    if (email.IndexOf(".com", StringComparison.Ordinal) <
                        email.IndexOf("@", StringComparison.Ordinal) + 1 ||
                        email.IndexOf(".com", StringComparison.Ordinal) == -1 ||
                        email.IndexOf(" ", StringComparison.Ordinal) != -1 ||
                        email.IndexOf("@", StringComparison.Ordinal) == -1)
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
                            id = int.Parse(u.GetCustomerByEmail(_beforeMail).Rows[0][0].ToString());
                            lbError.Text = phoneNumber;

                            var result = u.Update(id, name, surname, email, password, phoneNumber);
                            if (result > 0)
                            {
                                lbError.Text = "Succesful";
                                _beforeMail = email;
                                _beforePhone = phoneNumber;
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

                _u.AddImage(id, (byte[]) imgCon.ConvertTo(userPicture.Image, typeof(byte[])), "Customer");

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
                _imgLoc = dlg.FileName;
                userPicture.ImageLocation = _imgLoc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            
            var name = label47.Text;
            var phonenumber = _u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString();
            var price = int.Parse(label36.Text);
            _productNumber = 0;
            var userName = _u.GetCustomerByEmail(_beforeMail).Rows[0][1] + " " +
                           _u.GetCustomerByEmail(_beforeMail).Rows[0][2].ToString();
            var userId = int.Parse(_u.GetCustomerByEmail(_beforeMail).Rows[0][0].ToString());
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
            alert = new Alert();
            alert.Show();
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var name = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[0].Value.ToString();
                var price = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[1].Value.ToString();
                var brand = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[3].Value.ToString();
                var gpu = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[4].Value.ToString();
                var os = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[7].Value.ToString();
                var ram = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[6].Value.ToString();
                var date = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[2].Value.ToString();
                var cpu = bunifuCustomDataGrid2.Rows[e.RowIndex].Cells[5].Value.ToString();

                label51.Text = gpu;
                label50.Text = os;
                label49.Text = ram;
                label36.Text = price;
                label37.Text = brand;
                label47.Text = name;
                label48.Text = date;
                label35.Text = cpu;

                byte[] img;
                if (_computers.GetByName(label47.Text, "Computers").Rows[0][12].ToString() == "NULL") return;
                img = (byte[]) (_computers.GetByName(label47.Text, "Computers").Rows[0][12]);
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

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            TMMS.ActiveForm.Show();
            this.Close();
        }

        private void bunifuCustomDataGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {

                    label21.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[3].Value.ToString();
                    label22.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[0].Value.ToString();
                    label41.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[7].Value.ToString();
                    label40.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[6].Value.ToString();
                    label39.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[5].Value.ToString();
                    label23.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[2].Value.ToString();
                    label19.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[4].Value.ToString();
                    label20.Text = bunifuCustomDataGrid3.Rows[e.RowIndex].Cells[1].Value.ToString();

                    byte[] img;
                    if (_phones.GetByName(label22.Text, "SmartPhones").Rows[0][10].ToString() != "NULL")
                    {

                        img = (byte[]) (_phones.GetByName(label22.Text, "SmartPhones").Rows[0][10]);
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

                xtraTabPage5.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuCustomDataGrid4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    label16.Text = _book.GetShort().Rows[e.RowIndex][4].ToString();
                    label24.Text = _book.GetShort().Rows[e.RowIndex][0].ToString();
                    label28.Text = _book.GetShort().Rows[e.RowIndex][3].ToString();
                    label14.Text = _book.GetShort().Rows[e.RowIndex][1].ToString();
                    label25.Text = _book.GetShort().Rows[e.RowIndex][2].ToString();

                    byte[] img;
                    if (_book.GetByName(label24.Text, "MusicBook").Rows[0][8].ToString() != "NULL")
                    {

                        img = (byte[]) (_book.GetByName(label24.Text, "MusicBook").Rows[0][8]);
                        if (img == null)
                        {
                            pictureBox19.Image = null;
                        }
                        else
                        {
                            var ms = new MemoryStream(img);
                            pictureBox19.Image = Image.FromStream(ms);

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

        private void bunifuCustomDataGrid5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != bunifuCustomDataGrid5.Columns.Count - 1 || e.RowIndex < 0) return;
                var name = bunifuCustomDataGrid5.Rows[e.RowIndex].Cells[0].Value.ToString();
                var phonenumber = _u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString();
                var userId = int.Parse(_u.GetCustomerByEmail(_beforeMail).Rows[0][0].ToString());

                if (_cc.GetByName(phonenumber, name).Rows.Count > 0)
                {
                    var piece = int.Parse(_cc.GetByName(phonenumber, name).Rows[0][2].ToString());
                    if (piece > 1)
                    {
                        _cc.UpdatePiece(piece - 1, name, phonenumber);
                        _order.UpdatePiece(piece - 1, name, userId);
                    }
                    else
                    {
                        _cc.Delete(phonenumber, name);
                        _order.Delete(userId, name);
                    }

                }

                bunifuCustomDataGrid5.Columns.Clear();
                bunifuCustomDataGrid5.DataSource =
                    _cc.Get(_u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString());
                AddButton(bunifuCustomDataGrid5, "Delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(_u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var name = label22.Text;
            var phonenumber = _u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString();
            var price = int.Parse(label20.Text);
            _productNumber = 0;
            var userName = _u.GetCustomerByEmail(_beforeMail).Rows[0][1] + " " +
                           _u.GetCustomerByEmail(_beforeMail).Rows[0][2].ToString();
            var userId = int.Parse(_u.GetCustomerByEmail(_beforeMail).Rows[0][0].ToString());
            var date = DateTime.Today.ToString();

            if (_cc.GetByName(phonenumber, name).Rows.Count > 0)
            {
                var piece = int.Parse(_cc.GetByName(phonenumber, name).Rows[0][2].ToString());
                _cc.UpdatePiece(piece + 1, name, phonenumber);
                _order.UpdatePiece(piece + 1, name, userId);
            }
            else
            {
                _cc.Add(name, 1, phonenumber, price, "SmartPhones");
                _order.Add(name, 1, price, phonenumber, "Not entered", "On Cart", "SmartPhones", userName, userId, date);
            }

            GetNumberProduct(phonenumber);
            alert = new Alert();
            alert.Show();
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var name = label24.Text;
            var phonenumber = _u.GetCustomerByEmail(_beforeMail).Rows[0][6].ToString();
            var price = int.Parse(label14.Text);
            _productNumber = 0;
            var userName = _u.GetCustomerByEmail(_beforeMail).Rows[0][1] + " " +
                           _u.GetCustomerByEmail(_beforeMail).Rows[0][2].ToString();
            var userId = int.Parse(_u.GetCustomerByEmail(_beforeMail).Rows[0][0].ToString());
            var date = DateTime.Today.ToString();

            if (_cc.GetByName(phonenumber, name).Rows.Count > 0)
            {
                var piece = int.Parse(_cc.GetByName(phonenumber, name).Rows[0][2].ToString());
                _cc.UpdatePiece(piece + 1, name, phonenumber);
                _order.UpdatePiece(piece + 1, name, userId);
            }
            else
            {
                _cc.Add(name, 1, phonenumber, price, "MusicBook");
                _order.Add(name, 1, price, phonenumber, "Not entered", "On Cart", "MusicBook", userName, userId, date);
            }

            GetNumberProduct(phonenumber);
            alert = new Alert();
            alert.Show();
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid5.Rows.Count > 0)
            {
                if (_pd != null)
                {
                    _pd = null;
                }
                else
                {
                    _pd = new PaymentDelivery();
                    _pd.Show();
                    Close();
                }
            }
            else
            {
                label5.Text = "You need to add product to continue.";
            }
        }
    }
}