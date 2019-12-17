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

namespace Techonology_Market_Management_System
{
    public partial class Edit_Product : Form
    {
        Computers comp = new Computers();
        Admin_Panel Admin_Panel;


        public Edit_Product()
        {
            InitializeComponent();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchID.Text.Trim() == "" && searchName.Text.Trim() == "")
                    searchError.Text = "Parameters can not be empty.";
                else
                {
                    if (searchID.Text.Trim() != "" && searchName.Text.Trim() == "")
                    {
                        dataGridView1.DataSource = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers");
                        tID.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][0].ToString();
                        tName.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][1].ToString();
                        tPrice.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][2].ToString();
                        tPiece.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][3].ToString();
                        tDate.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][4].ToString();
                        tBrand.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][5].ToString();
                        tGPU.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][6].ToString();
                        tCPU.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][7].ToString();
                        tRAM.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][8].ToString();
                        tSS.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][9].ToString();
                        tOS.Text = comp.GetByID(int.Parse(searchID.Text.Trim()), "Computers").Rows[0][10].ToString();

                    }

                    else if (searchID.Text.Trim() == "" && searchName.Text.Trim() != "")
                    {
                        dataGridView1.DataSource = comp.GetByName(searchName.Text.Trim(), "Computers");
                        tID.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][0].ToString();
                        tName.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][1].ToString();
                        tPrice.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][2].ToString();
                        tPiece.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][3].ToString();
                        tDate.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][4].ToString();
                        tBrand.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][5].ToString();
                        tGPU.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][6].ToString();
                        tCPU.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][7].ToString();
                        tRAM.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][8].ToString();
                        tSS.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][9].ToString();
                        tOS.Text = comp.GetByName(searchName.Text.Trim(), "Computers").Rows[0][10].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(tID.Text.Trim());
            string name = tName.Text.Trim();
            int price = int.Parse(tPrice.Text.Trim());
            int piece = int.Parse(tPiece.Text.Trim());
            string date = tDate.Text.Trim();
            string brand = tBrand.Text.Trim();
            string gpu = tGPU.Text.Trim();
            string cpu = tCPU.Text.Trim();
            int ram = int.Parse(tRAM.Text.Trim());
            float ss = float.Parse(tSS.Text.Trim());
            string os = tOS.Text.Trim();

            var result = comp.GetByName(name,"Computers");

            if(result.Rows.Count > 0)
            {
                lberror.Text = "This product already exists";
            }
            else
            {
                comp.Add(name, gpu, price, piece, date, brand, cpu, ram, ss, os);
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
            string gpu = tGPU.Text.Trim();
            string cpu = tCPU.Text.Trim();
            int ram = int.Parse(tRAM.Text.Trim());
            float ss = float.Parse(tSS.Text.Trim());
            string os = tOS.Text.Trim();

            comp.Update(id, name, gpu, price, piece, date, brand, cpu, ram, ss, os);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Edit_Product_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = comp.Get("Computers");
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_Product_Load(sender, e);
        }
    }
}
