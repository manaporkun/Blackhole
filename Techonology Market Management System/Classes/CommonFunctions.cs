using Technology_Market_Management_System.Classes;

namespace Blackhole.Classes
{
    public class CommonFunctions
    {
        private static readonly User _user = new User();
        private static readonly Product _product = new Product();

        public static void SetUserDetails(string _email, TextBox name, TextBox surname, TextBox email, TextBox password, TextBox address, MaskedTextBox phone, DateTimePicker time, RadioButton male, RadioButton female)
        {
            try
            {
                name.Text = _user.GetCustomerByEmail(_email).Rows[0][1].ToString();
                surname.Text = _user.GetCustomerByEmail(_email).Rows[0][2].ToString();
                email.Text = _user.GetCustomerByEmail(_email).Rows[0][3].ToString();
                password.Text = _user.GetCustomerByEmail(_email).Rows[0][4].ToString();
                address.Text = _user.GetCustomerByEmail(_email).Rows[0][5].ToString();
                phone.Text = _user.GetCustomerByEmail(_email).Rows[0][6].ToString();
                time.Value =
                    DateTime.Parse(_user.GetCustomerByEmail(_email).Rows[0][10].ToString());
                var gender = _user.GetCustomerByEmail(_email).Rows[0][9].ToString();
                if (gender == "Male")
                    male.Checked = true;
                else
                    female.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void GetEmail(string originalEmail, string copyEmail)
        {
            copyEmail = originalEmail;
        }

        public static void GetComputerById(int id, string category, DataGridView list, TextBox tID,
            TextBox tName, TextBox tPrice, TextBox tPiece, TextBox tDate, TextBox tBrand, TextBox tGPU, TextBox tCPU, TextBox tRAM, TextBox tSS, TextBox tOS)
        {
            list.DataSource = _product.GetById(id, category);
            tID.Text = _product.GetById(id, category).Rows[0][0].ToString();
            tName.Text = _product.GetById(id, category).Rows[0][1].ToString();
            tPrice.Text = _product.GetById(id, category).Rows[0][2].ToString();
            tPiece.Text = _product.GetById(id, category).Rows[0][3].ToString();
            tDate.Text = _product.GetById(id, category).Rows[0][4].ToString();
            tBrand.Text = _product.GetById(id, category).Rows[0][5].ToString();
            tGPU.Text = _product.GetById(id, category).Rows[0][6].ToString();
            tCPU.Text = _product.GetById(id, category).Rows[0][7].ToString();
            tRAM.Text = _product.GetById(id, category).Rows[0][8].ToString();
            tSS.Text = _product.GetById(id, category).Rows[0][9].ToString();
            tOS.Text = _product.GetById(id, category).Rows[0][10].ToString();
        }

        public static void GetComputerByName(string name, string category, DataGridView list, TextBox tID,
            TextBox tName, TextBox tPrice, TextBox tPiece, TextBox tDate, TextBox tBrand, TextBox tGPU, TextBox tCPU, TextBox tRAM, TextBox tSS, TextBox tOS)
        {
            list.DataSource = _product.GetByName(name, "Computers");
            tID.Text = _product.GetByName(name, "Computers").Rows[0][0].ToString();
            tName.Text = _product.GetByName(name, "Computers").Rows[0][1].ToString();
            tPrice.Text = _product.GetByName(name, "Computers").Rows[0][2].ToString();
            tPiece.Text = _product.GetByName(name, "Computers").Rows[0][3].ToString();
            tDate.Text = _product.GetByName(name, "Computers").Rows[0][4].ToString();
            tBrand.Text = _product.GetByName(name, "Computers").Rows[0][5].ToString();
            tGPU.Text = _product.GetByName(name, "Computers").Rows[0][6].ToString();
            tCPU.Text = _product.GetByName(name, "Computers").Rows[0][7].ToString();
            tRAM.Text = _product.GetByName(name, "Computers").Rows[0][8].ToString();
            tSS.Text = _product.GetByName(name, "Computers").Rows[0][9].ToString();
            tOS.Text = _product.GetByName(name, "Computers").Rows[0][10].ToString();
        }

        public static string ReturnString(string s)
        {
            switch (s)
            {
                case "empty":
                    return "Parameters can not be empty.";
                case "one":
                    return "You can only search with only one parameter";
                case "exist":
                    return "This product already exists";
                case "employee not deleted":
                    return "Last employee can not be deleted.";
                case "email":
                    return "Please enter valid email address";
                case "name":
                    return "Name must be between 20 and 3 characters";
                case "surname":
                    return "Surname must be between 20 and 3 characters";
                case "password":
                    return "Password must be between 20 and 5 characters";
                case "success":
                    return "Succesfull";
                default:
                    return string.Empty;
            }

        }

        public static bool ChangePasswordChar(bool condition, TextBox tPassword)
        {
            if (condition)
            {
                tPassword.UseSystemPasswordChar = true;
                return false;
            }
            else
            {
                tPassword.UseSystemPasswordChar = false;
                return true;
            }
        }

        public static void GetMusicBookById(DataGridView dataGridView1, int id, TextBox tID, TextBox tName, TextBox tPrice, TextBox tPiece, TextBox tDate, TextBox tAuthor, TextBox tProducer)
        {
            dataGridView1.DataSource = _product.GetById(id, "MusicBook");
            tID.Text = _product.GetById(id, "MusicBook").Rows[0][0]
                .ToString();
            tName.Text = _product.GetById(id, "MusicBook").Rows[0][1]
                .ToString();
            tPrice.Text = _product.GetById(id, "MusicBook").Rows[0][3]
                .ToString();
            tPiece.Text = _product.GetById(id, "MusicBook").Rows[0][4]
                .ToString();
            tDate.Text = _product.GetById(id, "MusicBook").Rows[0][5]
                .ToString();
            tAuthor.Text = _product.GetById(id, "MusicBook").Rows[0][7]
                .ToString();

            tProducer.Text = _product.GetById(id, "MusicBook").Rows[0][6]
                .ToString();
        }

        public static void GetMusicBookByName(DataGridView dataGridView1, string name, TextBox tID, TextBox tName, TextBox tPrice, TextBox tPiece, TextBox tDate, TextBox tAuthor, TextBox tProducer)
        {
            dataGridView1.DataSource = _product.GetByName(name, "MusicBook");
            tID.Text = _product.GetByName(name, "MusicBook").Rows[0][0].ToString();
            tName.Text = _product.GetByName(name, "MusicBook").Rows[0][1].ToString();
            tPrice.Text = _product.GetByName(name, "MusicBook").Rows[0][3].ToString();
            tPiece.Text = _product.GetByName(name, "MusicBook").Rows[0][4].ToString();
            tDate.Text = _product.GetByName(name, "MusicBook").Rows[0][5].ToString();
            tProducer.Text = _product.GetByName(name, "MusicBook").Rows[0][6].ToString();
            tAuthor.Text = _product.GetByName(name, "MusicBook").Rows[0][7].ToString();
        }

        public static void GetSmartphoneById(DataGridView dataGridView1, int id, TextBox tID, TextBox tName, TextBox tPrice, TextBox tPiece,
            TextBox tDate, TextBox tBrand, TextBox tCPU, TextBox tRAM, TextBox tSS, TextBox textBox1)
        {
            dataGridView1.DataSource = _product.GetById(id, "SmartPhones");
            tID.Text = _product.GetById(id, "SmartPhones").Rows[0][0]
                .ToString();
            tName.Text = _product.GetById(id, "SmartPhones").Rows[0][1]
                .ToString();
            tPrice.Text = _product.GetById(id, "SmartPhones").Rows[0][2]
                .ToString();
            tPiece.Text = _product.GetById(id, "SmartPhones").Rows[0][3]
                .ToString();
            tDate.Text = _product.GetById(id, "SmartPhones").Rows[0][4]
                .ToString();
            tBrand.Text = _product.GetById(id, "SmartPhones").Rows[0][5]
                .ToString();
            tCPU.Text = _product.GetById(id, "SmartPhones").Rows[0][6]
                .ToString();
            tRAM.Text = _product.GetById(id, "SmartPhones").Rows[0][7]
                .ToString();
            tSS.Text = _product.GetById(id, "SmartPhones").Rows[0][8]
                .ToString();
            textBox1.Text = _product.GetById(id, "SmartPhones").Rows[0][9]
                .ToString();
        }

        public static void GetSmartphonebyName(DataGridView dataGridView1, string name, TextBox tID, TextBox tName, TextBox tPrice, TextBox tPiece,
            TextBox tDate, TextBox tBrand, TextBox tCPU, TextBox tRAM, TextBox tSS, TextBox textBox1)
        {
            dataGridView1.DataSource = _product.GetByName(name, "SmartPhones");
            tID.Text = _product.GetByName(name, "SmartPhones").Rows[0][0].ToString();
            tName.Text = _product.GetByName(name, "SmartPhones").Rows[0][1].ToString();
            tPrice.Text = _product.GetByName(name, "SmartPhones").Rows[0][2]
                .ToString();
            tPiece.Text = _product.GetByName(name, "SmartPhones").Rows[0][3]
                .ToString();
            tDate.Text = _product.GetByName(name, "SmartPhones").Rows[0][4].ToString();
            tBrand.Text = _product.GetByName(name, "SmartPhones").Rows[0][5]
                .ToString();
            tCPU.Text = _product.GetByName(name, "SmartPhones").Rows[0][6].ToString();
            tRAM.Text = _product.GetByName(name, "SmartPhones").Rows[0][7].ToString();
            tSS.Text = _product.GetByName(name, "SmartPhones").Rows[0][8].ToString();
            textBox1.Text = _product.GetByName(name, "SmartPhones").Rows[0][9]
                .ToString();
        }
    }
}
