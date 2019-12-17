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
    public partial class Home : Form
    {
        Login l = null;
        
        Register r = null;
        Search s = null;
        PaymentDelivery p = null;
        Payment c = null;
        UserInformations userInformations = null;
        Computers comp = new Computers();
        SmartPhones sp = new SmartPhones();
        MusicBook mb = new MusicBook();
        CartClass cc = new CartClass();
        Product product = new Product();
        ProductType productType = new ProductType();
        string selection = "Computers";
        private bool menu = false;
        DataGridViewButtonColumn col;
        private bool userinfo = false;
        private static string before_change_email;
        private static string before_change_phone;
        private int piece = 0;
        User u = new User();
        int productNumber = 0;
        private bool datagrid = false;
        Compare compare;





        public Home()
        {
            InitializeComponent();
            

        }


        private void AddButton()
        {
            //dataGridView1.Columns.Clear();
           
            col = new DataGridViewButtonColumn();
            col.HeaderText = "";
            col.Text = "ADD";
            col.UseColumnTextForButtonValue = true;
            col.Width = 120;
            col.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            col.DefaultCellStyle.BackColor = Color.DarkCyan;
            col.FlatStyle = FlatStyle.Flat;
            col.DisplayIndex = dataGridView1.Columns.Count + 1;
            dataGridView1.Columns.Add(col);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (s == null)
            {
                s = new Search();
                s.Show();
            }
            else
                s = null;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            

            dataGridView1.DataSource = comp.GetShort();
            groupBox5.Hide();
            groupBox7.Hide();
            AddButton();
            errorlb.Text = "";
            added.Text = "";


            button2_Click(sender, e);
            pictureBox3.Image = Properties.Resources._1;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            Timer tm = new Timer();
            tm.Tick += new EventHandler(changeimage);
            tm.Start();

        }

        private void changeimage(object sender, EventArgs e)
        {
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources._1);
            b1.Add(Properties.Resources._2);
            b1.Add(Properties.Resources._3);
            b1.Add(Properties.Resources._4);
            //b1.Add(Properties.Resources._5);
            b1.Add(Properties.Resources._6);
            b1.Add(Properties.Resources._7);
            int index = (DateTime.Now.Second / 6) % b1.Count;
            pictureBox3.Image = b1[index];

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //selection = "Computers";
                string name = textBox1.Text.Trim();
                dataGridView1.Columns.Clear();

                switch (selection)
                {
                    case "Computers":
                        dataGridView1.DataSource = comp.GetShortByName(name);
                        break;
                    case "SmartPhones":
                        dataGridView1.DataSource = sp.GetShortByName(name);
                        break;
                    case "MusicBook":
                        dataGridView1.DataSource = mb.GetShortByName(name);
                        break;
                    default:
                        break;
                }

                AddButton();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            //tbid.text = datagrid.rows[secilen].cell[0].value.tostring();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void user_Click_1(object sender, EventArgs e)
        {
            /*
            if (userInformations == null)
            {
                userInformations = new UserInformations();
                userInformations.Show();
            }
            else
                userInformations = null;
            */
            if (!userinfo)
            {
                //User u = new User();
                errorlb.Text = "";
                tName.Text = u.GetCustomerByEmail(before_change_email).Rows[0][1].ToString();
                tSurname.Text = u.GetCustomerByEmail(before_change_email).Rows[0][2].ToString();
                tEmail.Text = u.GetCustomerByEmail(before_change_email).Rows[0][3].ToString();
                tPassword.Text = u.GetCustomerByEmail(before_change_email).Rows[0][4].ToString();
                tPhone.Text = u.GetCustomerByEmail(before_change_email).Rows[0][7].ToString();
                before_change_phone = u.GetCustomerByEmail(before_change_email).Rows[0][7].ToString(); ;
                //tAdress.Text = u.GetCustomerByEmail(before_change_email).Rows[0][5].ToString();
                groupBox7.Show();
                userinfo = true;
            }
            else
            {
                groupBox7.Hide();
                userinfo = false;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new Login();
                l.Show();
                this.Close();
            }
            else
                l = null;
        }

        private void cart_Click_1(object sender, EventArgs e)
        {
            if (c == null)
            {
                c = new Payment();
                c.Show();
                this.Hide();
            }
            else
                c = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.Columns.Clear();
            label20.Text = productType.ShowType(1);
            dataGridView1.DataSource = sp.GetShort();
            selection = productType.ShowType(1);
            c1name.Text = sp.GetByID(0, "SmartPhones").Rows[0][1].ToString();
            c1brand.Text = sp.GetByID(0, "SmartPhones").Rows[0][5].ToString();
            c1price.Text = sp.GetByID(0, "SmartPhones").Rows[0][2].ToString();
            c1picture.Image = Properties.Resources.p2;

            c2name.Text = sp.GetByID(1, "SmartPhones").Rows[0][1].ToString();
            c2brand.Text = sp.GetByID(1, "SmartPhones").Rows[0][5].ToString();
            c2price.Text = sp.GetByID(1, "SmartPhones").Rows[0][2].ToString();
            c2picture.Image = Properties.Resources.p3;

            c3name.Text = sp.GetByID(2, "SmartPhones").Rows[0][1].ToString();
            c3brand.Text = sp.GetByID(2, "SmartPhones").Rows[0][5].ToString();
            c3price.Text = sp.GetByID(2, "SmartPhones").Rows[0][2].ToString();
            c3picture.Image = Properties.Resources.p1;

            c4name.Text = sp.GetByID(3, "SmartPhones").Rows[0][1].ToString();
            c4brand.Text = sp.GetByID(3, "SmartPhones").Rows[0][5].ToString();
            c4price.Text = sp.GetByID(3, "SmartPhones").Rows[0][2].ToString();
            c4picture.Image = Properties.Resources.p4;
            AddButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            label20.Text = productType.ShowType(0);
            dataGridView1.DataSource = comp.GetShort();
            selection = productType.ShowType(0);
            c1name.Text = sp.GetByID(1, "Computers").Rows[0][1].ToString();
            c1brand.Text = sp.GetByID(1, "Computers").Rows[0][5].ToString();
            c1price.Text = sp.GetByID(1, "Computers").Rows[0][2].ToString();
            c1picture.Image = Properties.Resources.c2;

            c2name.Text = sp.GetByID(0, "Computers").Rows[0][1].ToString();
            c2brand.Text = sp.GetByID(0, "Computers").Rows[0][5].ToString();
            c2price.Text = sp.GetByID(0, "Computers").Rows[0][2].ToString();
            c2picture.Image = Properties.Resources.c3;

            c3name.Text = sp.GetByID(4, "Computers").Rows[0][1].ToString();
            c3brand.Text = sp.GetByID(4, "Computers").Rows[0][5].ToString();
            c3price.Text = sp.GetByID(4, "Computers").Rows[0][2].ToString();
            c3picture.Image = Properties.Resources.c1;

            c4name.Text = sp.GetByID(2, "Computers").Rows[0][1].ToString();
            c4brand.Text = sp.GetByID(2, "Computers").Rows[0][5].ToString();
            c4price.Text = sp.GetByID(2, "Computers").Rows[0][2].ToString();
            c4picture.Image = Properties.Resources.c4;
            AddButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            label20.Text = productType.ShowType(2);
            dataGridView1.DataSource = mb.GetShort();
            selection = productType.ShowType(2);
            c1name.Text = mb.GetByID(1, "MusicBook").Rows[0][1].ToString();
            c1brand.Text = mb.GetByID(1, "MusicBook").Rows[0][7].ToString();
            c1price.Text = mb.GetByID(1, "MusicBook").Rows[0][3].ToString();
            c1picture.Image = Properties.Resources.b1;

            c2name.Text = mb.GetByID(2, "MusicBook").Rows[0][1].ToString();
            c2brand.Text = mb.GetByID(2, "MusicBook").Rows[0][7].ToString();
            c2price.Text = mb.GetByID(2, "MusicBook").Rows[0][3].ToString();
            c2picture.Image = Properties.Resources.b2;

            c3name.Text = mb.GetByID(3, "MusicBook").Rows[0][1].ToString();
            c3brand.Text = mb.GetByID(3, "MusicBook").Rows[0][7].ToString();
            c3price.Text = mb.GetByID(3, "MusicBook").Rows[0][3].ToString();
            c3picture.Image = Properties.Resources.b3;

            c4name.Text = mb.GetByID(4, "MusicBook").Rows[0][1].ToString();
            c4brand.Text = mb.GetByID(4, "MusicBook").Rows[0][7].ToString();
            c4price.Text = mb.GetByID(4, "MusicBook").Rows[0][3].ToString();
            c4picture.Image = Properties.Resources.b4;
            AddButton();
        }


        private void menubutton_Click(object sender, EventArgs e)
        {
            if (menu == false)
            {
                groupBox5.Show();
                menu = true;
            }

            else
            {

                groupBox5.Hide();
                groupBox7.Hide();
                userinfo = false;
                menu = false;

            }

        }

        private void label15_Click(object sender, EventArgs e)
        {
            menubutton_Click(sender, e);
        }


        private void button6_Click(object sender, EventArgs e)
        {
           
            tPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string phoneNumber = tPhone.Text.ToString();
           
            var passw = tPassword.Text.Trim();
            var name = tName.Text.Trim();
            var surname = tSurname.Text.Trim();
            //var address = tAdress.Text.Trim();
            var email = tEmail.Text.Trim();
            var dt_email = u.GetCustomerByEmail(email);
            var dt_phonenumber = u.GetCustomerByPhoneNumber(phoneNumber);
            //bool phone_changed = false;

            errorlb.Text = "";
            errorlb.ForeColor = Color.Red;

            if (name.Length == 0 || surname.Length == 0 || email.Length == 0 || passw.Length == 0  || phoneNumber.Length == 0)
            {
                errorlb.Text = "Parameters can not be empty.";
                return;
            }
            else if (name == "Name" || surname == "Surname" || email == "Email")
            {
                errorlb.Text = "Please enter valid informations";
                return;
            }
            else if (name == "admin" || surname == "admin" || email == "admin")
            {
                errorlb.Text = "Please enter valid informations";
                return;
            }
            else if (before_change_email != email && dt_email.Rows.Count > 0)
            {
                errorlb.Text = "This email is already exists.";
                return;
            }
            else if (before_change_phone != phoneNumber && dt_phonenumber.Rows.Count > 0)
            {
                errorlb.Text = "This number is already exists.";
                return;
            }

            else
            {

                if (email.IndexOf(".com") < email.IndexOf("@") + 1 || email.IndexOf(".com") == -1 || email.IndexOf(" ") != -1 || email.IndexOf("@") == -1)
                {
                    errorlb.Text = "Please enter valid email adress";
                    
                    return;
                }
                if (name.Length > 20 || name.Length < 3)
                {
                    errorlb.Text = "Name must be between 20 and 3 characters";
                    return;
                }
                if (surname.Length > 20 || surname.Length < 3)
                {
                    errorlb.Text = "Surname must be between 20 and 3 characters";
                    return;
                }
                if (passw.Length > 20 || passw.Length < 5)
                {
                    errorlb.Text = "Password must be between 20 and 5 characters";
                    return;
                }

                

                else
                {
                    try
                    {
                        User u = new User();
                        int id = int.Parse(u.GetCustomerByEmail(before_change_email).Rows[0][0].ToString());
                        errorlb.Text = phoneNumber;

                        var result = u.Update(id, name, surname, email, passw, phoneNumber);
                        if (result > 0)
                        {
                            errorlb.Text = ("Succesful");
                            before_change_email = email;
                            before_change_phone = phoneNumber;
                            errorlb.ForeColor = Color.Green;
                        }
                        else
                        {
                            errorlb.Text = ("Error");
                            errorlb.ForeColor = Color.Red;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
        }

        public static void TakeEmail(string e)
        {
            before_change_email = e;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (compare == null)
            {
                compare = new Compare();
                compare.Show();
                this.Hide();
            }
            else compare = null;
        }

        private void c1picture_Click(object sender, EventArgs e)
        {
            if(selection == "Computers")
            {
                textBox1.Text = "Mac";
            }
            else if(selection == "SmartPhones")
            {
                textBox1.Text = "Mi 9T Pro";
            }
            else
            {
                textBox1.Text = "Zamanın Kısa Tarihi";
            }

        }

        private void c2picture_Click(object sender, EventArgs e)
        {
            if (selection == "Computers")
            {
                textBox1.Text = "Inspiron 7567";
            }
            else if (selection == "SmartPhones")
            {
                textBox1.Text = "M30";
            }
            else
            {
                textBox1.Text = "Türlerin Kökeni";
            }
        }

        private void c3picture_Click(object sender, EventArgs e)
        {
            if (selection == "Computers")
            {
                textBox1.Text = "Ge63 Raider";
            }
            else if (selection == "SmartPhones")
            {
                textBox1.Text = "iPhone 11 Pro";
            }
            else
            {
                textBox1.Text = "Kozmos";
            }
        }

        private void c4picture_Click(object sender, EventArgs e)
        {
            if (selection == "Computers")
            {
                textBox1.Text = "Ideapad 310";
            }
            else if (selection == "SmartPhones")
            {
                textBox1.Text = "AX7";
            }
            else
            {
                textBox1.Text = "Büyük Tasarım";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns.Count - 1 && e.RowIndex >= 0)
                {

                    string name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string phonenumber = u.GetCustomerByEmail(before_change_email).Rows[0][7].ToString();
                    int price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    //string category = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 2].Value.ToString();
                    productNumber = 0;

                    //MessageBox.Show("Added");

                    if (cc.GetByName(phonenumber, name).Rows.Count > 0)
                    {
                        int piece = int.Parse(cc.GetByName(phonenumber, name).Rows[0][2].ToString());
                        cc.UpdatePiece(piece + 1, name, phonenumber);

                    }

                    else
                    {
                        cc.Add(name, 1, phonenumber, price,selection);
                    }

                    for (int i = 0; i < cc.Get(phonenumber).Rows.Count; i++)
                    {
                        productNumber += int.Parse(cc.Get(phonenumber).Rows[i][2].ToString());
                    }

                    PaymentDelivery.TakeNumberPorduct(productNumber);

                    added.Text = productNumber.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
