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
    public partial class Edit_SmartPhones : Form
    {
        SmartPhones smartPhones = new SmartPhones();
        Admin_Panel Admin_Panel;

        public Edit_SmartPhones()
        {
            InitializeComponent();
        }

        private void Edit_SmartPhones_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = smartPhones.Get("SmartPhones");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Admin_Panel == null)
            {
                Admin_Panel = new Admin_Panel();
                Admin_Panel.Show();
                this.Close();
            }
            else Admin_Panel = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchID.Text.Trim() == "" && searchName.Text.Trim() == "")
                    searchError.Text = "Parameters can not be empty.";
                else
                {
                    if (searchID.Text.Trim() != "" && searchName.Text.Trim() == "")
                    {
                        dataGridView1.DataSource = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones");
                        tID.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][0].ToString();
                        tName.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][1].ToString();
                        tPrice.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][2].ToString();
                        tPiece.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][3].ToString();
                        tDate.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][4].ToString();
                        tBrand.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][5].ToString();
                        //tGPU.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][6].ToString();
                        tCPU.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][6].ToString();
                        tRAM.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][7].ToString();
                        tSS.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][8].ToString();
                        textBox1.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones").Rows[0][9].ToString();
                        //tOS.Text = smartPhones.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][10].ToString();

                    }

                    else if (searchID.Text.Trim() == "" && searchName.Text.Trim() != "")
                    {
                        dataGridView1.DataSource = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones");
                        tID.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][0].ToString();
                        tName.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][1].ToString();
                        tPrice.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][2].ToString();
                        tPiece.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][3].ToString();
                        tDate.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][4].ToString();
                        tBrand.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][5].ToString();
                        //tGPU.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][6].ToString();
                        tCPU.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][6].ToString();
                        tRAM.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][7].ToString();
                        tSS.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][8].ToString();
                        textBox1.Text = smartPhones.GetByName(searchName.Text.Trim(), "SmartPhones").Rows[0][9].ToString();
                        // tOS.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][10].ToString();
                    }

                    else
                        searchError.Text = "You can only search with only one parameter";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tID.Text.Trim());
            string name = tName.Text.Trim();
            int price = int.Parse(tPrice.Text.Trim());
            int piece = int.Parse(tPiece.Text.Trim());
            string date = tDate.Text.Trim();
            string brand = tBrand.Text.Trim();
            //string gpu = tGPU.Text.Trim();
            string cpu = tCPU.Text.Trim();
            int ram = int.Parse(tRAM.Text.Trim());
            int ss = int.Parse(tSS.Text.Trim());
            string screentype = textBox1.Text.Trim();
            //string os = tOS.Text.Trim();

            smartPhones.Update(id, name, price, piece, date, brand, cpu, ram, ss, screentype);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tID.Text.Trim());
            string name = tName.Text.Trim();
            int price = int.Parse(tPrice.Text.Trim());
            int piece = int.Parse(tPiece.Text.Trim());
            string date = tDate.Text.Trim();
            string brand = tBrand.Text.Trim();
            //string gpu = tGPU.Text.Trim();
            string cpu = tCPU.Text.Trim();
            int ram = int.Parse(tRAM.Text.Trim());
            int ss = int.Parse(tSS.Text.Trim());
            string screentype = textBox1.Text.Trim();
            //string os = tOS.Text.Trim();

            var result = smartPhones.GetByName(name, "Computers");

            if (result.Rows.Count > 0)
            {
                lberror.Text = "This product already exists";
            }
            else
            {
                smartPhones.Add(name,price,piece,date,brand,cpu,ram,ss,screentype,"SmartPhones");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_SmartPhones_Load(sender, e);
        }
    }
}
