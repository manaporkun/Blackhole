using Blackhole.Classes;
using Technology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Forms
{
    public partial class Edit_SmartPhones : Form
    {
        private AdminPanel Admin_Panel;
        private readonly SmartPhones smartPhones = new SmartPhones();
        private string imgLoc = "";
        private byte[] img = null;
        private readonly Product _product = new Product();
        public Edit_SmartPhones()
        {
            InitializeComponent();
        }

        private void Edit_SmartPhones_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = smartPhones.Get("SmartPhones");
            searchError.Text = "";
            lberror.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Admin_Panel == null)
            {
                Admin_Panel = new AdminPanel();
                Admin_Panel.Show();
                Close();
            }
            else
            {
                Admin_Panel = null;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                searchError.Text = "";
                lberror.Text = "";
                if (searchID.Text.Length == 0 && searchName.Text.Length == 0)
                {
                    searchError.Text = CommonFunctions.ReturnString("empty");
                }
                else
                {
                    if (searchID.Text.Length != 0 && searchName.Text.Length == 0)
                    {
                        var id = int.Parse(searchID.Text.Trim());
                        CommonFunctions.GetSmartphoneById(dataGridView1, id, tID, tName, tPrice, tPiece, tDate, tBrand, tCPU, tRAM, tSS, textBox1);
                    }

                    else if (searchID.Text.Length == 0 && searchName.Text.Length != 0)
                    {
                        var name = searchName.Text.Trim();
                        CommonFunctions.GetSmartphonebyName(dataGridView1, name, tID, tName, tPrice, tPiece, tDate, tBrand, tCPU, tRAM, tSS, textBox1);
                    }

                    else
                    {
                        searchError.Text = CommonFunctions.ReturnString("one");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_SmartPhones_Load(sender, e);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var name = tName.Text.Trim();
                var price = int.Parse(tPrice.Text.Trim());
                var piece = int.Parse(tPiece.Text.Trim());
                var date = tDate.Text.Trim();
                var brand = tBrand.Text.Trim();
                var cpu = tCPU.Text.Trim();
                var ram = int.Parse(tRAM.Text.Trim());
                var ss = int.Parse(tSS.Text.Trim());
                var screentype = textBox1.Text.Trim();
                var fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                var result = smartPhones.GetByName(name, "SmartPhones");

                if (result.Rows.Count > 0)
                {
                    lberror.ForeColor = Color.Red;
                    lberror.Text = CommonFunctions.ReturnString("exist");

                }

                else
                {
                    smartPhones.Add(name, price, piece, date, brand, cpu, ram, ss, screentype);
                    _product.AddImage(int.Parse(_product.GetByName(name, "SmartPhones").Rows[0][0].ToString()), img, "SmartPhones");
                    lberror.ForeColor = Color.Green;
                    lberror.Text = CommonFunctions.ReturnString("success");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var id = int.Parse(tID.Text.Trim());
            var name = tName.Text.Trim();
            var price = int.Parse(tPrice.Text.Trim());
            var piece = int.Parse(tPiece.Text.Trim());
            var date = tDate.Text.Trim();
            var brand = tBrand.Text.Trim();
            var cpu = tCPU.Text.Trim();
            var ram = int.Parse(tRAM.Text.Trim());
            var ss = int.Parse(tSS.Text.Trim());
            var screentype = textBox1.Text.Trim();
            var fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            smartPhones.Update(id, name, price, piece, date, brand, cpu, ram, ss, screentype);
            _product.AddImage(id, img, "SmartPhones");
        }

        private void search_Click_1(object sender, EventArgs e)
        {
            try
            {
                searchError.Text = string.Empty;
                lberror.Text = string.Empty;
                if (searchID.Text.Length == 0 && searchName.Text.Trim().Length == 0)
                {
                    searchError.Text = CommonFunctions.ReturnString("empty");
                }
                else
                {
                    if (searchID.Text.Length != 0 && searchName.Text.Length == 0)
                    {
                        var id = int.Parse(searchID.Text.Trim());
                        byte[] img;
                        if (smartPhones.GetById(id, "SmartPhones").Rows[0][10].ToString() != "NULL")
                        {

                            img = (byte[])(smartPhones.GetById(id, "SmartPhones").Rows[0][10]);
                            if (img == null)
                            {
                                productPicture.Image = null;
                            }
                            else
                            {
                                var ms = new MemoryStream(img);
                                productPicture.Image = Image.FromStream(ms);

                            }
                        }


                        CommonFunctions.GetSmartphoneById(dataGridView1, id, tID, tName, tPrice, tPiece, tDate, tBrand, tCPU, tRAM, tSS, textBox1);
                    }
                    else if (searchID.Text.Length == 0 && searchName.Text.Length != 0)
                    {
                        var productName = searchName.Text.Trim();
                        CommonFunctions.GetSmartphonebyName(dataGridView1, productName, tID, tName, tPrice, tPiece, tDate, tBrand, tCPU, tRAM, tSS, textBox1);
                    }
                    else
                    {
                        searchError.Text = CommonFunctions.ReturnString("one");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}