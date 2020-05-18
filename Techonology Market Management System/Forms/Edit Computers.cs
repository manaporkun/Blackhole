using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Blackhole.Classes;
using Technology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System
{
    public partial class Edit_Product : Form
    {
        private AdminPanel _adminPanel;
        private readonly Computers _comp = new Computers();
        private string imgLoc = "";
        byte[] img = null;
        private readonly Product _product = new Product();

        public Edit_Product()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
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
                        if(_comp.GetById(id, "Computers").Rows[0][12].ToString() != "NULL")
                        {
                            
                            img = (byte[])(_comp.GetById(id, "Computers").Rows[0][12]);
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

                        
                        CommonFunctions.GetComputerById(id, "Computers", dataGridView1, tID,tName,tPrice,tPiece,tDate,tBrand,tGPU,tCPU,tRAM,tSS,tOS);
                    }
                    else if (searchID.Text.Length == 0 && searchName.Text.Length != 0)
                    {
                        var productName = searchName.Text.Trim();
                        CommonFunctions.GetComputerByName(productName,"Computers", dataGridView1, tID, tName, tPrice, tPiece, tDate, tBrand, tGPU, tCPU, tRAM, tSS, tOS);
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

        private void button1_Click(object sender, EventArgs e)
        {
            GetComputerInfo("add");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetComputerInfo("update");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void Edit_Product_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _comp.Get("Computers");
            searchError.Text = "";
            lberror.Text = "";
            tID.Text = string.Empty;
            tName.Text = string.Empty;
            tPrice.Text = string.Empty;
            tPiece.Text = string.Empty;
            tDate.Text = string.Empty;
            tBrand.Text = string.Empty;
            tGPU.Text = string.Empty;
            tCPU.Text = string.Empty;
            tRAM.Text = string.Empty;
            tSS.Text = string.Empty;
            tOS.Text = string.Empty;
            productPicture.Image = null;
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_Product_Load(sender, e);
        }

        private void GetComputerInfo(string s)
        {

            try
            {
                var name = tName.Text.Trim();
                var price = int.Parse(tPrice.Text.Trim());
                var piece = int.Parse(tPiece.Text.Trim());
                var date = tDate.Text.Trim();
                var brand = tBrand.Text.Trim();
                var gpu = tGPU.Text.Trim();
                var cpu = tCPU.Text.Trim();
                var ram = int.Parse(tRAM.Text.Trim());
                var ss = float.Parse(tSS.Text.Trim());
                var os = tOS.Text.Trim();
                var fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                switch (s)
                {
                    case "add":
                    {
                        var result = _comp.GetByName(name, "Computers");

                        if (result.Rows.Count > 0)
                        {
                            lberror.ForeColor = Color.Red;
                            lberror.Text = CommonFunctions.ReturnString("exist");
                        }
                            
                        else
                        {
                            _comp.Add(name, gpu, price, piece, date, brand, cpu, ram, ss, os);
                            _product.AddImage(int.Parse(_product.GetByName(name,"Computers").Rows[0][0].ToString()),img, "Computers");
                            lberror.ForeColor = Color.Green;
                            lberror.Text = CommonFunctions.ReturnString("success");
                        }
                            
                        break;
                    }
                    case "update":
                    {
                        var id = int.Parse(tID.Text.Trim());

                        _comp.Update(id, name, gpu, price, piece, date, brand, cpu, ram, ss, os);
                        _comp.AddImage(id, img, "Computers");
                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
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